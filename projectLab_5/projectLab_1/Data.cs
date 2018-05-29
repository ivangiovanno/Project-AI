using Accord.Imaging.Converters;
using Accord.Imaging.Filters;
using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Statistics.Analysis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLab_1
{
    class Data
    {
        public static Data instance = new Data();
        public List<Bitmap> images = new List<Bitmap>();
        public List<String> classes = new List<string>();
        public List<int> indexClasses = new List<int>();       

        public Bitmap preProcess(Bitmap image)
        {
            //The input image will be applied with preprocessing(grayscale, threshold, and reduce noise)
         
            image = Grayscale.CommonAlgorithms.RMY.Apply(image);
            
            image = new Threshold(127).Apply(image);
            int xStart = image.Width, yStart = image.Height, xEnd = 0, yEnd = 0;

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    if (image.GetPixel(j, i).R > 127)
                    {
                        if (xStart > j) xStart = j;
                        if (yStart > i) yStart = i;
                        if (xEnd < j) xEnd = j;
                        if (yEnd < i) yEnd = i;
                    }
                }
            }

            image = image.Clone(new Rectangle(xStart, yStart, xEnd - xStart, yEnd - yStart), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //and will be resized it to 10x10 pixels
            image = new ResizeBilinear(10, 10).Apply(image);

            return image;
            //  Total input neurons in neural network must be 100 neurons
        }


        //o Method: Backpropagation
        public ActivationNetwork bpnnNetwork;
        public BackPropagationLearning bpnnLearning;
        public void bpnnTraining()
        {
            double[][] input_data = new double[Data.instance.images.Count][];
            double[][] output_data = new double[Data.instance.indexClasses.Count][];
            int max_output = Data.instance.classes.Count - 1, min_output = 0;

            for (int i = 0; i < Data.instance.images.Count; i++)
            {
                //Pilih gambar berwarna
                Bitmap image = new Bitmap(Data.instance.images[i]);
                //Preprocess jadi 10 x 10 hitam putih
                image = Data.instance.preProcess(image);
                // dari pixel 0-255 jadi 0-1
                ImageToArray converter = new ImageToArray(0, 1);
                converter.Convert(image, out input_data[i]);

                output_data[i] = new double[1];
                output_data[i][0] = Data.instance.indexClasses[i];
                output_data[i][0] = 0 + (output_data[i][0] - min_output) * (1 - 0) / (max_output - min_output);
            }

            bpnnNetwork = new ActivationNetwork(new SigmoidFunction(), 100, 3, 1);
            bpnnLearning = new BackPropagationLearning(bpnnNetwork);
            
            //o   Error Goals: 0.000001
            //o   Max Epochs: 1000000

            int max_iter = 1000000;
            double max_error = 0.000001;

            for (int i = 0; i < max_iter; i++)
            {
                double error = bpnnLearning.RunEpoch(input_data, output_data);

                if (error < max_error) break;
            }

            bpnnNetwork.Save("an.bin");
        }

        //o Method: Kohonen Self-Organizing Map(SOM)
    
        public DistanceNetwork som_network;
        public SOMLearning som_learning;
        public PrincipalComponentAnalysis pca;

        public void somTraining()
        {
            double[][] input_data = new double[Data.instance.images.Count][];
            for (int i = 0; i < images.Count; i++)
            {
                Bitmap image = new Bitmap(images[i]);
                image = preProcess(image);
                ImageToArray converter = new ImageToArray(0, 1);
                converter.Convert(image, out input_data[i]);
            }

            pca = new PrincipalComponentAnalysis(PrincipalComponentMethod.Center);

            pca.Learn(input_data);
            double[][] input_pca = pca.Transform(input_data);
            //o Clusters(Groups) Count: 4
            
            som_network = new DistanceNetwork(input_pca[0].Count(), 4);
            som_learning = new SOMLearning(som_network);
            //o Error Goals: 0.001
            //o Max Epochs: 100000
            int maxIter = 100000;
            double maxError = 0.001;

            for (int i = 0; i < maxIter; i++)
            {
                double error = som_learning.RunEpoch(input_pca);
                if (error < maxError)
                {
                    break;
                }
            }

            System.Windows.Forms.MessageBox.Show("SOM Training Complete");
        }

        public void checkData()
        {
            Console.WriteLine("Classes:"+classes.Count);
            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine(classes[i]);
            }
            Console.WriteLine("Image:"+images.Count);
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine(images[i]);
            }
            Console.WriteLine("IndexClasses:"+indexClasses.Count);
            for (int i = 0; i < indexClasses.Count; i++)
            {
                Console.WriteLine(indexClasses[i]);
            }
            Console.WriteLine("All:");
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine(images[i]+" = "+classes[indexClasses[i]]);
            }
        }
    }
}
