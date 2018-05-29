using Accord.Imaging.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectLab_1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Data.instance.somTraining();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (Data.instance.images.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No image for SOM Training...");
                return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.Image = Data.instance.preProcess(new Bitmap(pictureBox1.ImageLocation));

                // Main Process
                listView1.Items.Clear();
                imageList1.Images.Clear();
                double[] input_data = new double[10*10];

                Bitmap image = new Bitmap(pictureBox1.Image);
                image = Data.instance.preProcess(image);

                ImageToArray converter = new ImageToArray(0, 1);
                converter.Convert(image, out input_data);

                double[] input_pca = Data.instance.pca.Transform(input_data);
                Data.instance.som_network.Compute(input_pca);

                int winner = Data.instance.som_network.GetWinner();

                for (int i = 0; i < Data.instance.images.Count; i++)
                {
                    double[] input_data2 = new double[10 * 10];

                    Bitmap image2 = new Bitmap(Data.instance.images[i]);
                    image2 = Data.instance.preProcess(image2);

                    ImageToArray converter2 = new ImageToArray(0, 1);
                    converter2.Convert(image2, out input_data2);

                    double[] input_pca2 = Data.instance.pca.Transform(input_data2);

                    Data.instance.som_network.Compute(input_pca2);
                    int winner2 = Data.instance.som_network.GetWinner();

                    //bool isSame = false;

                    if (winner == winner2)
                    {
                        Bitmap showImage = Data.instance.images[i];

                        imageList1.Images.Add(showImage);
                        listView1.Items.Add("",imageList1.Images.Count-1);
                    }
                }

                MessageBox.Show("Find Similar Item Finished!");
            }
        }
    }
}
