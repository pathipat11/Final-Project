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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            displayCust();
        }
        CustomersTbl Con = new CustomersTbl();
        private void Reset()
        {
            CNameTb.Text = "";
            CAddTb.Text = "";
            CCarTb.Text = "";
            CPhoneTb.Text = "";
            CStatusCb.SelectedIndex = -1;
        }
        private displayCust()
        {
            Con.Open();
            string Query = "Select * from CustomersTbl";

            Con.Close();
        }

        

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAddTb.Text == "" || CStatusCb.SelectedIndex == -1 || EPhoneTb.Text == "" || CCarTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    EmployeesTbl cmd = new EmployeesTbl("insert into CustomersTbl(CName,Cphone,CAdd,CStatus,CCar) values(@Cn,@Cp,@Ca,@Cs,@Cc)", Con);
                    cmd.Parameters.AddWithValue("@Cn", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@Cp", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Ca", CAddTb.Text);
                    cmd.Parameters.AddWithValue("@Cs", CStatusCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Cc", CCarTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Saved");

                    Con.Close();
                    displayCust();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        
        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CPhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CAddTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
            CStatusCb.SelectedItem = CustomerDGV.SelectedRows[0].Cells[4].Value.ToString();
            CCarTb.Text = CustomerDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (ENameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        int Key = 0;
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Customer");
            }
            else
            {
                Con.Open();
                EmployeesTbl cmd = new EmployeesTbl("delete from CustomersTbl where CId=@CuId", Con);
                cmd.Parameters.AddWithValue("@CuId", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Deleted");
                Con.Close();
                displayCust();
                Reset();
            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAddTb.Text == "" || CStatusCb.SelectedIndex == -1 || EPhoneTb.Text == "" || CCarTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                EmployeesTbl cmd = new EmployeesTbl("Update CustomersTbl set CName=@Cun,CPhone=@Cup,CAdd=@Cua,CStatus=@Cus,CCar=@Cuc where CId=@CuId", Con);
                cmd.Parameters.AddWithValue("@Cun", CNameTb.Text);
                cmd.Parameters.AddWithValue("@Cup", CPhoneTb.Text);
                cmd.Parameters.AddWithValue("@Cua", CAddTb.Text);
                cmd.Parameters.AddWithValue("@Cus", CStatusCb.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Cuc", CCarTb.Text);
                cmd.Parameters.AddWithValue("@CuId", Key);
                cmd.ExcuteNonQuery();
                MessageBox.Show("Customer Updated");

                Con.Close();
                displayCust();
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

        private void label2_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
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
