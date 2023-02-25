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
    class Merge_algorithm
    {
        static public bool proces = true;
        static Thread th;
        static public int[] process(int[] data, int size, bool everyFrame, int bitmapWidth, int bitmapHeight, PictureBox pictureBox1,int lowIndex,int highIndex)
        {
            th = new Thread(t =>
            {
                logic(data,  size,  everyFrame,  bitmapWidth,  bitmapHeight,  pictureBox1,  lowIndex,  highIndex);
                print_image(data, size, bitmapWidth, bitmapHeight, pictureBox1, null);
                proces = true;
            });
            th.Start();
            return data;
        }
        static private int[] logic(int[] data, int size, bool everyFrame, int bitmapWidth, int bitmapHeight, PictureBox pictureBox1, int lowIndex, int highIndex)
        {
            if (proces == false)
            {
                print_image(data, size, bitmapWidth, bitmapHeight, pictureBox1, null);
                return data;
            }
            int[] swapped = new int[size];
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                logic(data, size, everyFrame, bitmapWidth, bitmapHeight, pictureBox1, lowIndex, middleIndex);
                logic(data, size, everyFrame, bitmapWidth, bitmapHeight, pictureBox1, middleIndex + 1, highIndex);
                Merge(data, lowIndex, middleIndex, highIndex, ref swapped);
                if (everyFrame)
                {
                    print_image(data, size, bitmapWidth, bitmapHeight, pictureBox1, swapped);
                }
            }
            return data;
        }
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex,ref int[] swapped)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    swapped[index] = left;
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    swapped[index] = right;
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                swapped[index] = left;
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                swapped[index] = right;
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
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
        static public void print_image(int[] sortedData, int size, int bitmapWidth, int bitmapHeight, PictureBox pictureBox1, int[] swapped)
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
                if (swapped != null)
                {
                    for (int i = 0; i < swapped.Length; i++)
                    {
                        if (count == swapped[i])
                            curentSwaped = true;
                    }
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
}
