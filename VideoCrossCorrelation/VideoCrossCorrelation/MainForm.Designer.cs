﻿namespace VideoCrossCorrelation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.video2TextBox = new System.Windows.Forms.TextBox();
            this.video2Button = new System.Windows.Forms.Button();
            this.video1TextBox = new System.Windows.Forms.TextBox();
            this.video1Button = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.ExecutePanel = new System.Windows.Forms.Panel();
            this.unitLabel = new System.Windows.Forms.Label();
            this.configurationPanel = new System.Windows.Forms.Panel();
            this.durationLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.startTimeTextBox = new System.Windows.Forms.TextBox();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playerControlPanel = new System.Windows.Forms.Panel();
            this.labelTotalTimePrefix = new System.Windows.Forms.Label();
            this.labelCurrentTimePrefix = new System.Windows.Forms.Label();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.waveformPainter1 = new NAudio.Gui.WaveformPainter();
            this.waveformPainter2 = new NAudio.Gui.WaveformPainter();
            this.waveFormPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.ExecutePanel.SuspendLayout();
            this.configurationPanel.SuspendLayout();
            this.playerControlPanel.SuspendLayout();
            this.waveFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.video2TextBox);
            this.panel1.Controls.Add(this.video2Button);
            this.panel1.Controls.Add(this.video1TextBox);
            this.panel1.Controls.Add(this.video1Button);
            this.panel1.Location = new System.Drawing.Point(35, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 189);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // video2TextBox
            // 
            this.video2TextBox.Location = new System.Drawing.Point(143, 125);
            this.video2TextBox.Name = "video2TextBox";
            this.video2TextBox.Size = new System.Drawing.Size(347, 20);
            this.video2TextBox.TabIndex = 3;
            this.video2TextBox.Text = "C:\\Users\\YOAVV~1\\AppData\\Local\\Temp\\test-cross\\p-1sec.mkv";
            // 
            // video2Button
            // 
            this.video2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.video2Button.Location = new System.Drawing.Point(27, 110);
            this.video2Button.Name = "video2Button";
            this.video2Button.Size = new System.Drawing.Size(85, 49);
            this.video2Button.TabIndex = 2;
            this.video2Button.Text = "Video #2";
            this.video2Button.UseVisualStyleBackColor = true;
            this.video2Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // video1TextBox
            // 
            this.video1TextBox.Location = new System.Drawing.Point(143, 43);
            this.video1TextBox.Name = "video1TextBox";
            this.video1TextBox.Size = new System.Drawing.Size(347, 20);
            this.video1TextBox.TabIndex = 1;
            this.video1TextBox.Text = "C:\\Users\\YOAVV~1\\AppData\\Local\\Temp\\test-cross\\p-5sec.mkv";
            // 
            // video1Button
            // 
            this.video1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.video1Button.Location = new System.Drawing.Point(27, 26);
            this.video1Button.Name = "video1Button";
            this.video1Button.Size = new System.Drawing.Size(85, 49);
            this.video1Button.TabIndex = 0;
            this.video1Button.Text = "Video #1";
            this.video1Button.UseVisualStyleBackColor = true;
            this.video1Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTextBox.Location = new System.Drawing.Point(166, 33);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(103, 26);
            this.resultTextBox.TabIndex = 5;
            this.resultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // executeButton
            // 
            this.executeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeButton.Location = new System.Drawing.Point(15, 26);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(126, 40);
            this.executeButton.TabIndex = 4;
            this.executeButton.Text = "Calculate Delay";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // ExecutePanel
            // 
            this.ExecutePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExecutePanel.Controls.Add(this.unitLabel);
            this.ExecutePanel.Controls.Add(this.resultTextBox);
            this.ExecutePanel.Controls.Add(this.executeButton);
            this.ExecutePanel.Location = new System.Drawing.Point(63, 267);
            this.ExecutePanel.Name = "ExecutePanel";
            this.ExecutePanel.Size = new System.Drawing.Size(350, 92);
            this.ExecutePanel.TabIndex = 1;
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitLabel.Location = new System.Drawing.Point(273, 35);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(47, 20);
            this.unitLabel.TabIndex = 6;
            this.unitLabel.Text = "[sec]";
            this.unitLabel.Visible = false;
            // 
            // configurationPanel
            // 
            this.configurationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.configurationPanel.Controls.Add(this.durationLabel);
            this.configurationPanel.Controls.Add(this.startTimeLabel);
            this.configurationPanel.Controls.Add(this.durationTextBox);
            this.configurationPanel.Controls.Add(this.startTimeTextBox);
            this.configurationPanel.Location = new System.Drawing.Point(591, 43);
            this.configurationPanel.Name = "configurationPanel";
            this.configurationPanel.Size = new System.Drawing.Size(230, 189);
            this.configurationPanel.TabIndex = 2;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(7, 91);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(73, 13);
            this.durationLabel.TabIndex = 3;
            this.durationLabel.Text = "Duration [sec]";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(7, 47);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(81, 13);
            this.startTimeLabel.TabIndex = 2;
            this.startTimeLabel.Text = "Start Time [sec]";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Location = new System.Drawing.Point(93, 88);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(50, 20);
            this.durationTextBox.TabIndex = 1;
            this.durationTextBox.Text = "60";
            this.durationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.durationTextBox.TextChanged += new System.EventHandler(this.durationTextBox_TextChanged);
            // 
            // startTimeTextBox
            // 
            this.startTimeTextBox.Location = new System.Drawing.Point(93, 44);
            this.startTimeTextBox.Name = "startTimeTextBox";
            this.startTimeTextBox.Size = new System.Drawing.Size(50, 20);
            this.startTimeTextBox.TabIndex = 0;
            this.startTimeTextBox.Text = "0";
            this.startTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startTimeTextBox.TextChanged += new System.EventHandler(this.startTimeTextBox_TextChanged);
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(31, 14);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(80, 28);
            this.playButton.TabIndex = 3;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseButton.Location = new System.Drawing.Point(117, 14);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(80, 28);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Location = new System.Drawing.Point(203, 14);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(80, 28);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playerControlPanel
            // 
            this.playerControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerControlPanel.Controls.Add(this.labelTotalTimePrefix);
            this.playerControlPanel.Controls.Add(this.labelCurrentTimePrefix);
            this.playerControlPanel.Controls.Add(this.labelTotalTime);
            this.playerControlPanel.Controls.Add(this.labelCurrentTime);
            this.playerControlPanel.Controls.Add(this.playButton);
            this.playerControlPanel.Controls.Add(this.stopButton);
            this.playerControlPanel.Controls.Add(this.pauseButton);
            this.playerControlPanel.Location = new System.Drawing.Point(500, 267);
            this.playerControlPanel.Name = "playerControlPanel";
            this.playerControlPanel.Size = new System.Drawing.Size(321, 92);
            this.playerControlPanel.TabIndex = 6;
            this.playerControlPanel.Visible = false;
            // 
            // labelTotalTimePrefix
            // 
            this.labelTotalTimePrefix.AutoSize = true;
            this.labelTotalTimePrefix.Location = new System.Drawing.Point(183, 58);
            this.labelTotalTimePrefix.Name = "labelTotalTimePrefix";
            this.labelTotalTimePrefix.Size = new System.Drawing.Size(60, 13);
            this.labelTotalTimePrefix.TabIndex = 9;
            this.labelTotalTimePrefix.Text = "Total Time:";
            // 
            // labelCurrentTimePrefix
            // 
            this.labelCurrentTimePrefix.AutoSize = true;
            this.labelCurrentTimePrefix.Location = new System.Drawing.Point(31, 57);
            this.labelCurrentTimePrefix.Name = "labelCurrentTimePrefix";
            this.labelCurrentTimePrefix.Size = new System.Drawing.Size(70, 13);
            this.labelCurrentTimePrefix.TabIndex = 8;
            this.labelCurrentTimePrefix.Text = "Current Time:";
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.AutoSize = true;
            this.labelTotalTime.Location = new System.Drawing.Point(249, 58);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(34, 13);
            this.labelTotalTime.TabIndex = 7;
            this.labelTotalTime.Text = "00:00";
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Location = new System.Drawing.Point(107, 58);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(34, 13);
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
            this.waveformPainter1.Size = new System.Drawing.Size(752, 60);
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
            this.waveformPainter2.Size = new System.Drawing.Size(752, 60);
            this.waveformPainter2.TabIndex = 19;
            this.waveformPainter2.Text = "waveformPainter2";
            // 
            // waveFormPanel
            // 
            this.waveFormPanel.Visible = false;
            this.waveFormPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveFormPanel.Controls.Add(this.waveformPainter2);
            this.waveFormPanel.Controls.Add(this.waveformPainter1);
            this.waveFormPanel.Location = new System.Drawing.Point(35, 391);
            this.waveFormPanel.Name = "waveFormPanel";
            this.waveFormPanel.Size = new System.Drawing.Size(786, 173);
            this.waveFormPanel.TabIndex = 7;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 591);
            this.Controls.Add(this.waveFormPanel);
            this.Controls.Add(this.playerControlPanel);
            this.Controls.Add(this.configurationPanel);
            this.Controls.Add(this.ExecutePanel);
            this.Controls.Add(this.panel1);
            this.Name = "InputForm";
            this.Text = "Video Cross-Correlation Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ExecutePanel.ResumeLayout(false);
            this.ExecutePanel.PerformLayout();
            this.configurationPanel.ResumeLayout(false);
            this.configurationPanel.PerformLayout();
            this.playerControlPanel.ResumeLayout(false);
            this.playerControlPanel.PerformLayout();
            this.waveFormPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button video1Button;
        private System.Windows.Forms.TextBox video1TextBox;
        private System.Windows.Forms.TextBox video2TextBox;
        private System.Windows.Forms.Button video2Button;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Panel ExecutePanel;
        private System.Windows.Forms.Panel configurationPanel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.TextBox startTimeTextBox;
        private System.Windows.Forms.Label unitLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Panel playerControlPanel;
        private System.Windows.Forms.Label labelTotalTimePrefix;
        private System.Windows.Forms.Label labelCurrentTimePrefix;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel waveFormPanel;
        private NAudio.Gui.WaveformPainter waveformPainter1;
        private NAudio.Gui.WaveformPainter waveformPainter2;
    }
}

