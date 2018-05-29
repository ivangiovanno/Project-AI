using Accord.Imaging.Converters;
using Accord.Neuro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectLab_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
         
            if (Data.instance.bpnnNetwork == null)
            {
                btnPredict.Enabled = false;
            }
            Data.instance.checkData();
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
           if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.Image = Data.instance.preProcess(new Bitmap(pictureBox1.ImageLocation));

                double[] input_data;

                int max_output = Data.instance.classes.Count - 1, min_output = 0;
                Bitmap image = new Bitmap(pictureBox1.Image);
                ImageToArray converter = new ImageToArray(0, 1);
                converter.Convert(image, out input_data);

                double[] output = Data.instance.bpnnNetwork.Compute(input_data);

                int result = Convert.ToInt32(min_output + Math.Round(output[0] - 0) * (max_output - min_output) / (1 - 0));

                MessageBox.Show(output[0] + " has result " + result);
                textBox1.Text = Data.instance.classes[result];
                MessageBox.Show("Prediction Complete");
            }
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            if(Data.instance.images.Count == 0)
            {
                MessageBox.Show("No picture to learn!!");
            }

            if (!File.Exists("an.bin"))
            {
                Data.instance.bpnnTraining();
                MessageBox.Show("Computing BPNN finished");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Are you sure to re-train the classsification network?","Confirmation",MessageBoxButtons.YesNo);
                if(confirm == DialogResult.Yes)
                {
                    Data.instance.bpnnTraining();
                    MessageBox.Show("Computing BPNN finished");
                }
                else
                {
                    Data.instance.bpnnNetwork = (ActivationNetwork)ActivationNetwork.Load("an.bin");
                }

            }
            btnPredict.Enabled = true;
        }
    }
}
