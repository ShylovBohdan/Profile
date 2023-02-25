using System;
using System.Collections.Generic;

namespace Lab_16_3
{
    public class Book
    {
        public Book parent;
        public Book left;
        public Book right;
        public string content;
        public int compare(Book another)
        {
            if(another.content == null)
            {
                return 0;
            }
            else
            {
                int len = this.content.Length;
                int another_len = another.content.Length;
                if(this.content == another.content)
                {
                    return 0;
                }
                bool same = true;
                for (int i = 0; i < len&&i<another_len; i++)
                {
                    if (((int)another.content[i]) < ((int)this.content[i]))
                    {
                        return 1;
                    }
                }
                for (int i = 0; i < len && i < another_len; i++)
                {
                    if (((int)another.content[i]) != ((int)this.content[i]))
                    {
                        same = false;
                    }
                }
                if (same && len < another_len)
                {
                    return -1;
                }
                else if (same && len > another_len)
                {
                    return 1;
                }
                return -1;
            }
        }
    }
    public class Tree
    {
        private Book root;
        public void Insert(string value)
        {
            Book new_book = new Book();
            new_book.content = value;
            if(this.root == null)
            {
                this.root = new_book;
                return;
            }
            else
            {
                Book temp = this.root;
                while(temp != null)
                {
                    int compare = temp.compare(new_book);
                    if(compare == 1)
                    {
                        if(temp.right == null)
                        {
                            temp.right = new_book;
                            new_book.parent = temp;
                            return;
                        }
                        temp = temp.right;
                    }
                    if(compare == -1)
                    {
                        if(temp.left == null)
                        {
                            temp.left = new_book;
                            new_book.parent = temp;
                            return;
                        }
                        temp = temp.left;
                    }
                    if( compare == 0)
                    {
                        return;
                    }
                }
            }
        }
        public void Delete(string value)
        {
            Book temp = this.root;
            Queue<Book> queue = new Queue<Book>();
            while (temp != null)
            {
                if(temp.content == value)
                {
                    if(temp.left==null&&temp.right == null)
                    {
                        if(temp.parent.left == temp)
                        {
                            temp.parent.left = null;
                        }
                        if(temp.parent.right == temp)
                        {
                            temp.parent.right = null;
                        }
                    }
                    if((temp.left != null && temp.right == null)||(temp.left == null && temp.right != null))
                    {
                        Book tmp = null;
                        if(temp.left != null)
                        {
                            tmp = temp.left;
                        }
                        if(temp.right != null)
                        {
                            tmp = temp.right;
                        }
                        if(temp.parent.left == temp)
                        {
                            temp.parent.left = tmp;
                            tmp.parent = temp.parent;
                        }
                        if(temp.parent.right == temp)
                        {
                            temp.parent.right = tmp;
                            tmp.parent = temp.parent;
                        }
                    }
                    if(temp.left != null && temp.right != null)
                    {

                    }
                }
                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    queue.Enqueue(temp.right);
                }
                if (queue.Count != 0)
                {
                    temp = queue.Dequeue();
                }
                else
                {
                    temp = null;
                }
            }
        }
        public void Show()
        {
            Book temp = this.root;
            Queue<Book> queue = new Queue<Book>();
            while (temp != null)
            {
                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    queue.Enqueue(temp.right);
                }
                Console.Write(temp.content);
                Console.Write("\t");
                if (queue.Count != 0)
                {
                    temp = queue.Dequeue();
                }
                else
                {
                    temp = null;
                }
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write \"help\" for information");
            bool looped = true;
            Tree tree = new Tree();
            while (looped)
            {
                Console.Write("<Lab_16_3>");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "help":
                        Console.WriteLine("push - add some information");
                        Console.WriteLine("del - delete some information");
                        Console.WriteLine("show - show all tree");
                        break;
                    case "push":
                        Console.WriteLine("Enter value(string):");
                        string content = Console.ReadLine();
                        tree.Insert(content);
                        break;
                    case "del":
                        Console.WriteLine("Enter value(string):");
                        string delete = Console.ReadLine();
                        tree.Insert(delete);
                        break;
                    case "show":
                        tree.Show();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
