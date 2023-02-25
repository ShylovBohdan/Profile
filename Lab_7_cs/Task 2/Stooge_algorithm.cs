using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Task_2
{
    class Stooge_algorithm
    {
        static bool proces = true;
        static Thread th;
        static public void process(int[] data, int size, bool everyFrame, int bitmapWidth, int bitmapHeight, PictureBox pictureBox1, ref int[] return_arr, int left, int right)
        {
            int[] temp = new int[0];
            th = new Thread(t =>
            {
                logic(data, size, everyFrame, bitmapWidth, bitmapHeight, pictureBox1,ref temp, left, right);
                print_image(data, size, bitmapWidth, bitmapHeight, pictureBox1, -1, -1);
                proces = true;
            });
            th.Start();
        }
        static private void logic(int[] data, int size, bool everyFrame, int bitmapWidth, int bitmapHeight, PictureBox pictureBox1, ref int[] return_arr, int left, int right)
        {
            if(proces == false)
            {
                return;
            }
            int stepX = bitmapWidth / size;
            int stepY = bitmapHeight / size;
            int swapped1 = -1;
            int swapped2 = -1;
            if (data[left] > data[right])
            {
                swap(ref data[left], ref data[right]);
                swapped1 = left;
                swapped2 = right;
                if (everyFrame)
                {
                    print_image(data, size, bitmapWidth, bitmapHeight, pictureBox1, swapped1, swapped2);
                }
            }
            if ((left + 1) >= right)
                return;
            int k = (int)((right - left + 1) / 3);
            logic(data, size, everyFrame, bitmapWidth, bitmapHeight, pictureBox1, ref data, left, right - k);
            logic(data, size, everyFrame, bitmapWidth, bitmapHeight, pictureBox1, ref data, left + k, right);
            logic(data, size, everyFrame, bitmapWidth, bitmapHeight, pictureBox1, ref data, left, right - k);
            return_arr = data;
        }
        static private void swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
        static public void print_image(int[] sortedData,int size,int bitmapWidth, int bitmapHeight, PictureBox pictureBox1,int swapped1,int swapped2)
        {
            int stepX = bitmapWidth / size;
            int stepY = bitmapHeight / size;
            bool paintGreen = false;
            int count = -1;
            int currentX = 0;
            int currentY = 0;
            Bitmap myBitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (currentX = 0; currentX < bitmapWidth; currentX++)
            {
                if ((currentX % stepX) == 0)
                {
                    count++;
                }
                bool curentSwaped = false;
                if (count == swapped1 || count == swapped2)
                {
                    curentSwaped = true;
                }
                for (currentY = 0; currentY < bitmapHeight; currentY++)
                {
                    if ((currentY % stepY) == 0)
                    {
                        if (((bitmapHeight - currentY) / stepY) < sortedData[count] + 25)
                        {
                            paintGreen = true;
                        }
                        else
                        {
                            paintGreen = false;
                        }
                    }
                    if (paintGreen == true && curentSwaped == true)
                    {
                        myBitmap1.SetPixel(currentX, currentY, Color.FromArgb(0, 200, 200));
                    }
                    else if (paintGreen == true && curentSwaped == false)
                    {
                        myBitmap1.SetPixel(currentX, currentY, Color.FromArgb(0, 200, 20));
                    }
                    else if (paintGreen == false && curentSwaped == true)
                    {
                        myBitmap1.SetPixel(currentX, currentY, Color.FromArgb(200, 200, 0));
                    }
                    else if (paintGreen == false && curentSwaped == false)
                    {
                        myBitmap1.SetPixel(currentX, currentY, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            pictureBox1.Image = myBitmap1;
            pictureBox1.Update();
        }
        static public void stop()
        {
            proces = false;
        }
    }
}
