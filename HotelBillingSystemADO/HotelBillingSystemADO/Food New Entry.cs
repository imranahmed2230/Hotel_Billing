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
    public partial class Food_New_Entry : Form
    {
        public Food_New_Entry()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=HotelDB;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string ftype = radioButton1.Checked ? "Veg" : "Non Veg";
            string q = "INSERT INTO tblFood (Fname,Ftype,Fprice,Favailable) VALUES('" + textBox1.Text + "','" + ftype
          + "'," + textBox2.Text + ",'" + comboBox1.Text + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            MessageBox.Show((res > 0) ? "Data Inserted" : "Data Not Inserted");
            con.Close();

            {
                string view = "select * from tblFood";
                SqlCommand v = new SqlCommand(view, con);
                SqlDataAdapter sda = new SqlDataAdapter(v);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "table";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string view = "select * from tblFood";
            SqlCommand cmd = new SqlCommand(view, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "table";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ftype = radioButton1.Checked ? "Veg" : "Non Veg";
            string update = "UPDATE tblFood SET Favailable='" + comboBox1.Text + "', Fprice=" + textBox2.Text + ", Ftype='" + ftype + "' WHERE Fname='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(update, con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            MessageBox.Show((res > 0) ? "Updated " : "Not Updated");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string del = "delete from tblFood where Fname ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(del, con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            MessageBox.Show((res > 0) ? "Deleted" : "Not-Deleted");
            con.Close();
        }

        private void Food_New_Entry_Load(object sender, EventArgs e)
        {
            {
                string view = "select * from tblFood";
                SqlCommand v = new SqlCommand(view, con);
                SqlDataAdapter sda = new SqlDataAdapter(v);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "table";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string load = "select Fname,Ftype,Fprice,Favailable from tblFood where Fname='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(load, con);
            con.Open();
            SqlDataReader sd = cmd.ExecuteReader();
            if (sd.Read())
            {
                textBox1.Text = sd["Fname"].ToString();
                textBox2.Text = sd["Fprice"].ToString();
                comboBox1.Text = sd["Favailable"].ToString();
               
                if (sd["Ftype"].ToString() == "Veg")
                {
                    radioButton1.Checked = true;
                }
                else if (sd["Ftype"].ToString() == "Non-Veg")
                {
                    radioButton2.Checked = true;
                }
            }
            con.Close();
        }
    }
}
 