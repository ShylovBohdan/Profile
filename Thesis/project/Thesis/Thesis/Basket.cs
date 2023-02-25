using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thesis
{
    public partial class Basket : Form
    {
        private Form1 parrent;
        public Basket(Form1 p)
        {
            parrent = p;
            InitializeComponent();
            this.dataGridView1.ReadOnly = true;
        }
        public void updateBasketDataGrid(Products prod)
        {
            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < prod.Data.Count; i++)
            {
                this.Add_product_To_DataGridView(prod.Data[i]);
            }
        }
        private void Add_product_To_DataGridView(Product prod)
        {
            this.dataGridView1.Rows.Add(prod.Name, prod.Unit, prod.Price.ToString(), prod.Amount.ToString());
        }
        private void Basket_FormClosing(object sender, FormClosingEventArgs e)
        {
            parrent.basket_closing();
        }
    }
}
