using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoCrossCorrelation.Logic;

namespace VideoCrossCorrelation
{
    public partial class Form1 : Form
    {
        public Form1()
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
        string videoFilter = "Video files (*.mkv, *.mp4, *.avi, *.flv, *.webm, *.mpeg, *.mpg, *.mov) | *.mkv; *.mp4; *.avi; *.flv; *.webm; *.mpeg; *.mpg; *.mov";
        

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = videoFilter;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
                updateButton3State();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = videoFilter;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog.FileName;
                updateButton3State();
            }
        }

        private void updateButton3State()
        {
            button3.Enabled = !string.IsNullOrEmpty(this.textBox1.Text) && !string.IsNullOrEmpty(this.textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogicExecutor le = new LogicExecutor();
            double? result = le.RunLogic(this.textBox1.Text, this.textBox2.Text, 0, 60);
            if (result != null)
            {
                textBox3.Text = result.ToString();
            }
        }
    }
}
