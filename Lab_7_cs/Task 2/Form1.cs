using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_2;
using System.Diagnostics;
using System.Threading;

namespace Task_2
{
    public partial class Form1 : Form
    {
        private int bitmapWidth = 650;
        static private int arr_size = 50;
        private int bitmapHeight = 450;
        private int[] data = new int[arr_size];
        private int[] sortedData = null;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(bitmapWidth, bitmapHeight);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stooge_algorithm.process(data, arr_size, checkBox1.Checked, bitmapWidth, bitmapHeight, pictureBox1, ref sortedData,0,arr_size-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for(int i = 0; i < 50; i++)
            {
                data[i] = rnd.Next(-25,25);
            }
            bool paintGreen = false;
            int count = -1;
            int stepX = bitmapWidth / 50;
            int stepY = bitmapHeight / 50;
            int currentX = 0;
            int currentY = 0;
            Bitmap myBitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (currentX = 0; currentX < bitmapWidth; currentX++)
            {
                if ((currentX % stepX) == 0)
                {
                    count++;
                }
                for (currentY = 0; currentY < bitmapHeight; currentY++)
                {
                    if ((currentY % stepY) == 0)
                    {
                        if (((bitmapHeight-currentY) / stepY) < data[count] + 25)
                        {
                            paintGreen = true;
                        }
                        else
                        {
                            paintGreen = false;
                        }
                    }
                    if (paintGreen)
                    {
                        myBitmap1.SetPixel(currentX, currentY, Color.FromArgb(0, 200, 20));
                    }
                    else
                    {
                        myBitmap1.SetPixel(currentX, currentY, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            pictureBox1.Image = myBitmap1;
            pictureBox1.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.sortedData = Bubble_algorithm.process(data, arr_size,checkBox1.Checked, bitmapWidth, bitmapHeight, pictureBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.sortedData = Shaker_algorithm.process(data, arr_size, checkBox1.Checked, bitmapWidth, bitmapHeight, pictureBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.sortedData = Insertion_algorithm.process(data, arr_size, checkBox1.Checked, bitmapWidth, bitmapHeight, pictureBox1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Shell_algorithm.process(data, arr_size, checkBox1.Checked, bitmapWidth, bitmapHeight, pictureBox1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Merge_algorithm.process(data, arr_size, checkBox1.Checked, bitmapWidth, bitmapHeight, pictureBox1,0,arr_size-1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Selection_algorithm.process(data, arr_size, checkBox1.Checked, bitmapWidth, bitmapHeight, pictureBox1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Quick_algorithm.process(data, arr_size, checkBox1.Checked, bitmapWidth, bitmapHeight, pictureBox1, 0, arr_size - 1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bubble_algorithm.stop();
            Insertion_algorithm.stop();
            Merge_algorithm.stop();
            Quick_algorithm.stop();
            Selection_algorithm.stop();
            Shaker_algorithm.stop();
            Shell_algorithm.stop();
            Stooge_algorithm.stop();
        }
    }
}
