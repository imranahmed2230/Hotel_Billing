﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBillingSystemADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Food_New_Entry fne = new Food_New_Entry();
            fne.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sales_Billing sb = new Sales_Billing();
            sb.Show();
        }
    }
}
