using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectComvis
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            loginForm lf = new loginForm();
            lf.Show();
            this.Hide();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            String email = "";
            if (!emailBox.Text.Equals(""))
            {
                if (emailBox.Text.Contains('@') && emailBox.Text.Contains('.'))
                {
                    if (emailBox.Text.IndexOf('@') + 1 < emailBox.Text.IndexOf('.'))
                    {
                        email = emailBox.Text;
                    }
                }
            }
            String password = "";
            if (!passBox.Text.Equals(""))
            {
                bool cek1 = false;
                bool cek2 = false;
                for (int i = 0; i < passBox.Text.Length; i++)
                {
                    if (Char.IsNumber(passBox.Text.ElementAt(i)))
                    {
                        cek1 = true;
                        break; 
                    }
                    cek1 = false;
                }
                for (int i = 0; i < passBox.Text.Length; i++)
                {
                    if (Char.IsLetter(passBox.Text.ElementAt(i)))
                    {
                        cek2 = true;
                        break;
                    }
                    cek2 = false;
                }
                if (cek1 == true && cek2 == true)
                {
                    password = passBox.Text;
                }
            }
            String cPassword = cPassBox.Text;
            if (!password.Equals(cPassword))
            {
                password = "";
            }
            String gender = "";
            if (maleRb.Checked)
            {
                gender = "Male";
            }
            else gender = "Female";
            String birthdate = "";
            if (2017 - dateBox.Value.Year >= 16)
            {
                birthdate = dateBox.Text;
            }
            bool agree = false;
            if (agreeCk.Checked)
            {
                agree = true;
            }
            if (email.Equals("") || password.Equals("") || gender.Equals("") || birthdate.Equals("") || agree == false)
            {
                MessageBox.Show("Wrong Format");
            }
            else
            {
                //Write File
                String data;
                System.IO.StreamWriter file = new System.IO.StreamWriter("data.txt",true);
                data = email+"#"+password+"\n";
                file.WriteLine(data);

                file.Close();

                MessageBox.Show("Sign Up Success");
                this.Hide();
                loginForm lf = new loginForm();
                lf.Show();
            }
        }
    }
}
