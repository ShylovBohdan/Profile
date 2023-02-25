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
    class Shaker_algorithm
    {
        static bool proces = true;
        static Thread th;
        static public int[] process(int[] data, int size, bool everyFrame, int bitmapWidth, int bitmapHeight, PictureBox pictureBox1)
        {
            int stepX = bitmapWidth / size;
            int stepY = bitmapHeight / size;
            int[] sortedData = new int[size];
            int swapped = 0;
            th = new Thread(t =>
            {
                for (int i = 0; i < size; i++)
                {
                    sortedData[i] = data[i];
                }
                for (int i = 0; i < (size - 2) / 2; i++)
                {
                    for (int j = 0; j < (size - 1) - i; j++)
                    {
                        if (sortedData[j] > sortedData[j + 1])
                        {
                            swap(ref sortedData[j], ref sortedData[j + 1]);
                            swapped = j;
                            if (everyFrame)
                            {
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
                                    if (count == swapped || count == swapped + 1)
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
                        }
                        if (proces == false)
                        {
                            break;
                        }
                    }
                    for (int j = size - 2; j >= i; j--)
                    {
                        if (sortedData[j] > sortedData[j + 1])
                        {
                            swap(ref sortedData[j], ref sortedData[j + 1]);
                            swapped = j;
                            if (everyFrame)
                            {
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
                                    if (count == swapped || count == swapped + 1)
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
                bool paintGreen1 = false;
                int count1 = -1;
                int currentX1 = 0;
                int currentY1 = 0;
                for (currentX1 = 0; currentX1 < bitmapWidth; currentX1++)
                {
                    if ((currentX1 % stepX) == 0)
                    {
                        count1++;
                    }
                    for (currentY1 = 0; currentY1 < bitmapHeight; currentY1++)
                    {
                        if ((currentY1 % stepY) == 0)
                        {
                            if (((bitmapHeight - currentY1) / stepY) < sortedData[count1] + 25)
                            {
                                paintGreen1 = true;
                            }
                            else
                            {
                                paintGreen1 = false;
                            }
                        }
                        if (paintGreen1)
                        {
                            ((Bitmap)pictureBox1.Image).SetPixel(currentX1, currentY1, Color.FromArgb(0, 200, 20));
                        }
                        else
                        {
                            ((Bitmap)pictureBox1.Image).SetPixel(currentX1, currentY1, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
                pictureBox1.Refresh();
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
        static public void stop()
        {
            proces = false;
        }
    }
}
