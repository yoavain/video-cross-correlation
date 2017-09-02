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
        private string ExecuteProcess(string processName,string workingDir, string args)
        {
            var output = new StringBuilder();
            var proc = new Process
            {
                StartInfo =
                {
                    FileName = processName,
                    WorkingDirectory = workingDir,
                    Arguments = args,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
        }
            };
            if (!proc.Start())
            {
                Console.WriteLine("Error starting");
                return "Error";
            }
            var reader = proc.StandardError;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                output.AppendLine(line);
            }
            var rc = proc.ExitCode;
            proc.Close();
            return rc == 0 ? output.ToString() : "Error";
        }

        private string ExecuteFfmpeg(string args)
        {
            return ExecuteProcess("ffmpeg.exe", Directory.GetCurrentDirectory() + @"\libs\ffmpeg\bin\", args);
        }

        private string ExecuteFfprobe(string args)
        {
            return ExecuteProcess("ffprobe.exe", Directory.GetCurrentDirectory() + @"\libs\ffmpeg\bin\", args);
        }

        private static double? ExecuteCrossCorrelation(string audioFile, string refAudioFile)
        {
            return CrossCorrelation.CrossCorrelation.Run(audioFile, refAudioFile, "delay");
        }

        private bool ExtractAudioFromVideo(string inputVideoFile, string outputAudioFile, double start, double duration, int channels, int samplingRate)
        {
            var output = ExecuteFfmpeg(string.Format("-i \"{0}\" -y -vn -ss {1} -t {2} -ac {3} -ar {4} \"{5}\"", inputVideoFile, start, duration, channels, samplingRate, outputAudioFile));
            return !"Error".Equals(output);
        }

        private bool NormalizeAudio(string inputAudioFile, string outputAudioFile)
        {
            // Detect volume
            var pass1Output = ExecuteFfmpeg(string.Format("-i \"{0}\" -af \"volumedetect\" -f null /dev/null", inputAudioFile));
            if ("Error".Equals(pass1Output))
            {
                return false;
            }
            const string pattern = @"max_volume: (?<MaxVolume>-\d+.\d+) dB";
            var regex = new Regex(pattern);
            var match = regex.Match(pass1Output);
            var maxVolumeStr = match.Groups["MaxVolume"].Value;
            if (string.IsNullOrEmpty(maxVolumeStr))
            {
                return false;
            }
            var maxVolume = double.Parse(maxVolumeStr);

            // Normalize
            var pass2Output = ExecuteFfmpeg(string.Format("-i \"{0}\" -y -af \"volume ={1} dB\" \"{2}\"", inputAudioFile, -1.0 * maxVolume, outputAudioFile));
            return !"Error".Equals(pass2Output);
        }

        private bool MergeAudioWithDelay(string inputAudioFile1, string inputAudioFile2, string outputAudioFile, int delay)
        {
            var delayStr = delay > 0 ? string.Format("{0}|0", delay) : string.Format("0|{0}", -1 * delay);
            var mergeOutput = ExecuteFfmpeg(string.Format("-i \"{0}\" -i \"{1}\" -filter_complex \"[0][1]amerge[aout];[aout]adelay={2}[adelay]\" -map \"[adelay]\" \"{3}\"",
                inputAudioFile1, inputAudioFile2, delayStr, outputAudioFile));
            return !"Error".Equals(mergeOutput);
        }

        public Dictionary<string, string> GetAudioStreams(string inputVideoFile)
        {
            var ffprobeOutput = ExecuteFfprobe(string.Format("-v 0 -select_streams a -show_entries stream=index,codec_type:stream_tags=title,language -of compact \"{0}\"", inputVideoFile));
            if ("Error".Equals(ffprobeOutput))
            {
                return null;
            }

            var result = new Dictionary<string, string>();

            // Parse output
            using (StringReader reader = new StringReader(ffprobeOutput))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    const string idPattern = @"index=(?<id>\d+)";
                    var idRegex = new Regex(idPattern);
                    var idMatch = idRegex.Match(line);
                    var id = idMatch.Groups["id"].Value;
                    if (string.IsNullOrEmpty(id))
                    {
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
                    if (string.IsNullOrEmpty(title))
                    {
                        streamName = title;
                    }
                    if (string.IsNullOrEmpty(language))
                    {
                        streamName += "[" + language + "]";
                    }
                    if (string.IsNullOrEmpty(streamName))
                    {
                        streamName = "unknown";
                    }

                    result.Add(id, streamName);
                }
            }
            return result;
        }

        public LogicResult RunLogic(string videoFile1, string videoFile2, double start, double duration)
        {
            var audioFile1 = Path.GetTempPath() + Guid.NewGuid() + "_audioFile1.wav";
            var audioFile2 = Path.GetTempPath() + Guid.NewGuid() + "audioFile2.wav";
            var normalizedAudioFile1 = Path.GetTempPath() + Guid.NewGuid() + "_normalizedAudioFile1.wav";
            var normalizedAudioFile2 = Path.GetTempPath() + Guid.NewGuid() + "_normalizedAudioFile2.wav";
            var mergedAudioFile = Path.GetTempPath() + Guid.NewGuid() + "_mergedAudioFile.wav";

            // Extract audio
            var extract1 = ExtractAudioFromVideo(videoFile1, audioFile1, start, duration, 1, 22050);
            var extract2 = ExtractAudioFromVideo(videoFile2, audioFile2, start, duration, 1, 22050);
            if (!(extract1 && extract2)) {
                return LogicResult.FailLogicResult("Failed to extract one or more audio from video files");
            }

            // Normalize
            var normalize1 = NormalizeAudio(audioFile1, normalizedAudioFile1);
            var normalize2 = NormalizeAudio(audioFile2, normalizedAudioFile2);
            if (!(normalize1 && normalize2))
            {
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
            return LogicResult.FailLogicResult("Failed to calculate audio cross-correlation");
        }
    }
}
