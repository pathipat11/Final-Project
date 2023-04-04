using Final_Project.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Final_Project
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            displayEmp();
        }
        EmployeesTbl Con = new EmployeesTbl();
        private void Reset()
        {
            ENameTb.Text = "";
            EAddTb.Text = "";
            EPhoneTb.Text = "";
            EGenCb.SelectedIndex = -1;
        }
        private displayEmp()
        {
            Con.Open();
            string Query = "Select * from EmployeeTbl";

            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ENameTb.Text == "" || EAddTb.Text == "" || EGenCb.SelectedIndex == -1 || EPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }else
            {
                try
                {
                    Con.Open();
                    EmployeesTbl cmd = new EmployeesTbl("insert into EmployeesTbl(EName,Ephone,EGen,EAdd) values(@En,@Ep,@Eg,@a)", Con);
                    cmd.Parameters.AddWithValue("@En", ENameTb.Text);
                    cmd.Parameters.AddWithValue("@Ep", EPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Eg", EGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Ea", EAddTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Eployee Saved");

                    Con.Close();
                    displayEmp();
                    Reset();
                }catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void EmployeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ENameTb.Text = EmployeesDGV.SelectedRows[0].Cells[1].Value.ToString();
            EPhoneTb.Text = EmployeesDGV.SelectedRows[0].Cells[2].Value.ToString();
            EGenCb.SelectedItem = EmployeesDGV.SelectedRows[0].Cells[3].Value.ToString();
            EAddTb.Text = EmployeesDGV.SelectedRows[0].Cells[4].Value.ToString();
            if(ENameTb.Text == "")
            {
                Key = 0;
            }else
            {
                Key = Convert.ToInt32(EmployeesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if(Key == 0)
            {
                MessageBox.Show("Select TheEmployee");
            }else
            {
                Con.Open();
                EmployeesTbl cmd = new EmployeesTbl("delete from EmployeeTbl where EId=@EmId", Con);
                cmd.Parameters.AddWithValue("@EmId", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Deleted");
                Con.Close();
                displayEmp();
                Reset();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ENameTb.Text == "" || EAddTb.Text == "" || EGenCb.SelectedIndex == -1 || EPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }else
            {
                Con.Open();
                EmployeesTbl cmd = new EmployeesTbl("Update EmployeeTbl set EName=@En,EPhone=@Ep,EGen=@g,EAdd=@Ea where EId=@EmId", Con);
                cmd.Parameters.AddWithValue("@En",ENameTb.Text);
                cmd.Parameters.AddWithValue("@Ep", EPhoneTb.Text);
                cmd.Parameters.AddWithValue("@Eg", EGenCb.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Ea", EAddTb.Text);
                cmd.Parameters.AddWithValue("@EmId", Key);
                cmd.ExcuteNonQuery();
                MessageBox.Show("Employee Updated");
                
                Con.Close();
                displayEmp();
                Reset();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Logins obj = new Logins();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Services obj = new Services();
            obj.Show();
            this.Hide();
        }

    }
}
