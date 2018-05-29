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
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace ProjectComvis
{
    public partial class menuForm : Form
    {
        OpenFileDialog ofd;
        Capture capture;
        Image<Bgr, byte> image;
        Image<Bgr, byte> poto;

        public menuForm()
        {
            InitializeComponent();
            ofd = new OpenFileDialog();
        }

        private void browseImage_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image Files | *.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image = new Image<Bgr, byte>(ofd.FileName);
                imageProcessing imgProc = new imageProcessing(image);
                imgProc.Show();
                this.Hide();
            }
        }

        private void captureImage_Click(object sender, EventArgs e)
        {
            capturePoto c = new capturePoto();
            c.Show();
            this.Hide();
        }

        private void browseVideo_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Video File | *.wmv;*.mp4";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //capture = new Capture(ofd.FileName);
                String fileName = ofd.FileName;
                Video v = new Video(fileName);
                v.Show();
                Hide();
            }
        }

        private void signOut_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            login.Show();
            Close();
        }
    }
}
