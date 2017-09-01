using System;
using System.Drawing;
using System.Windows.Forms;
using VideoCrossCorrelation.Logic;

namespace VideoCrossCorrelation
{
    public partial class InputForm : Form
    {
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

        OpenFileDialog openFileDialog = new OpenFileDialog();
        readonly string videoFilter = "Video files (*.mkv, *.mp4, *.avi, *.flv, *.webm, *.mpeg, *.mpg, *.mov) | *.mkv; *.mp4; *.avi; *.flv; *.webm; *.mpeg; *.mpg; *.mov";
        

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
            var le = new LogicExecutor();
            var result = le.RunLogic(video1TextBox.Text, video2TextBox.Text, Double.Parse(startTimeTextBox.Text), Double.Parse(durationTextBox.Text));
            if (result != null)
            {
                resultTextBox.Text = string.Format("{0:0.000}", result);
                unitLabel.Visible = true;
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
    }
}
