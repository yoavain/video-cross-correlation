﻿using System;
using System.Drawing;
using System.Windows.Forms;
using VideoCrossCorrelation.Logic;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using MetroFramework;
using MetroFramework.Controls;
using System.Collections.Generic;

namespace VideoCrossCorrelation
{
    public partial class InputForm : MetroFramework.Forms.MetroForm
    {
        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();
        private readonly string _videoFilter = "Video files (*.mkv, *.mp4, *.avi, *.flv, *.webm, *.mpeg, *.mpg, *.mov) | *.mkv; *.mp4; *.avi; *.flv; *.webm; *.mpeg; *.mpg; *.mov";

        private readonly LogicExecutor _logicExecutor = new LogicExecutor();

        private string _mergedAudioFile;
        private IWavePlayer _waveOut;
        private AudioFileReader _audioFileReader;

        private Dictionary<string, int> _video1AudioStreams;
        private Dictionary<string, int> _video2AudioStreams;

        private readonly BindingSource _video1ComboBoxItemsBindingSource = new BindingSource
        {
            DataSource = new List<string>()
        };
        private readonly BindingSource _video2ComboBoxItemsBindingSource = new BindingSource
        {
            DataSource = new List<string>()
        };
            

        public InputForm()
        {
            InitializeComponent();

            StyleManager = metroStyleManager;
        }

        private void video1Button_Click(object sender, EventArgs e)
        {
            _openFileDialog.RestoreDirectory = true;
            _openFileDialog.Filter = _videoFilter;
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearData();
                video1TextBox.Text = _openFileDialog.FileName;
                var audioStreams = _logicExecutor.GetAudioStreams(_openFileDialog.FileName);
                if (audioStreams.Count > 0)
                {
                    _video1AudioStreams = audioStreams;
                    _video1ComboBoxItemsBindingSource.DataSource = audioStreams.Keys;
                    video1AudioStreamComboBox.SelectedIndex = 0;
                    video1AudioStreamComboBox.Visible = true;
                    if (audioStreams.Count > 1)
                    {
                        video1AudioStreamComboBox.Enabled = true;
                    }
                }
                UpdateExecuteButtonState();
            }
        }

        private void video2Button_Click(object sender, EventArgs e)
        {
            _openFileDialog.RestoreDirectory = true;
            _openFileDialog.Filter = _videoFilter;
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearData();
                video2TextBox.Text = _openFileDialog.FileName;
                var audioStreams = _logicExecutor.GetAudioStreams(_openFileDialog.FileName);
                if (audioStreams.Count > 0)
                {
                    _video2AudioStreams = audioStreams;
                    _video2ComboBoxItemsBindingSource.DataSource = audioStreams.Keys;
                    video2AudioStreamComboBox.SelectedIndex = 0;
                    video2AudioStreamComboBox.Visible = true;
                    if (audioStreams.Count > 1)
                    {
                        video2AudioStreamComboBox.Enabled = true;
                    }
                }
                UpdateExecuteButtonState();
            }
        }

        private void ClearData()
        {
            executeButton.Enabled = false;
            resultTextBox.Text = null;
            playerControlPanel.Visible = false;
            waveFormPanel.Visible = false;
        }

        private void UpdateExecuteButtonState()
        {
            double d;
            executeButton.Enabled = !string.IsNullOrEmpty(video1TextBox.Text) && 
                                    !string.IsNullOrEmpty(video2TextBox.Text) &&
                                    double.TryParse(startTimeTextBox.Text, out d) &&
                                    double.TryParse(durationTextBox.Text, out d);
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            _video1AudioStreams.TryGetValue(video1AudioStreamComboBox.SelectedValue.ToString(), out int video1StreamIndex);
            _video2AudioStreams.TryGetValue(video2AudioStreamComboBox.SelectedValue.ToString(), out int video2StreamIndex);
            var result = _logicExecutor.RunLogic(video1TextBox.Text, video1StreamIndex, video2TextBox.Text, video2StreamIndex, double.Parse(startTimeTextBox.Text), double.Parse(durationTextBox.Text));
            if (result.Success)
            {
                resultTextBox.Text = string.Format("{0:0.000}", result.Delay);
                unitLabel.Visible = true;
                
                if (result.MergedAudioFile != null)
                {
                    _mergedAudioFile = result.MergedAudioFile;
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
                startTimeTextBox.ForeColor = Color.Black;
            }
            else
            {
                startTimeTextBox.ForeColor = Color.Red;
            }
            UpdateExecuteButtonState();
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
            UpdateExecuteButtonState();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (_waveOut != null)
            {
                if (_waveOut.PlaybackState == PlaybackState.Playing)
                {
                    return;
                }
                else if (_waveOut.PlaybackState == PlaybackState.Paused)
                {
                    _waveOut.Play();
                    return;
                }
            }

            if (String.IsNullOrEmpty(_mergedAudioFile))
            {
                return;
            }

            try
            {
                CreateWaveOut();
            }
            catch (Exception driverCreateException)
            {
                MessageBox.Show(string.Format("{0}", driverCreateException.Message));
                return;
            }

            ISampleProvider sampleProvider;
            try
            {
                sampleProvider = CreateInputStream(_mergedAudioFile);
            }
            catch (Exception createException)
            {
                MessageBox.Show(string.Format("{0}", createException.Message), "Error Loading File");
                return;
            }


            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)_audioFileReader.TotalTime.TotalMinutes,
                _audioFileReader.TotalTime.Seconds);

            try
            {
                _waveOut.Init(sampleProvider);
            }
            catch (Exception initException)
            {
                MessageBox.Show(string.Format("{0}", initException.Message), "Error Initializing Output");
                return;
            }

            _waveOut.Play();
        }

        private void CreateWaveOut()
        {
            CloseWaveOut();
            _waveOut = new WaveOut();
            _waveOut.PlaybackStopped += OnPlaybackStopped;
        }

        void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show(e.Exception.Message, "Playback Device Error");
            }
            if (_audioFileReader != null)
            {
                _audioFileReader.Position = 0;
            }
        }

        private ISampleProvider CreateInputStream(string fileName)
        {
            _audioFileReader = new AudioFileReader(fileName);

            var sampleChannel = new SampleChannel(_audioFileReader, true);
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
            if (_waveOut != null)
            {
                _waveOut.Stop();
            }
            if (_audioFileReader != null)
            {
                // this one really closes the file and ACM conversion
                _audioFileReader.Dispose();
                //setVolumeDelegate = null;
                _audioFileReader = null;
            }
            if (_waveOut != null)
            {
                _waveOut.Dispose();
                _waveOut = null;
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_waveOut != null)
            {
                if (_waveOut.PlaybackState == PlaybackState.Playing)
                {
                    _waveOut.Pause();
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (_waveOut != null)
            {
                _waveOut.Stop();
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (_waveOut != null && _audioFileReader != null)
            {
                var currentTime = (_waveOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : _audioFileReader.CurrentTime;
                labelCurrentTime.Text = string.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);
            }
        }

        private void InputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default["MetroTheme"] = metroStyleManager.Theme;
                Properties.Settings.Default["MetroColor"] = metroStyleManager.Style;
                Properties.Settings.Default.Save();
            }
        }

        private void darkModeToggle_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as MetroToggle).Text == "On")
            {
                metroStyleManager.Theme = MetroThemeStyle.Dark;
            }
            else
            {
                metroStyleManager.Theme = MetroThemeStyle.Light;
            }
        }

        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroStyleManager.Style = (MetroColorStyle)Enum.Parse(typeof(MetroColorStyle), (sender as MetroComboBox).Text, true);
            waveformPainter1.ForeColor = Color.FromName(metroStyleManager.Style.ToString());
            waveformPainter2.ForeColor = Color.FromName(metroStyleManager.Style.ToString());
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            var theme = Properties.Settings.Default.MetroTheme;
            var color = Properties.Settings.Default.MetroColor;
            darkModeToggle.Checked = theme == MetroThemeStyle.Dark;
            colorComboBox.SelectedIndex = colorComboBox.Items.IndexOf(color.ToString());

            darkModeToggle_CheckedChanged(darkModeToggle, null);
            colorComboBox_SelectedIndexChanged(colorComboBox, null);
        }
    }
}
