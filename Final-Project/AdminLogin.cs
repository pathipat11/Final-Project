using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Logins obj = new Logins();
            obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AdminPassTb.Text == "")
            {
                MessageBox.Show("Enter Password");
            }else if(AdminPassTb.Text == "Password")
            {
                Employees obj = new Employees();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Password");
            }
        }
    }
}
