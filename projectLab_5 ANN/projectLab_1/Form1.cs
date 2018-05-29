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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Fill the classes fixed position based on combobox
            foreach (String item in comboBox1.Items)
            {
                Data.instance.classes.Add(item);
            }

            //	Try to locate and load the activation network from file “an.bin”
            if (File.Exists("an.bin"))
            {
                Data.instance.bpnnNetwork = (ActivationNetwork)ActivationNetwork.Load("an.bin");
                if (Directory.Exists(Environment.CurrentDirectory + @"\assets"))
                {
                    String[] categories = Directory.GetDirectories("assets");

                    foreach (var item in categories)
                    {
                        String category = new DirectoryInfo(item).Name;

                        //Data.instance.classes.Add(category);

                        String[] images = Directory.GetFiles(@"assets\" + category);

                        foreach (var item2 in images)
                        {
                            Bitmap img = new Bitmap(item2);

                            Data.instance.images.Add(img);
                            Data.instance.indexClasses.Add(Data.instance.classes.IndexOf(category));
                        }
                    }
                }
                MessageBox.Show("an.net success to be loaded");
            }
            else
            {
                MessageBox.Show("There's no \"an.net\" exist");
            }
            //	The images’ extension must be either “jpg”, “jpeg”, or “png”.
            openFileDialog1.Filter = "Image |*.jpg;*.png;*.jpeg";
            comboBox1.SelectedIndex = 0;
        }

        List<String> tempFileName = new List<string>();
        //List<Bitmap> tempUploadedImage = new List<Bitmap>();

        //o	If the user clicks Browse Button, then the application will show Open File Dialog 
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //	User can select multiple images.
            openFileDialog1.Multiselect = true;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //	If the user confirms to open image, then Selected 
                //Image List View will show the selected images.
                foreach (var path in openFileDialog1.FileNames)
                {
                    String fileName = Path.GetFileName(path);
                    Bitmap image = new Bitmap(path);
                    imageSelected.Images.Add(image);

                    listView2.Items.Add(/*fileName*/"", imageSelected.Images.Count - 1);
                    tempFileName.Add(fileName);
                    //tempUploadedImage.Add(image);
                }
            }

        }

       public void fillData()
        {
            for (int i = 0; i < imageUpload.Images.Count; i++)
            {
                Data.instance.images.Add(new Bitmap(imageUpload.Images[i]));
                Data.instance.indexClasses.Add(Data.instance.classes.IndexOf(listView1.Items[i].Group.Header));
            }
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            //o If the user clicks Classify Items Button, then the application will show Classify Item Form
            fillData();
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //o	If the user clicks Search Similar Image Button, then the application will 
            //show Search Similar Image Form. 
            fillData();
            Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count > 0)
            {
                listView2.Clear();
                imageSelected.Images.Clear();
                imageUpload.Images.Clear();
                tempFileName.Clear();
                //tempUploadedImage.Clear();
            }
            else
            {
                MessageBox.Show("Select Data First");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (imageSelected.Images.Count == 0)
            {
                MessageBox.Show("No picture to upload!");
                return;
            }

            for (int i = 0; i < imageSelected.Images.Count; i++)
            {
                if (!Directory.Exists(Environment.CurrentDirectory + @"\assets\" + comboBox1.Text))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\assets\" + comboBox1.Text);
                }
                if (!File.Exists(Environment.CurrentDirectory + @"\assets\" + comboBox1.Text + @"\" + tempFileName[i]))
                {
                    imageSelected.Images[i].Save(Environment.CurrentDirectory + @"\assets\" + comboBox1.Text + @"\" + tempFileName[i]);
                }

                ListViewGroup listViewGroup = null;
                foreach (ListViewGroup lvg in listView1.Groups)
                {
                    if (lvg.Header == comboBox1.Text)
                    {
                        listViewGroup = lvg;
                        break;
                    }
                }

                if (listViewGroup == null)
                {
                    listViewGroup = new ListViewGroup(comboBox1.Text);
                    listView1.Groups.Add(listViewGroup);
                }

                imageUpload.Images.Add(imageSelected.Images[i]);

                ListViewItem listViewItem = new ListViewItem(/*tempFileName[i]*/"", imageUpload.Images.Count - 1, listViewGroup);
                listView1.Items.Add(listViewItem);
            }
            //tempUploadedImage.Clear();
            imageSelected.Images.Clear();
            listView2.Clear();
        }
    }
}
