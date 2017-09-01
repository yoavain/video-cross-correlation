using System;
using System.Drawing;
using System.Windows.Forms;
using VideoCrossCorrelation.Logic;
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace VideoCrossCorrelation
{
    public partial class InputForm : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private readonly string videoFilter = "Video files (*.mkv, *.mp4, *.avi, *.flv, *.webm, *.mpeg, *.mpg, *.mov) | *.mkv; *.mp4; *.avi; *.flv; *.webm; *.mpeg; *.mpg; *.mov";

        private string mergedAudioFile = null;
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;


        public InputForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = videoFilter;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                video1TextBox.Text = openFileDialog.FileName;
                updateButton3State();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = videoFilter;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                video2TextBox.Text = openFileDialog.FileName;
                updateButton3State();
            }
        }

        private void updateButton3State()
        {
            double d;
            executeButton.Enabled = !string.IsNullOrEmpty(video1TextBox.Text) && 
                !string.IsNullOrEmpty(video2TextBox.Text) &&
                double.TryParse(startTimeTextBox.Text, out d) &&
                double.TryParse(durationTextBox.Text, out d);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var logicExecutor = new LogicExecutor();
            var result = logicExecutor.RunLogic(video1TextBox.Text, video2TextBox.Text, Double.Parse(startTimeTextBox.Text), Double.Parse(durationTextBox.Text));
            if (result.Success)
            {
                resultTextBox.Text = string.Format("{0:0.000}", result.Delay);
                unitLabel.Visible = true;
                
                if (result.MergedAudioFile != null)
                {
                    mergedAudioFile = result.MergedAudioFile;
                    playerControlPanel.Visible = true;
                    waveFormPanel.Visible = true;
                }
            }
        }

        private void startTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            double d;
            if (double.TryParse(startTimeTextBox.Text, out d))
            {
                this.startTimeTextBox.ForeColor = Color.Black;
            }
            else
            {
                this.startTimeTextBox.ForeColor = Color.Red;
            }
            updateButton3State();
        }

        private void durationTextBox_TextChanged(object sender, EventArgs e)
        {
            double d;
            if (double.TryParse(durationTextBox.Text, out d))
            {
                durationTextBox.ForeColor = Color.Black;
            }
            else
            {
                durationTextBox.ForeColor = Color.Red;
            }
            updateButton3State();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    return;
                }
                else if (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    waveOut.Play();
                    return;
                }
            }

            if (String.IsNullOrEmpty(mergedAudioFile))
            {
                return;
            }

            try
            {
                CreateWaveOut();
            }
            catch (Exception driverCreateException)
            {
                MessageBox.Show(String.Format("{0}", driverCreateException.Message));
                return;
            }

            ISampleProvider sampleProvider;
            try
            {
                sampleProvider = CreateInputStream(mergedAudioFile);
            }
            catch (Exception createException)
            {
                MessageBox.Show(String.Format("{0}", createException.Message), "Error Loading File");
                return;
            }


            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
                audioFileReader.TotalTime.Seconds);

            try
            {
                waveOut.Init(sampleProvider);
            }
            catch (Exception initException)
            {
                MessageBox.Show(String.Format("{0}", initException.Message), "Error Initializing Output");
                return;
            }

            waveOut.Play();
        }

        private void CreateWaveOut()
        {
            CloseWaveOut();
            waveOut = new WaveOut();
            waveOut.PlaybackStopped += OnPlaybackStopped;
        }

        void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show(e.Exception.Message, "Playback Device Error");
            }
            if (audioFileReader != null)
            {
                audioFileReader.Position = 0;
            }
        }

        private ISampleProvider CreateInputStream(string fileName)
        {
            audioFileReader = new AudioFileReader(fileName);

            var sampleChannel = new SampleChannel(audioFileReader, true);
            sampleChannel.PreVolumeMeter += OnPreVolumeMeter;
            var postVolumeMeter = new MeteringSampleProvider(sampleChannel);

            return postVolumeMeter;
        }

        void OnPreVolumeMeter(object sender, StreamVolumeEventArgs e)
        {
            // we know it is stereo
            waveformPainter1.AddMax(e.MaxSampleValues[0]);
            waveformPainter2.AddMax(e.MaxSampleValues[1]);
        }

        private void CloseWaveOut()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
            }
            if (audioFileReader != null)
            {
                // this one really closes the file and ACM conversion
                audioFileReader.Dispose();
                //setVolumeDelegate = null;
                audioFileReader = null;
            }
            if (waveOut != null)
            {
                waveOut.Dispose();
                waveOut = null;
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Pause();
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (waveOut != null && audioFileReader != null)
            {
                TimeSpan currentTime = (waveOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audioFileReader.CurrentTime;
//                trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / audioFileReader.TotalTime.TotalSeconds));
                labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes,
                    currentTime.Seconds);
            }
            else
            {
//                trackBarPosition.Value = 0;
            }
        }
    }
}
