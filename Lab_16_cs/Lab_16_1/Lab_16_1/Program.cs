using System;

namespace Lab_16_1
{
    public class Check_brackets
    {
        private int[] position;
        public void push(int pos)
        {
            if(this.position == null)
            {
                this.position = new int[1];
                this.position[0] = pos;
            }
            else
            {
                int[] temp = new int[this.position.Length+1];
                for (int i = 0; i < this.position.Length; i++)
                {
                    temp[i] = this.position[i];
                }
                temp[this.position.Length] = pos;
                this.position = temp;
            }
        }
        public int get()
        {
            if (this.position == null)
            {
                return -1;
            }
            else
            {
                if(this.position.Length - 1 < 0)
                {
                    return -1;
                }
                if(this.position.Length -1 == 0)
                {
                    int val_ = this.position[this.position.Length - 1];
                    this.position = null;
                    return val_;

                }
                int[] temp = new int[this.position.Length-1];
                for (int i = 0; i < this.position.Length-1; i++)
                {
                    temp[i] = this.position[i];
                }
                int val = this.position[this.position.Length - 1];
                this.position = temp;
                return val;
            }
        }
        public bool Check(string phrase)
        {
            int pairs = 0;
            for(int i = 0; i < phrase.Length; i++)
            {
                if(phrase[i] == '(')
                {
                    this.push(i);
                }
                if(phrase[i] == ')')
                {
                    int start_pos = this.get();
                    if(start_pos == -1)
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"Couple №{pairs}:\t{start_pos},{i}");
                        pairs++;
                    }
                }
            }
            if(this.position == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string phrase = "(a-2)-4+(a-3)/(7+6/3)";
            Check_brackets chk = new Check_brackets();
            if (chk.Check(phrase))
            {
                Console.WriteLine("Phrase balanced");
            }
            else
            {
                Console.WriteLine("Phrase is not balanced");
            }
        }
    }
}
