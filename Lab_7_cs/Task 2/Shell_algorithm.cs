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
    class Shell_algorithm
    {
        static bool proces = true;
        static Thread th;
        static public int[] process(int[] data, int size, bool everyFrame, int bitmapWidth, int bitmapHeight, PictureBox pictureBox1)
        {
            int stepX = bitmapWidth / size;
            int stepY = bitmapHeight / size;
            int swapped1 = -1;
            int swapped2 = -1;
            int[] sortedData = new int[size];
            th = new Thread(t =>
            {
                for (int i = 0; i < size; i++)
                {
                    sortedData[i] = data[i];
                }
                for (int d = size / 2; d >= 1; d /= 2)
                {
                    for (int i = d; i < size; i++)
                    {
                        for (int j = i; j >= d && sortedData[j - d] > sortedData[j]; j -= d)
                        {
                            swapped1 = j;
                            swapped2 = j - d;
                            swap(ref sortedData[swapped1], ref sortedData[swapped2]);
                            if (everyFrame)
                            {
                                print_image(sortedData, size, bitmapWidth, bitmapHeight, pictureBox1, swapped1, swapped2);
                            }
                            if(proces == false)
                            {
                                break;
                            }
                        }
                        if (proces == false)
                        {
                            break;
                        }
                    }
                    if (proces == false)
                    {
                        break;
                    }
                }
                print_image(sortedData, size, bitmapWidth, bitmapHeight, pictureBox1, -1, -1);
                proces = true;
            });
            th.Start();
            return sortedData;
        }
        static private void swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
        static public void print_image(int[] sortedData, int size, int bitmapWidth, int bitmapHeight, PictureBox pictureBox1, int swapped1, int swapped2)
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
