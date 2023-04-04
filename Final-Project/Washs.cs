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
    public partial class Washs : Form
    {
        public Washs()
        {
            InitializeComponent();
            FillCust();
            FillServices();
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
        CustomersTbl cmd = new CustomersTbl();
        private void FillCust()
        {
            Con.Open();
            CustomersTbl cmd = new CustomersTbl("select CName from CustomerTbl", Con);
            Con.Close();
        }
        private void FillServices()
        {
            Con.Open();
            ServicesTbl cmd = new ServicesTbl("select SName from ServicesTbl", Con);
            Con.Close();
        }
        private void GetCustData()
        {
            Con.Open();
            string query = "select * from CustomersTbl where CName='" + CustNameCb.SelectedValue.ToString() + "'";
            CustomersTbl cmd = new CustomersTbl(query, Con);
            DataTable dt = new DataTable();
            ///////////////
            DataTable.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CustPhoneTb.Text = dr["Cphone"].ToString();
            }
                
            Con.Close();
        }
        private void GetServiceData()
        {
            Con.Open();
            string query = "select * from ServicesTbl where SName='" + ServiceCb.SelectedValue.ToString() + "'";
            CustomersTbl cmd = new CustomersTbl(query, Con);
            DataTable dt = new DataTable();
            ///////////////
            DataTable.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PriceTb.Text = dr["Spreice"].ToString();
            }

            Con.Close();
        }
        int n = 0, Grdtotal = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PriceTb.Text == "")
            {
                MessageBox.Show("Select a Service");
            }else
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ServiceDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ServiceCb.SelectedValue.ToString();
                newRow.Cells[2].Value = PriceTb.Text;
                ServiceDGV.Rows.Add(newRow);
                n++;
                Grdtotal = Grdtotal + Convert.ToInt32(PriceTb.Text);
                // TotalLbl.Text = "Rs" + Grdtotal;
            }
        }

        private void CustNameCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustData();
        }

        private void ServiceCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetServiceData();
        }
    }
}
