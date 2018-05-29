using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ProjectComvis
{
    public partial class capturePoto : Form
    {
        Capture capture;
        Image<Bgr, byte> poto;
        Image<Bgr, byte> gambar;
        public capturePoto()
        {
            InitializeComponent();
            capture = new Capture();
            timer1.Start();
            timer1.Interval = 1000 / 60;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            poto = capture.QueryFrame();

            pictureBox.Image = poto.Bitmap;
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            gambar = poto.Clone();
            imageProcessing b = new imageProcessing(gambar);
            this.Close();
            b.Show();
        }
    }
}
