using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace VideoCrossCorrelation.Logic
{
    internal class LogicExecutor
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogicExecutor));

        private string ExecuteProcess(string processName,string workingDir, string args, bool redirectOutput, bool redirectError)
        {
            Log.Info(string.Format("Calling {0} with args: {1}", processName, args));

            var output = new StringBuilder();
            var proc = new Process
            {
                StartInfo =
                {
                    FileName = workingDir + processName,
                    WorkingDirectory = workingDir,
                    Arguments = args,
                    RedirectStandardError = redirectError,
                    RedirectStandardOutput = redirectOutput,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
        }
            };
            if (!proc.Start())
            {
                Log.Error(string.Format("{0}: Error starting process", processName));
                return "Error";
            }
            if (redirectError)
            {
                var reader = proc.StandardError;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Log.Debug(string.Format("{0} [Error]: {1}",processName, line));
                    output.AppendLine(line);
                }
            }
            if (redirectOutput)
            {
                var reader = proc.StandardOutput;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Log.Debug(string.Format("{0} [Output]: {1}", processName, line));
                    output.AppendLine(line);
                }
            }
            var rc = proc.ExitCode;
            proc.Close();
            Log.Info(string.Format("{0}: exit code = {1}", processName, rc));
            return rc == 0 ? output.ToString() : "Error";
        }

        private string ExecuteFfmpeg(string args)
        {
            return ExecuteProcess("ffmpeg.exe", Directory.GetCurrentDirectory() + @"\libs\ffmpeg\bin\", args, false, true);
        }

        private string ExecuteFfprobe(string args)
        {
            return ExecuteProcess("ffprobe.exe", Directory.GetCurrentDirectory() + @"\libs\ffmpeg\bin\", args, true, false);
        }

        private static double? ExecuteCrossCorrelation(string audioFile, string refAudioFile)
        {
            return CrossCorrelation.CrossCorrelation.Run(audioFile, refAudioFile, "delay");
        }

        private bool ExtractAudioFromVideo(string inputVideoFile, int streamIndex, string outputAudioFile, double start, double duration, int channels, int samplingRate)
        {
            var output = ExecuteFfmpeg(string.Format("-i \"{0}\" -map 0:{1} -y -vn -ss {2} -t {3} -ac {4} -ar {5} \"{6}\"", inputVideoFile, streamIndex, start, duration, channels, samplingRate, outputAudioFile));
            return !"Error".Equals(output);
        }

        private bool NormalizeAudio(string inputAudioFile, string outputAudioFile)
        {
            // Detect volume
            Log.Info(string.Format("Detecting volume for {0}", inputAudioFile));
            var pass1Output = ExecuteFfmpeg(string.Format("-i \"{0}\" -af \"volumedetect\" -f null /dev/null", inputAudioFile));
            if ("Error".Equals(pass1Output))
            {
                Log.Error(string.Format("Failed detecting volume for {0}", inputAudioFile));
                return false;
            }
            const string pattern = @"max_volume: (?<MaxVolume>-\d+.\d+) dB";
            var regex = new Regex(pattern);
            var match = regex.Match(pass1Output);
            var maxVolumeStr = match.Groups["MaxVolume"].Value;
            if (string.IsNullOrEmpty(maxVolumeStr))
            {
                Log.Error(string.Format("Failed detecting volume for {0}. Missing max_volume", inputAudioFile));
                return false;
            }
            var maxVolume = double.Parse(maxVolumeStr);
            Log.Info(string.Format("Max volume for {0} is {1} dB", inputAudioFile, maxVolume));

            // Normalize
            Log.Info(string.Format("Normalizing volume for {0}", inputAudioFile));
            var pass2Output = ExecuteFfmpeg(string.Format("-i \"{0}\" -y -af \"volume ={1} dB\" \"{2}\"", inputAudioFile, -1.0 * maxVolume, outputAudioFile));
            if ("Error".Equals(pass2Output))
            {
                Log.Error(string.Format("Failed normalizing volume for {0}", inputAudioFile));
                return false;
            }
            return true;
        }

        private bool MergeAudioWithDelay(string inputAudioFile1, string inputAudioFile2, string outputAudioFile, int delay)
        {
            Log.Info(string.Format("Merging {0} with {1}", inputAudioFile1, inputAudioFile2));
            string mergeOutput;
            if (delay != 0)
            {
                var delayStr = delay > 0 ? string.Format("{0}|0", delay) : string.Format("0|{0}", -1 * delay);
                mergeOutput = ExecuteFfmpeg(string.Format("-i \"{0}\" -i \"{1}\" -filter_complex \"[0][1]amerge[aout];[aout]adelay={2}[adelay]\" -map \"[adelay]\" \"{3}\"",
                    inputAudioFile1, inputAudioFile2, delayStr, outputAudioFile)); 
            }
            else
            {
                mergeOutput = ExecuteFfmpeg(string.Format("-i \"{0}\" -i \"{1}\" -filter_complex \"[0][1]amerge[aout]\" -map \"[aout]\" \"{2}\"",
                    inputAudioFile1, inputAudioFile2, outputAudioFile));
            }
            if ("Error".Equals(mergeOutput))
            {
                Log.Error(string.Format("Failed merging {0} with {1}", inputAudioFile1, inputAudioFile2));
                return false;
            }
            return true;
        }

        public Dictionary<string, int> GetAudioStreams(string inputVideoFile)
        {
            Log.Info(string.Format("Getting audio streams for {0}", inputVideoFile));
            var ffprobeOutput = ExecuteFfprobe(string.Format("-v 0 -select_streams a -show_entries stream=index,codec_type:stream_tags=title,language -of compact \"{0}\"", inputVideoFile));
            if ("Error".Equals(ffprobeOutput))
            {
                Log.Error(string.Format("Failed getting audio streams for {0}", inputVideoFile));
                return null;
            }

            var result = new Dictionary<string, int>();

            // Parse output
            using (StringReader reader = new StringReader(ffprobeOutput))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    const string idPattern = @"index=(?<id>\d+)";
                    var idRegex = new Regex(idPattern);
                    var idMatch = idRegex.Match(line);
                    var idStr = idMatch.Groups["id"].Value;
                    if (string.IsNullOrEmpty(idStr))
                    {
                        Log.Warn("Failed getting id for audio stream. Skipping");
                        continue;
                    }
                    var parseOk = int.TryParse(idStr, out int id);
                    if (!parseOk)
                    {
                        Log.Warn("Failed parsing id for audio stream. Skipping");
                        continue;
                    }

                    const string languagePattern = @"tag:language=(?<lang>[a-z]+)";
                    var languageRegex = new Regex(languagePattern);
                    var languageMatch = languageRegex.Match(line);
                    var language = languageMatch.Groups["lang"].Value;

                    const string titlePattern = @"tag:title=(?<title>.*)";
                    var titleRegex = new Regex(titlePattern);
                    var titleMatch = titleRegex.Match(line);
                    var title = titleMatch.Groups["title"].Value;

                    var streamName = "";
                    if (!string.IsNullOrEmpty(title))
                    {
                        streamName = title;
                    }
                    if (!string.IsNullOrEmpty(language))
                    {
                        streamName += "[" + language + "]";
                    }
                    if (string.IsNullOrEmpty(streamName))
                    {
                        streamName = "unknown";
                    }

                    Log.Info(string.Format("Adding stream id {0} with name {1}", id, streamName));
                    result.Add(streamName, id);
                }
            }
            Log.Info(string.Format("Found {0} audio stream{1} for {2}", result.Count, (result.Count > 1 ? "s" : ""), inputVideoFile));
            return result;
        }

        public LogicResult RunLogic(string videoFile1, int video1StreamIndex, string videoFile2, int video2StreamIndex, double start, double duration)
        {
            Log.Info(string.Format("Starting logic for {0} and {1}", videoFile1, videoFile2));

            var audioFile1 = Path.GetTempPath() + Guid.NewGuid() + "_audioFile1.wav";
            var audioFile2 = Path.GetTempPath() + Guid.NewGuid() + "audioFile2.wav";
            var normalizedAudioFile1 = Path.GetTempPath() + Guid.NewGuid() + "_normalizedAudioFile1.wav";
            var normalizedAudioFile2 = Path.GetTempPath() + Guid.NewGuid() + "_normalizedAudioFile2.wav";
            var mergedAudioFile = Path.GetTempPath() + Guid.NewGuid() + "_mergedAudioFile.wav";

            // Extract audio
            var extract1 = ExtractAudioFromVideo(videoFile1, video1StreamIndex, audioFile1, start, duration, 1, 22050);
            var extract2 = ExtractAudioFromVideo(videoFile2, video2StreamIndex, audioFile2, start, duration, 1, 22050);
            if (!(extract1 && extract2)) {
                Log.Error("Failed to extract one or more audio from video files");
                return LogicResult.FailLogicResult("Failed to extract one or more audio from video files");
            }

            // Normalize
            var normalize1 = NormalizeAudio(audioFile1, normalizedAudioFile1);
            var normalize2 = NormalizeAudio(audioFile2, normalizedAudioFile2);
            if (!(normalize1 && normalize2))
            {
                Log.Error("Failed to normalize one or more audio files");
                return LogicResult.FailLogicResult("Failed to normalize one or more audio files");
            }

            var crossCorrelationResult = ExecuteCrossCorrelation(normalizedAudioFile1, normalizedAudioFile2);
            if (crossCorrelationResult != null)
            {
                var delay = crossCorrelationResult ?? 0;
                int delayMillis = (int)Math.Round(delay * 1000);
                bool merge = MergeAudioWithDelay(normalizedAudioFile1, normalizedAudioFile2, mergedAudioFile, delayMillis);
                return LogicResult.SuccessLogicResult(delay, merge ? mergedAudioFile : null);
            }
            Log.Error("Failed to calculate audio cross-correlation");
            return LogicResult.FailLogicResult("Failed to calculate audio cross-correlation");
        }
    }
}
