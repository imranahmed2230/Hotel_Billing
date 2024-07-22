using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBillingSystemADO
{
    public partial class Sales_Billing : Form
    {
        public Sales_Billing()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection (@"Data Source=(localdb)\v11.0;Initial Catalog=HotelDB;Integrated Security=True");


        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string price = "SELECT Fprice FROM tblFood WHERE Fname =@Fname";
            SqlCommand cmd = new SqlCommand(price, con);
            cmd.Parameters.AddWithValue("@Fname", comboBox1.Text);
            con.Open();
            SqlDataReader s = cmd.ExecuteReader();
            while (s.Read())
            {
                string pri = s["Fprice"].ToString();
                textBox2.Text = pri;
            }
            con.Close();
        }
    }
}
