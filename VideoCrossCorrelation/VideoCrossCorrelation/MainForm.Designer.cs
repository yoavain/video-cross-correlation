using MetroFramework;
using System;
using System.Windows.Forms;

namespace VideoCrossCorrelation
{
    partial class InputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new MetroFramework.Controls.MetroPanel();
            this.video2TextBox = new MetroFramework.Controls.MetroTextBox();
            this.video2Button = new MetroFramework.Controls.MetroButton();
            this.video1TextBox = new MetroFramework.Controls.MetroTextBox();
            this.video1Button = new MetroFramework.Controls.MetroButton();
            this.resultTextBox = new MetroFramework.Controls.MetroTextBox();
            this.executeButton = new MetroFramework.Controls.MetroButton();
            this.ExecutePanel = new MetroFramework.Controls.MetroPanel();
            this.unitLabel = new MetroFramework.Controls.MetroLabel();
            this.configurationPanel = new MetroFramework.Controls.MetroPanel();
            this.durationLabel = new MetroFramework.Controls.MetroLabel();
            this.startTimeLabel = new MetroFramework.Controls.MetroLabel();
            this.durationTextBox = new MetroFramework.Controls.MetroTextBox();
            this.startTimeTextBox = new MetroFramework.Controls.MetroTextBox();
            this.playButton = new MetroFramework.Controls.MetroButton();
            this.pauseButton = new MetroFramework.Controls.MetroButton();
            this.stopButton = new MetroFramework.Controls.MetroButton();
            this.playerControlPanel = new MetroFramework.Controls.MetroPanel();
            this.labelTotalTimePrefix = new MetroFramework.Controls.MetroLabel();
            this.labelCurrentTimePrefix = new MetroFramework.Controls.MetroLabel();
            this.labelTotalTime = new MetroFramework.Controls.MetroLabel();
            this.labelCurrentTime = new MetroFramework.Controls.MetroLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.waveformPainter1 = new NAudio.Gui.WaveformPainter();
            this.waveformPainter2 = new NAudio.Gui.WaveformPainter();
            this.waveFormPanel = new MetroFramework.Controls.MetroPanel();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.darkModeToggle = new MetroFramework.Controls.MetroToggle();
            this.colorComboBox = new MetroFramework.Controls.MetroComboBox();
            this.colorLabel = new MetroFramework.Controls.MetroLabel();
            this.darkModeLabel = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            this.ExecutePanel.SuspendLayout();
            this.configurationPanel.SuspendLayout();
            this.playerControlPanel.SuspendLayout();
            this.waveFormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.video2TextBox);
            this.panel1.Controls.Add(this.video2Button);
            this.panel1.Controls.Add(this.video1TextBox);
            this.panel1.Controls.Add(this.video1Button);
            this.panel1.HorizontalScrollbarBarColor = true;
            this.panel1.HorizontalScrollbarHighlightOnWheel = false;
            this.panel1.HorizontalScrollbarSize = 10;
            this.panel1.Location = new System.Drawing.Point(14, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 161);
            this.panel1.TabIndex = 0;
            this.panel1.VerticalScrollbarBarColor = true;
            this.panel1.VerticalScrollbarHighlightOnWheel = false;
            this.panel1.VerticalScrollbarSize = 10;
            // 
            // video2TextBox
            // 
            this.video2TextBox.Location = new System.Drawing.Point(143, 106);
            this.video2TextBox.Name = "video2TextBox";
            this.video2TextBox.Size = new System.Drawing.Size(347, 20);
            this.video2TextBox.TabIndex = 3;
            // 
            // video2Button
            // 
            this.video2Button.Location = new System.Drawing.Point(27, 91);
            this.video2Button.Name = "video2Button";
            this.video2Button.Size = new System.Drawing.Size(85, 49);
            this.video2Button.TabIndex = 2;
            this.video2Button.Text = "Video #2";
            this.video2Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // video1TextBox
            // 
            this.video1TextBox.Location = new System.Drawing.Point(143, 38);
            this.video1TextBox.Name = "video1TextBox";
            this.video1TextBox.Size = new System.Drawing.Size(347, 20);
            this.video1TextBox.TabIndex = 1;
            // 
            // video1Button
            // 
            this.video1Button.Location = new System.Drawing.Point(27, 21);
            this.video1Button.Name = "video1Button";
            this.video1Button.Size = new System.Drawing.Size(85, 49);
            this.video1Button.TabIndex = 0;
            this.video1Button.Text = "Video #1";
            this.video1Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(166, 33);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(103, 26);
            this.resultTextBox.TabIndex = 5;
            this.resultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // executeButton
            // 
            this.executeButton.Enabled = false;
            this.executeButton.Location = new System.Drawing.Point(15, 26);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(126, 40);
            this.executeButton.TabIndex = 4;
            this.executeButton.Text = "Calculate Delay";
            this.executeButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // ExecutePanel
            // 
            this.ExecutePanel.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ExecutePanel.Controls.Add(this.unitLabel);
            this.ExecutePanel.Controls.Add(this.resultTextBox);
            this.ExecutePanel.Controls.Add(this.executeButton);
            this.ExecutePanel.HorizontalScrollbarBarColor = true;
            this.ExecutePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ExecutePanel.HorizontalScrollbarSize = 10;
            this.ExecutePanel.Location = new System.Drawing.Point(14, 246);
            this.ExecutePanel.Name = "ExecutePanel";
            this.ExecutePanel.Size = new System.Drawing.Size(350, 92);
            this.ExecutePanel.TabIndex = 1;
            this.ExecutePanel.VerticalScrollbarBarColor = true;
            this.ExecutePanel.VerticalScrollbarHighlightOnWheel = false;
            this.ExecutePanel.VerticalScrollbarSize = 10;
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Location = new System.Drawing.Point(273, 35);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(35, 19);
            this.unitLabel.TabIndex = 6;
            this.unitLabel.Text = "[sec]";
            this.unitLabel.Visible = false;
            // 
            // configurationPanel
            // 
            this.configurationPanel.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.configurationPanel.Controls.Add(this.durationLabel);
            this.configurationPanel.Controls.Add(this.startTimeLabel);
            this.configurationPanel.Controls.Add(this.durationTextBox);
            this.configurationPanel.Controls.Add(this.startTimeTextBox);
            this.configurationPanel.HorizontalScrollbarBarColor = true;
            this.configurationPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.configurationPanel.HorizontalScrollbarSize = 10;
            this.configurationPanel.Location = new System.Drawing.Point(540, 154);
            this.configurationPanel.Name = "configurationPanel";
            this.configurationPanel.Size = new System.Drawing.Size(191, 70);
            this.configurationPanel.TabIndex = 2;
            this.configurationPanel.VerticalScrollbarBarColor = true;
            this.configurationPanel.VerticalScrollbarHighlightOnWheel = false;
            this.configurationPanel.VerticalScrollbarSize = 10;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(7, 38);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(89, 19);
            this.durationLabel.TabIndex = 3;
            this.durationLabel.Text = "Duration [sec]";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(7, 10);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(100, 19);
            this.startTimeLabel.TabIndex = 2;
            this.startTimeLabel.Text = "Start Time [sec]";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Location = new System.Drawing.Point(111, 37);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(50, 20);
            this.durationTextBox.TabIndex = 1;
            this.durationTextBox.Text = "60";
            this.durationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.durationTextBox.TextChanged += new System.EventHandler(this.durationTextBox_TextChanged);
            // 
            // startTimeTextBox
            // 
            this.startTimeTextBox.Location = new System.Drawing.Point(111, 9);
            this.startTimeTextBox.Name = "startTimeTextBox";
            this.startTimeTextBox.Size = new System.Drawing.Size(50, 20);
            this.startTimeTextBox.TabIndex = 0;
            this.startTimeTextBox.Text = "0";
            this.startTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startTimeTextBox.TextChanged += new System.EventHandler(this.startTimeTextBox_TextChanged);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(31, 14);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(80, 28);
            this.playButton.TabIndex = 3;
            this.playButton.Text = "Play";
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(117, 14);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(80, 28);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(203, 14);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(80, 28);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playerControlPanel
            // 
            this.playerControlPanel.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.playerControlPanel.Controls.Add(this.labelTotalTimePrefix);
            this.playerControlPanel.Controls.Add(this.labelCurrentTimePrefix);
            this.playerControlPanel.Controls.Add(this.labelTotalTime);
            this.playerControlPanel.Controls.Add(this.labelCurrentTime);
            this.playerControlPanel.Controls.Add(this.playButton);
            this.playerControlPanel.Controls.Add(this.stopButton);
            this.playerControlPanel.Controls.Add(this.pauseButton);
            this.playerControlPanel.HorizontalScrollbarBarColor = true;
            this.playerControlPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.playerControlPanel.HorizontalScrollbarSize = 10;
            this.playerControlPanel.Location = new System.Drawing.Point(410, 246);
            this.playerControlPanel.Name = "playerControlPanel";
            this.playerControlPanel.Size = new System.Drawing.Size(321, 92);
            this.playerControlPanel.TabIndex = 6;
            this.playerControlPanel.VerticalScrollbarBarColor = true;
            this.playerControlPanel.VerticalScrollbarHighlightOnWheel = false;
            this.playerControlPanel.VerticalScrollbarSize = 10;
            this.playerControlPanel.Visible = false;
            // 
            // labelTotalTimePrefix
            // 
            this.labelTotalTimePrefix.AutoSize = true;
            this.labelTotalTimePrefix.Location = new System.Drawing.Point(173, 58);
            this.labelTotalTimePrefix.Name = "labelTotalTimePrefix";
            this.labelTotalTimePrefix.Size = new System.Drawing.Size(72, 19);
            this.labelTotalTimePrefix.TabIndex = 9;
            this.labelTotalTimePrefix.Text = "Total Time:";
            // 
            // labelCurrentTimePrefix
            // 
            this.labelCurrentTimePrefix.AutoSize = true;
            this.labelCurrentTimePrefix.Location = new System.Drawing.Point(31, 57);
            this.labelCurrentTimePrefix.Name = "labelCurrentTimePrefix";
            this.labelCurrentTimePrefix.Size = new System.Drawing.Size(89, 19);
            this.labelCurrentTimePrefix.TabIndex = 8;
            this.labelCurrentTimePrefix.Text = "Current Time:";
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.AutoSize = true;
            this.labelTotalTime.Location = new System.Drawing.Point(243, 58);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(40, 19);
            this.labelTotalTime.TabIndex = 7;
            this.labelTotalTime.Text = "00:00";
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Location = new System.Drawing.Point(117, 58);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(40, 19);
            this.labelCurrentTime.TabIndex = 6;
            this.labelCurrentTime.Text = "00:00";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // waveformPainter1
            // 
            this.waveformPainter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waveformPainter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.waveformPainter1.ForeColor = System.Drawing.Color.ForestGreen;
            this.waveformPainter1.Location = new System.Drawing.Point(15, 20);
            this.waveformPainter1.Name = "waveformPainter1";
            this.waveformPainter1.Size = new System.Drawing.Size(683, 60);
            this.waveformPainter1.TabIndex = 19;
            this.waveformPainter1.Text = "waveformPainter1";
            // 
            // waveformPainter2
            // 
            this.waveformPainter2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waveformPainter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.waveformPainter2.ForeColor = System.Drawing.Color.ForestGreen;
            this.waveformPainter2.Location = new System.Drawing.Point(15, 95);
            this.waveformPainter2.Name = "waveformPainter2";
            this.waveformPainter2.Size = new System.Drawing.Size(683, 60);
            this.waveformPainter2.TabIndex = 19;
            this.waveformPainter2.Text = "waveformPainter2";
            // 
            // waveFormPanel
            // 
            this.waveFormPanel.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.waveFormPanel.Controls.Add(this.waveformPainter2);
            this.waveFormPanel.Controls.Add(this.waveformPainter1);
            this.waveFormPanel.HorizontalScrollbarBarColor = true;
            this.waveFormPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.waveFormPanel.HorizontalScrollbarSize = 10;
            this.waveFormPanel.Location = new System.Drawing.Point(14, 361);
            this.waveFormPanel.Name = "waveFormPanel";
            this.waveFormPanel.Size = new System.Drawing.Size(717, 173);
            this.waveFormPanel.TabIndex = 7;
            this.waveFormPanel.VerticalScrollbarBarColor = true;
            this.waveFormPanel.VerticalScrollbarHighlightOnWheel = false;
            this.waveFormPanel.VerticalScrollbarSize = 10;
            this.waveFormPanel.Visible = false;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.darkModeToggle);
            this.metroPanel1.Controls.Add(this.colorComboBox);
            this.metroPanel1.Controls.Add(this.colorLabel);
            this.metroPanel1.Controls.Add(this.darkModeLabel);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(540, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(191, 85);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // darkModeToggle
            // 
            this.darkModeToggle.AutoSize = true;
            this.darkModeToggle.Location = new System.Drawing.Point(99, 14);
            this.darkModeToggle.Name = "darkModeToggle";
            this.darkModeToggle.Size = new System.Drawing.Size(80, 17);
            this.darkModeToggle.TabIndex = 5;
            this.darkModeToggle.Text = "Off";
            this.darkModeToggle.UseVisualStyleBackColor = true;
            this.darkModeToggle.CheckedChanged += new System.EventHandler(this.darkModeToggle_CheckedChanged);
            // 
            // colorComboBox
            // 
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.ItemHeight = 23;
            this.colorComboBox.Items.AddRange(new object[] {
            "Black",
            "White",
            "Silver",
            "Blue",
            "Green",
            "Lime",
            "Teal",
            "Orange",
            "Brown",
            "Pink",
            "Magenta",
            "Purple",
            "Red",
            "Yellow",
            "Default"});
            this.colorComboBox.Location = new System.Drawing.Point(99, 51);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(83, 29);
            this.colorComboBox.TabIndex = 4;
            this.colorComboBox.SelectedIndexChanged += new System.EventHandler(this.colorComboBox_SelectedIndexChanged);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(7, 51);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(42, 19);
            this.colorLabel.TabIndex = 3;
            this.colorLabel.Text = "Color";
            // 
            // darkModeLabel
            // 
            this.darkModeLabel.AutoSize = true;
            this.darkModeLabel.Location = new System.Drawing.Point(7, 12);
            this.darkModeLabel.Name = "darkModeLabel";
            this.darkModeLabel.Size = new System.Drawing.Size(75, 19);
            this.darkModeLabel.TabIndex = 2;
            this.darkModeLabel.Text = "Dark Mode";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 552);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.waveFormPanel);
            this.Controls.Add(this.playerControlPanel);
            this.Controls.Add(this.configurationPanel);
            this.Controls.Add(this.ExecutePanel);
            this.Controls.Add(this.panel1);
            this.Name = "InputForm";
            this.Text = "Video Cross-Correlation Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputForm_FormClosing);
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.panel1.ResumeLayout(false);
            this.ExecutePanel.ResumeLayout(false);
            this.ExecutePanel.PerformLayout();
            this.configurationPanel.ResumeLayout(false);
            this.configurationPanel.PerformLayout();
            this.playerControlPanel.ResumeLayout(false);
            this.playerControlPanel.PerformLayout();
            this.waveFormPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel panel1;
        private MetroFramework.Controls.MetroButton video1Button;
        private MetroFramework.Controls.MetroTextBox video1TextBox;
        private MetroFramework.Controls.MetroTextBox video2TextBox;
        private MetroFramework.Controls.MetroButton video2Button;
        private MetroFramework.Controls.MetroTextBox resultTextBox;
        private MetroFramework.Controls.MetroButton executeButton;
        private MetroFramework.Controls.MetroPanel ExecutePanel;
        private MetroFramework.Controls.MetroPanel configurationPanel;
        private MetroFramework.Controls.MetroLabel durationLabel;
        private MetroFramework.Controls.MetroLabel startTimeLabel;
        private MetroFramework.Controls.MetroTextBox durationTextBox;
        private MetroFramework.Controls.MetroTextBox startTimeTextBox;
        private MetroFramework.Controls.MetroLabel unitLabel;
        private MetroFramework.Controls.MetroButton playButton;
        private MetroFramework.Controls.MetroButton pauseButton;
        private MetroFramework.Controls.MetroButton stopButton;
        private MetroFramework.Controls.MetroPanel playerControlPanel;
        private MetroFramework.Controls.MetroLabel labelTotalTimePrefix;
        private MetroFramework.Controls.MetroLabel labelCurrentTimePrefix;
        private MetroFramework.Controls.MetroLabel labelTotalTime;
        private MetroFramework.Controls.MetroLabel labelCurrentTime;
        private System.Windows.Forms.Timer timer;
        private MetroFramework.Controls.MetroPanel waveFormPanel;
        private NAudio.Gui.WaveformPainter waveformPainter1;
        private NAudio.Gui.WaveformPainter waveformPainter2;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroToggle darkModeToggle;
        private MetroFramework.Controls.MetroComboBox colorComboBox;
        private MetroFramework.Controls.MetroLabel colorLabel;
        private MetroFramework.Controls.MetroLabel darkModeLabel;
    }
}

