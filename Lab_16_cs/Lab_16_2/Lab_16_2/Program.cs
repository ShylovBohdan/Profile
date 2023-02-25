using System;

namespace Lab_16_2
{
    public class Deque
    {
        private int[] data;
        private int first;
        private int last;
        public Deque()
        {
            this.data = new int[10];
            this.first = 0;
            this.last = 0;
        }
        public void Show()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                Console.Write(this.data[i]);
                Console.Write("\t");
            }
            Console.WriteLine();
        }
        public void Push_front(int value)
        {
            this.data[this.first] = value;
            this.first++;
            if (this.first > 9)
            {
                this.first = 0;
            }
        }
        public void Push_back(int value)
        {
            this.last--;
            if (this.last < 0)
            {
                this.last = 9;
            }
            this.data[last] = value;
        }
        public int Pop_front()
        {
            this.first--;
            if (this.first < 0)
            {
                this.first = 9;
            }
            int temp = this.data[this.first];
            if (temp == 0)
            {
                Console.WriteLine("Uncorrect operation!");
                return 0;
            }
            this.data[this.first] = 0;
            return temp;
        }
        public int Pop_back()
        {
            int temp = this.data[this.last];
            if (temp == 0)
            {
                Console.WriteLine("Uncorrect operation!");
                return 0;
            }
            this.data[this.last] = 0;
            this.last++;
            if (this.last > 9)
            {
                this.last = 0;
            }
            return temp;
        }
        public int Front()
        {
            if(this.data[this.first] == 0)
            {
                Console.WriteLine("Uncorrect operation!");
            }
            return this.data[this.first];
        }
        public int Back()
        {
            if (this.data[this.last] == 0)
            {
                Console.WriteLine("Uncorrect operation!");
            }
            return this.data[this.last];
        }
        public void Clear()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                this.data[i] = 0;
            }
        }
        public int Size()
        {
            int len = 0;
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i] != 0)
                {
                    len++;
                }
            }
            return len;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deque dec = new Deque();
            bool looped = true;
            Console.WriteLine("write \"help\" to get information");
            while (looped)
            {
                Console.Write("<Lab_16_2>");
                string command = Console.ReadLine();
                switch(command)
                {
                    case "help":
                        Console.WriteLine("push front - add to start");
                        Console.WriteLine("push back - add to end");
                        Console.WriteLine("pop front - delete from start");
                        Console.WriteLine("pop back - delete from end");
                        Console.WriteLine("show - show all array");
                        Console.WriteLine("clear - delete all values");
                        Console.WriteLine("front - return value of start element and dont delete this");
                        Console.WriteLine("back - return value of end element and dont delete this");
                        Console.WriteLine("size - return count of not 0 elements");
                        Console.WriteLine("exit - stop the program");
                        break;
                    case "push front":
                        Console.WriteLine("Enter value: ");
                        int push_front_value = int.Parse(Console.ReadLine());
                        dec.Push_front(push_front_value);
                        break;
                    case "push back":
                        Console.WriteLine("Enter value: ");
                        int push_back_value = int.Parse(Console.ReadLine());
                        dec.Push_back(push_back_value);
                        break;
                    case "pop front":
                        int pop_front = dec.Pop_front();
                        if (pop_front != 0)
                        {
                            Console.WriteLine(pop_front);
                        }
                        break;
                    case "pop back":
                        int pop_back = dec.Pop_back();
                        if (pop_back != 0)
                        {
                            Console.WriteLine(pop_back);
                        }
                        break;
                    case "show":
                        dec.Show();
                        break;
                    case "clear":
                        dec.Clear();
                        break;
                    case "front":
                        Console.WriteLine(dec.Front());
                        break;
                    case "back":
                        Console.WriteLine(dec.Back());
                        break;
                    case "size":
                        Console.WriteLine($"Size: {dec.Size()}");
                        break;
                    case "exit":
                        looped = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
