using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            while (dataGridView1.Rows.Count <= 10)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.AllowUserToAddRows = false;
        }
        private void generate_table(DataGridView dataGridView1)
        {
            Random rnd = new Random();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rnd.Next(-25, 25);
                }
            }
        }
        private int[] get_arr(DataGridView dataGridView1)
        {
            int index = 0;
            int[] array = new int[dataGridView1.Rows.Count * dataGridView1.Columns.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    array[index] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    index++;
                }
            }
            return array;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            generate_table(dataGridView1);
            set_cell_style(dataGridView1, -1);
            set_cell_style(dataGridView2, -1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] search = get_arr(dataGridView2);
            int[] data = get_arr(dataGridView1);
            int[,] temp_table = new int[data.Length, search.Length];
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < search.Length; j++)
                {
                    if (data[i] == search[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            temp_table[i, j] = 1;
                        }
                        else
                        {
                            temp_table[i, j] = temp_table[i - 1, j - 1] + 1;
                        }
                    }
                }
            }
            int index_x = 0;
            int index_y = 0;
            int temp = 0;
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < search.Length; j++)
                {
                    if (temp_table[i, j] > temp)
                    {
                        temp = temp_table[i, j];
                        index_x = i;
                        index_y = j;
                    }
                }
            }
            for(int i = 0; i < temp; i++)
            {
                set_cell_style(dataGridView1, index_x);
                index_x--;
                set_cell_style(dataGridView2, index_y);
                index_y--;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int number = int.Parse(textBox1.Text);
            for(int i = 0;i< dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j< dataGridView1.Columns.Count; j++) {
                    if (number == Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value))
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.FromArgb(200, 200, 0);
                        style.ForeColor = Color.Black;
                        dataGridView1.Rows[i].Cells[j].Style = style;
                    }
                    else
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.FromArgb(255, 255, 255);
                        style.ForeColor = Color.Black;
                        dataGridView1.Rows[i].Cells[j].Style = style;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            set_cell_style(dataGridView1, -1);
            int number = int.Parse(textBox1.Text);
            int size = dataGridView1.Rows.Count * dataGridView1.Columns.Count;
            int[] data = process(get_arr(dataGridView1), size);
            set_arr(dataGridView1, data);
            int left = 0;
            int right = size;
            int middle = (left+right) / 2;
            while (left<=right)
            {
                middle = (left + right) / 2;
                if (number< data[middle])
                {
                    right = middle - 1;
                }
                else if (number > data[middle])
                {
                    left = middle + 1;
                }
                else
                {
                    set_cell_style(dataGridView1, middle);
                    int k = middle-1;
                    while(data[k] == data[middle]&&k>0)
                    {
                        set_cell_style(dataGridView1, k);
                        k++;
                    }
                    k = middle+1;
                    while (data[k] == data[middle]&&k<size)
                    {
                        set_cell_style(dataGridView1, k);
                        k--;
                    }
                    return;
                }
            }

        }
        static private void set_arr(DataGridView dataGridView1,int[] data)
        {
            int index = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = data[index];
                    index++;
                }
            }
        }
        static private void set_cell_style(DataGridView dataGridView1,int index)
        {
            int index_curent = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (index_curent == index)
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.FromArgb(200, 200, 0);
                        style.ForeColor = Color.Black;
                        dataGridView1.Rows[i].Cells[j].Style = style;
                        return;
                    }
                    else
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.FromArgb(255, 255, 255);
                        style.ForeColor = Color.Black;
                        dataGridView1.Rows[i].Cells[j].Style = style;
                    }
                    index_curent++;
                }
            }
        }

        static private int[] process(int[] data, int size)
        {
            for (int d = size / 2; d >= 1; d /= 2)
            {
                for (int i = d; i < size; i++)
                {
                    for (int j = i; j >= d && data[j - d] > data[j]; j -= d)
                    {
                        swap(ref data[j], ref data[j - d]);
                    }
                }
            }
            return data;
        }
        static private void swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
}
