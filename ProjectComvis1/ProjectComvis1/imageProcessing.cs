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
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;

namespace ProjectComvis
{
    public partial class imageProcessing : Form
    {
        private Image<Bgr, byte> ori, blur,gaussian,result, editan1;
        private Image<Gray, byte> gray,
            binary,binaryInverse,toZero,toZeroInv,
            canny, edit, editan2;

        private void refreshGambar()
        {
            imageList1.Images.Clear();
            //0 original
            if (pilihan == 0)
            {
                imageList1.Images.Add(ori.ToBitmap());
                pictureBox.Image = ori.ToBitmap();
            }
            else
            {
                imageList1.Images.Add(ori.ToBitmap());
            }

            //1 grayscale
            if (pilihan == 1)
            {
                gray = ori.Convert<Gray, byte>();
                imageList1.Images.Add(gray.ToBitmap());
                pictureBox.Image = gray.ToBitmap();
            }
            else
            {
                gray = ori.Convert<Gray, byte>();
                imageList1.Images.Add(gray.ToBitmap());
            }

            //2 blur
            if (pilihan == 2)
            {
                blur = ori.Clone();
                CvInvoke.cvSmooth(ori, blur, SMOOTH_TYPE.CV_BLUR, 5, 5, 0, 0);
                imageList1.Images.Add(blur.ToBitmap());
                pictureBox.Image = blur.ToBitmap();
            }
            else
            {
                blur = ori.Clone();
                CvInvoke.cvSmooth(ori, blur, SMOOTH_TYPE.CV_BLUR, 5, 5, 0, 0);
                imageList1.Images.Add(blur.ToBitmap());
            }

            //3 Gaussian
            if (pilihan == 3)
            {
                gaussian = ori.Clone();
                CvInvoke.cvSmooth(ori, gaussian, SMOOTH_TYPE.CV_GAUSSIAN, 5, 5, 0, 0);
                imageList1.Images.Add(gaussian.ToBitmap());
                pictureBox.Image = gaussian.ToBitmap();
            }
            else
            {
                gaussian = ori.Clone();
                CvInvoke.cvSmooth(ori, gaussian, SMOOTH_TYPE.CV_GAUSSIAN, 5, 5, 0, 0);
                imageList1.Images.Add(gaussian.ToBitmap());
            }

            //4 Binary
            if (pilihan == 4)
            {
                binary = gray.Clone();
                CvInvoke.cvThreshold(gray, binary, (double)nudLowThres.Value, (double)nudBrightness.Value, THRESH.CV_THRESH_BINARY);
                imageList1.Images.Add(binary.ToBitmap());
                pictureBox.Image = binary.ToBitmap();
            }
            else
            {
                binary = gray.Clone();
                CvInvoke.cvThreshold(gray, binary, (double)nudLowThres.Value, (double)nudBrightness.Value, THRESH.CV_THRESH_BINARY);
                imageList1.Images.Add(binary.ToBitmap());
            }

            //5 Binary Inverse
            if (pilihan == 5)
            {
                binaryInverse = gray.Clone();
                CvInvoke.cvThreshold(gray, binaryInverse, (double)nudLowThres.Value, (double)nudBrightness.Value, THRESH.CV_THRESH_BINARY_INV);
                imageList1.Images.Add(binaryInverse.ToBitmap());
                pictureBox.Image = binaryInverse.ToBitmap();
            }
            else
            {
                binaryInverse = gray.Clone();
                CvInvoke.cvThreshold(gray, binaryInverse, (double)nudLowThres.Value, (double)nudBrightness.Value, THRESH.CV_THRESH_BINARY_INV);
                imageList1.Images.Add(binaryInverse.ToBitmap());
            }

            //6 To Zero
            if (pilihan == 6)
            {
                toZero = gray.Clone();
                CvInvoke.cvThreshold(gray, toZero, (double)nudLowThres.Value, (double)nudBrightness.Value, THRESH.CV_THRESH_TOZERO);
                imageList1.Images.Add(toZero.ToBitmap());
                pictureBox.Image = toZero.ToBitmap();
            }
            else
            {
                toZero = gray.Clone();
                CvInvoke.cvThreshold(gray, toZero, (double)nudLowThres.Value, (double)nudBrightness.Value, THRESH.CV_THRESH_TOZERO);
                imageList1.Images.Add(toZero.ToBitmap());
            }

            //7 To Zero Inverse
            if (pilihan == 7)
            {
                toZeroInv = gray.Clone();
                CvInvoke.cvThreshold(gray, toZeroInv, (double)nudLowThres.Value, (double)nudBrightness.Value, THRESH.CV_THRESH_TOZERO_INV);
                imageList1.Images.Add(toZeroInv.ToBitmap());
                pictureBox.Image = toZeroInv.ToBitmap();
            }
            else
            {
                toZeroInv = gray.Clone();
                CvInvoke.cvThreshold(gray, toZeroInv, (double)nudLowThres.Value, (double)nudBrightness.Value, THRESH.CV_THRESH_TOZERO_INV);
                imageList1.Images.Add(toZeroInv.ToBitmap());
            }

            //8 Canny
            if (pilihan == 8)
            {
                canny = gray.Clone();
                nudAperture.Value = 3;
                CvInvoke.cvCanny(canny, canny, 1, 1, 3);
                imageList1.Images.Add(canny.ToBitmap());
                pictureBox.Image = canny.ToBitmap();
            }
            else
            {
                canny = gray.Clone();
                nudAperture.Value = 3;
                CvInvoke.cvCanny(canny, canny, 1, 1, 3);
                imageList1.Images.Add(canny.ToBitmap());
            }

            //9 Sobel
            if (pilihan == 9)
            {
                sobel = gray.Convert<Gray, float>();
                sobel = gray.Sobel(1, 1, (int)nudAperture.Value);
                imageList1.Images.Add(sobel.ToBitmap());
                pictureBox.Image = sobel.ToBitmap();
            }
            else
            {
                sobel = gray.Convert<Gray, float>();
                sobel = gray.Sobel(1, 1, (int)nudAperture.Value);
                imageList1.Images.Add(sobel.ToBitmap());
            }

            //10 Laplace
            if (pilihan == 10)
            {
                laplace = gray.Convert<Gray, float>();
                laplace = gray.Laplace((int)nudAperture.Value);
                imageList1.Images.Add(laplace.ToBitmap());
                pictureBox.Image = laplace.ToBitmap();
            }
            else
            {
                laplace = gray.Convert<Gray, float>();
                laplace = gray.Laplace((int)nudAperture.Value);
                imageList1.Images.Add(laplace.ToBitmap());
            }

            listView1.Items[0].ImageIndex = 0;
            listView1.Items[1].ImageIndex = 1;
            listView1.Items[2].ImageIndex = 2;
            listView1.Items[3].ImageIndex = 3;
            listView1.Items[4].ImageIndex = 4;
            listView1.Items[5].ImageIndex = 5;
            listView1.Items[6].ImageIndex = 6;
            listView1.Items[7].ImageIndex = 7;
            listView1.Items[8].ImageIndex = 8;
            listView1.Items[9].ImageIndex = 9;
            listView1.Items[10].ImageIndex = 10;
           
        }

        private void nudBrightness_ValueChanged(object sender, EventArgs e)
        {
            refreshGambar();
        }

        private void nudLowThres_ValueChanged(object sender, EventArgs e)
        {
            refreshGambar();
        }

        private void nudAperture_ValueChanged(object sender, EventArgs e)
        {
            refreshGambar();
        }

        int pilihan = 0;
        private Image<Gray, float> sobel, laplace, editan3;
        bool rbLChecked, rbRChecked, rbCChecked;

        public imageProcessing(Image<Bgr, byte> img)
        {
            InitializeComponent();
            ori = img.Clone();

            // disable all
            groupBox1.Enabled = false;
            nudLowThres.ReadOnly = true;
            nudBrightness.ReadOnly = true;
            nudAperture.ReadOnly = true;

            rbLine.Checked = false;
            rbRectangle.Checked = false;
            rbCircle.Checked = false;
            rbLChecked = rbRChecked = rbCChecked = false;

            pictureBox.Image = ori.ToBitmap();

            refreshGambar();
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbLine.Checked = false;
            rbRectangle.Checked = false;
            rbCircle.Checked = false;

            if (listView1.Items[0].Selected)
            {
                pictureBox.Image = ori.ToBitmap();
                pilihan = 0;
            }
            else if (listView1.Items[1].Selected)
            {
                pictureBox.Image = gray.ToBitmap();
                pilihan = 1;
            }
            else if (listView1.Items[2].Selected)
            {
                pictureBox.Image = blur.ToBitmap();
                pilihan = 2;
            }
            else if (listView1.Items[3].Selected)
            {
                pictureBox.Image = gaussian.ToBitmap();
                pilihan = 3;
            }
            else if (listView1.Items[4].Selected)
            {
                pictureBox.Image = binary.ToBitmap();
                groupBox1.Enabled = true;
                nudAperture.Enabled = false;
                nudLowThres.Enabled = true;
                nudBrightness.Enabled = true;
                pilihan = 4;
            }
            else if (listView1.Items[5].Selected)
            {
                pictureBox.Image = binaryInverse.ToBitmap();
                groupBox1.Enabled = true;
                nudAperture.Enabled = false;
                nudLowThres.Enabled = true;
                nudBrightness.Enabled = true;
                pilihan = 5;
            }
            else if (listView1.Items[6].Selected)
            {
                pictureBox.Image = toZero.ToBitmap();
                groupBox1.Enabled = true;
                nudAperture.Enabled = false;
                nudLowThres.Enabled = true;
                nudBrightness.Enabled = true;
                pilihan = 6;
            }
            else if (listView1.Items[7].Selected)
            {
                pictureBox.Image = toZeroInv.ToBitmap();
                groupBox1.Enabled = true;
                nudAperture.Enabled = false;
                nudLowThres.Enabled = true;
                nudBrightness.Enabled = true;
                pilihan = 7;
            }
            else if (listView1.Items[8].Selected)//Canny
            {
                nudAperture.Minimum = 3;
                groupBox1.Enabled = true;
                nudLowThres.Enabled = false;
                nudBrightness.Enabled = false;
                nudAperture.Enabled = true;
                CvInvoke.cvCanny(gray, canny, 1, 1, (int)nudAperture.Value);
                pictureBox.Image = canny.ToBitmap();
                pilihan = 8;
            }
            else if (listView1.Items[9].Selected)//Sobel
            {
                nudLowThres.Enabled = false;
                nudBrightness.Enabled = false;
                nudAperture.Enabled = true;
                pictureBox.Image = sobel.ToBitmap();
                pilihan = 9;
            }
            else if (listView1.Items[10].Selected)//Laplace
            {
                nudLowThres.Enabled = false;
                nudBrightness.Enabled = false;
                nudAperture.Enabled = true;
                pictureBox.Image = laplace.ToBitmap();
                pilihan = 10;
            }
        }
        
        private void rbLine_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbLChecked)
            {
                edit = ori.Convert<Gray, byte>();
                CvInvoke.cvCanny(edit, edit, 150, 60, 3);
                result = ori.Clone();

                foreach (LineSegment2D line in edit.HoughLines(new Gray(125), new Gray(125), 2, Math.Abs(Math.PI / 20), 2, 3, 2)[0])
                {
                    result.Draw(line, new Bgr(Color.Green), 3);
                }
                rbLChecked = true;
                rbRChecked = false;
                rbCChecked = false;
                pictureBox.Image = result.ToBitmap();
            }
        }

        private void rbRectangle_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbRChecked)
            {
                CvInvoke.cvCvtColor(ori, edit, COLOR_CONVERSION.CV_BGR2GRAY);
                CvInvoke.cvCanny(edit, edit, 150, 60, 3);
                result = ori.Clone();

                List<MCvBox2D> box = new List<MCvBox2D>();
                for (Contour<Point> con = edit.FindContours(); con != null; con = con.HNext)
                {
                    Contour<Point> conPoint = con.ApproxPoly(con.Perimeter * 0.16);
                    if (conPoint.Total == 4)
                    {
                        bool Rect = true;
                        Point[] pts = conPoint.ToArray();
                        LineSegment2D[] line = PointCollection.PolyLine(pts, true);
                        for (int i = 0; i < line.Length; i++)
                        {
                            double angle = Math.Abs(line[(i + 1) % line.Length].GetExteriorAngleDegree(line[i]));
                            if (angle < 80 || angle > 100)
                            {
                                Rect = false;
                                break;
                            }
                        }

                        if (Rect) box.Add(conPoint.GetMinAreaRect());

                        foreach (MCvBox2D boxs in box)
                        {
                            result.Draw(boxs, new Bgr(Color.Blue), 5);
                        }
                    }
                }

                rbRChecked = true;
                rbLChecked = false;
                rbCChecked = false;
                pictureBox.Image = result.ToBitmap();
            }
        }

        private void rbCircle_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbCChecked)
            {
                edit = ori.Convert<Gray, byte>();
                CvInvoke.cvCanny(edit, edit, 150, 60, 3);
                result = ori.Clone();

                foreach (CircleF circle in edit.HoughCircles(new Gray(125), new Gray(125), 4, 4, 35, 80)[0])
                {
                    result.Draw(circle, new Bgr(Color.Blue), 3);
                }
                rbCChecked = true;
                rbLChecked = false;
                rbRChecked = false;
                pictureBox.Image = result.ToBitmap();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Images Files|*.jpg";
            saveFileDialog1.DefaultExt = "jpg";
            DialogResult save = saveFileDialog1.ShowDialog();
            if (save == DialogResult.OK)
            {
                pictureBox.Image.Save(saveFileDialog1.FileName.ToString());

            }
        }
    }
}
