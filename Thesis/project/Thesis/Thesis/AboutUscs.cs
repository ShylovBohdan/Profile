using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thesis
{
    public partial class AboutUs : Form
    {
        private Form1 parent;
        public AboutUs(Form1 p)
        {
            this.parent = p;
            InitializeComponent();
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutUs_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parent.about_us_closing();
        }
    }
}
