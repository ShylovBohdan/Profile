using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thesis
{
    public partial class Bill : Form
    {
        public Bill(string prod_text,double sum)
        {
            InitializeComponent();
            this.Products_text.Text = "Name\tUnit\tPrice\tAmount\n";
            this.Products_text.Text += prod_text;
            this.Sum.Text = sum.ToString();
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
