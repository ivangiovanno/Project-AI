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
    public partial class Video : Form
    {
        //OpenFileDialog ofd;
        Capture capture;
        Image<Bgr, byte> original,edit;
        Image<Gray, byte> gray;
        HaarCascade faceCascade, noseCascade, eyeCascade;
        String file;

        public Video(String fileName)
        {
            InitializeComponent();
            file = fileName;
            faceCascade = new HaarCascade("haarcascade_frontalface_default.xml");
            noseCascade = new HaarCascade("haarcascade_mcs_nose.xml");
            eyeCascade = new HaarCascade("haarcascade_eye.xml");
        }

        private void Video_Load(object sender, EventArgs e)
        {
            capture = new Capture(file);
            timer1.Start();
            timer1.Interval = 1000 / 60;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            original = capture.QueryFrame();

            gray = original.Convert<Gray, byte>();
            
            if (cbFace.Checked)
            {
                foreach (MCvAvgComp item in faceCascade.Detect(gray))
                {
                    original.Draw(item.rect, new Bgr(Color.Lime), 5);
                }
            }

            if (cbNose.Checked)
            {
                CvInvoke.cvCvtColor(edit, gray, COLOR_CONVERSION.CV_BGR2GRAY);
                var faces = noseCascade.Detect(gray);

                foreach (var face in faces)
                {
                    edit.Draw(face.rect, new Bgr(Color.Red), 5);
                }
            }

            if (cbEyes.Checked)
            {
                foreach (MCvAvgComp item in eyeCascade.Detect(gray))
                {
                    original.Draw(item.rect, new Bgr(Color.White), 5);
                }
            }

            pictureBox.Image = original.Bitmap;
        }

    }
}
