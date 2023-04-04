using Final_Project.Tables;
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
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
            displayServices();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Logins obj = new Logins();
            obj.Show();
            this.Hide();
        }
        ServicesTbl Con = new ServicesTbl();
        private void Reset()
        {
            SNameTb.Text = "";
            PriceTb.Text = "";

        }
        private displayServices()
        {
            Con.Open();
            string Query = "Select * from ServicesTbl";

            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    EmployeesTbl cmd = new EmployeesTbl("insert into ServicesTbl(SName,Sprice) values(@SN,@SP)", Con);
                    cmd.Parameters.AddWithValue("@SN", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@SP", PriceTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Service Recorded");

                    Con.Close();
                    displayServices();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void ServiceDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SNameTb.Text = ServiceDGV.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = ServiceDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (SNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ServiceDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Service");
            }
            else
            {
                Con.Open();
                EmployeesTbl cmd = new ServiceDGV("delete from EmployeeTbl where SId=@SeId", Con);
                cmd.Parameters.AddWithValue("@SeId", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Service Deleted");
                Con.Close();
                displayServices();
                Reset();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || PriceTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                EmployeesTbl cmd = new EmployeesTbl("Update EmployeeTbl set SName=@Sen,Sprice=@Sep here SId=@SeId", Con);
                cmd.Parameters.AddWithValue("@Sen", SNameTb.Text);
                cmd.Parameters.AddWithValue("@Sep", PriceTb.Text);
                cmd.Parameters.AddWithValue("@EmId", Key);
                cmd.ExcuteNonQuery();
                MessageBox.Show("Service Updated");

                Con.Close();
                displayServices();
                Reset();
            }
        }
    }
}
