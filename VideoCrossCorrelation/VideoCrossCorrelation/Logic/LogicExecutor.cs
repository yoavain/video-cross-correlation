using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CrossCorrelation;

namespace VideoCrossCorrelation.Logic
{
    class LogicExecutor
    {
       string ExecuteProcess(string processName,string workingDir, string args)
        {
            StringBuilder output = new StringBuilder();
            Process proc = new Process();
            proc.StartInfo.FileName = processName;
            proc.StartInfo.WorkingDirectory = workingDir;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            if (!proc.Start())
            {
                Console.WriteLine("Error starting");
                return "Error";
            }
            StreamReader reader = proc.StandardError;
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

        string ExecuteFFMpeg(string args)
        {
            return ExecuteProcess("ffmpeg.exe", Directory.GetCurrentDirectory() + @"\libs\", args);
        }

        double? ExecuteCrossCorrelation(string audioFile, string refAudioFile)
        {
            return CrossCorrelation.CrossCorrelation.Run(audioFile, refAudioFile, "delay");
        }

        bool ExtractAudioFromVideo(string inputVideoFile, string outputAudioFile, double start, int duration, int channels, int samplingRate)
        {
            string output = ExecuteFFMpeg(string.Format("-i \"{0}\" -y -vn -ss {1} -t {2} -ac {3} -ar {4} \"{5}\"", inputVideoFile, start, duration, channels, samplingRate, outputAudioFile));
            return !"Error".Equals(output);
        }

        bool NormalizeAudio(string inputAudioFile, string outputAudioFile)
        {
            // Detect volume
            string pass1output = ExecuteFFMpeg(string.Format("-i \"{0}\" -af \"volumedetect\" -f null /dev/null", inputAudioFile));
            if ("Error".Equals(pass1output))
            {
                return false;
            }
            string pattern = @"max_volume: (?<MaxVolume>-\d+.\d+) dB";
            Regex regex = new Regex(pattern);
            var match = regex.Match(pass1output);
            string maxVolumeStr = match.Groups["MaxVolume"].Value;
            if (string.IsNullOrEmpty(maxVolumeStr))
            {
                return false;
            }
            var maxVolume = Double.Parse(maxVolumeStr);

            // Normalize
            string pass2output = ExecuteFFMpeg(string.Format("-i \"{0}\" -y -af \"volume ={1} dB\" \"{2}\"", inputAudioFile, -1.0 * maxVolume, outputAudioFile));
            if ("Error".Equals(pass2output))
            {
                return false;
            }

            return true;
        }

        public double? RunLogic(string videoFile1, string videoFile2, double start, int duration)
        {
            string audioFile1 = Path.GetTempPath() + Guid.NewGuid().ToString() + ".wav";
            string audioFile2 = Path.GetTempPath() + Guid.NewGuid().ToString() + ".wav";
            string normalizedAudioFile1 = Path.GetTempPath() + Guid.NewGuid().ToString() + ".wav";
            string normalizedAudioFile2 = Path.GetTempPath() + Guid.NewGuid().ToString() + ".wav";

            // Extract audio
            bool extract1 = ExtractAudioFromVideo(videoFile1, audioFile1, start, duration, 1, 22050);
            bool extract2 = ExtractAudioFromVideo(videoFile2, audioFile2, start, duration, 1, 22050);
            if (!(extract1 && extract2)) {
                return null;
            }

            // Normalize
            bool normalize1 = NormalizeAudio(audioFile1, normalizedAudioFile1);
            bool normalize2 = NormalizeAudio(audioFile2, normalizedAudioFile2);
            if (!(normalize1 && normalize2))
            {
                return null;
            }

            return ExecuteCrossCorrelation(audioFile1, audioFile2);
        }
    }
}
