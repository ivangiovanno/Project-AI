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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String email = emailBox.Text;
            String password = passBox.Text;
            String[] txt;
            bool OK = false;
            //Read File
            try
            {
                String[] data = System.IO.File.ReadAllLines("data.txt");
                for (int i = 0; i < data.Length; ++i)
                {
                    txt = data[i].Split('#');
                    if (txt[0].Equals(email) && txt[1].Equals(password))
                    {
                        OK = true;
                        break;
                    }
                }
                if (email.Equals("") && password.Equals(""))
                {
                    MessageBox.Show("Email or Password is empty");
                }
                else if (OK)
                {
                    menuForm mf = new menuForm();
                    mf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Email or Password is wrong");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This Application Database is not Found, Please Register First");
            }
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registerForm rf = new registerForm();
            rf.Show();
            this.Hide();
        }
    }
}
