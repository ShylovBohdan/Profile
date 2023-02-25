using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7_cs
{
    public partial class Form1 : Form
    {
        private int[,] data = new int[4, 5];
        public Form1()
        {
            InitializeComponent();
            while (dataGridView1.Rows.Count <= 4)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.AllowUserToAddRows = false;
            DataGridViewRow row1 = (DataGridViewRow)dataGridView2.Rows[0].Clone();
            dataGridView2.Rows.Add(row1);
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var temp = dataGridView1.Rows[i].Cells[j].Value;
                    if (temp == null)
                    {
                        data[i, j] = 0;
                    }
                    else
                    {
                        data[i, j] = Convert.ToInt32(temp);
                    }
                }
            }
            for(int j = 0; j < 5; j++)
            {
                int temp = 0;
                for(int i = 0; i < 4; i++)
                {
                    temp += data[i, j];
                }
                dataGridView2.Rows[0].Cells[j].Value = temp;
            }
            dataGridView2.Update();
        }
    }
}
