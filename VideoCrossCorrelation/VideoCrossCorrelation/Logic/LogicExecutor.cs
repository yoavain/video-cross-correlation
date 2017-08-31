using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace VideoCrossCorrelation.Logic
{
    internal class LogicExecutor
    {
        public string ExecuteProcess(string processName,string workingDir, string args)
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
            return ExecuteProcess("ffmpeg.exe", Directory.GetCurrentDirectory() + @"\libs\", args);
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

        public double? RunLogic(string videoFile1, string videoFile2, double start, double duration)
        {
            var audioFile1 = Path.GetTempPath() + Guid.NewGuid() + ".wav";
            var audioFile2 = Path.GetTempPath() + Guid.NewGuid() + ".wav";
            var normalizedAudioFile1 = Path.GetTempPath() + Guid.NewGuid() + ".wav";
            var normalizedAudioFile2 = Path.GetTempPath() + Guid.NewGuid() + ".wav";

            // Extract audio
            var extract1 = ExtractAudioFromVideo(videoFile1, audioFile1, start, duration, 1, 22050);
            var extract2 = ExtractAudioFromVideo(videoFile2, audioFile2, start, duration, 1, 22050);
            if (!(extract1 && extract2)) {
                return null;
            }

            // Normalize
            var normalize1 = NormalizeAudio(audioFile1, normalizedAudioFile1);
            var normalize2 = NormalizeAudio(audioFile2, normalizedAudioFile2);
            if (!(normalize1 && normalize2))
            {
                return null;
            }

            return ExecuteCrossCorrelation(audioFile1, audioFile2);
        }
    }
}
