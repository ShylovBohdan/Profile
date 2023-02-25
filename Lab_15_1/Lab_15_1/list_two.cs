using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_15_1
{
    public class list_two : list_one
    {
        private Teacher_two last;
        private Teacher_two first;
        public list_two()
        {
            this.first = null;
            this.length = 0;
            this.last = null;
        }
        public override bool Check()
        {
            if (this.first != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Show()
        {
            Teacher_two temp = this.first;
            while (temp != null)
            {
                Console.WriteLine(temp.Name);
                temp = temp.Next;
            }
        }
        public override int Count()
        {
            int count = 0;
            Teacher_two temp = this.first;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }
            this.length = count;
            return count;
        }
        public override void Insert(string value)
        {
            Teacher_two new_first = new Teacher_two();
            new_first.Name = value;
            new_first.Next = this.first;
            if (this.first != null)
            {
                this.first.Prev = new_first;
            }
            if (this.first == null)
            {
                this.last = new_first;
            }
            this.first = new_first;
            this.length++;
        }
        public override void InsertEnd(string value)
        {
            Teacher_two new_element = new Teacher_two();
            new_element.Name = value;
            if (this.last == null)
            {
                this.first = new_element;
                this.last = new_element;
            }
            else
            {
                new_element.Prev = this.last;
                this.last.Next = new_element;
                this.last = new_element;
            }
            this.length++;
        }
        public override bool InsertPos(string value, int pos)
        {
            Teacher_two temp = this.first;
            for (int i = 0; i < pos - 1; i++)
            {
                if (temp == null)
                {
                    return false;
                }
                temp = temp.Next;
            }
            Teacher_two new_element = new Teacher_two();
            new_element.Name = value;
            var next_element = temp.Next;
            temp.Next = new_element;
            new_element.Prev = temp;
            new_element.Next = next_element;
            if (next_element != null)
            {
                next_element.Prev = new_element;
            }
            this.length++;
            return true;
        }
        public override void Clear()
        {
            Teacher_two temp = this.first;
            Teacher_two temp_next = null;
            while (temp != null)
            {
                temp_next = temp.Next;
                temp.Next = null;
                temp = temp_next;
            }
            this.length = 0;
            this.first = null;
        }
        public override void ClearAll()
        {
            Teacher_two temp = this.first;
            Teacher_two temp_next = null;
            while (temp != null)
            {
                temp_next = temp.Next;
                temp.Next = null;
                temp.Name = null;
                temp = temp_next;
            }
            this.length = 0;
            this.first = null;
        }
        public override bool DelPos(int position)
        {
            Teacher_two temp = this.first;
            for (int i = 0; i < position - 1; i++)
            {
                if (temp == null)
                {
                    return false;
                }
                temp = temp.Next;
            }
            Teacher_two temp_next = temp.Next;
            if (temp_next == null)
            {
                return false;
            }
            temp.Next = temp_next.Next;
            temp_next.Next.Prev = temp;
            this.length--;
            return true;
        }
        public override void DelValue(string value)
        {
            if (this.first != null)
            {
                if (this.first.Name == value)
                {
                    this.first = this.first.Next;
                    this.first.Prev = null;
                    this.length--;
                    return;
                }
                if (this.last.Name == value)
                {
                    this.last.Prev.Next = null;
                    this.last = this.last.Prev;
                    this.length--;
                    return;
                }
                Teacher_two temp = this.first;
                if (temp.Next != null)
                {
                    Teacher_two temp_next = temp.Next;
                    while (temp_next != null)
                    {
                        if (temp_next.Name == value)
                        {
                            temp.Next = temp_next.Next;
                            temp_next.Next.Prev = temp;
                            this.length--;
                            return;
                        }
                    }
                }
            }
        }
        public override void DelValueAll(string value)
        {
            if (this.first != null)
            {
                while (this.first.Name == value)
                {
                    this.first = this.first.Next;
                    if (this.first != null)
                    {
                        this.first.Prev = null;
                    }
                    else
                    {
                        this.length = 0;
                        return;
                    }
                    this.length--;
                }
                while (this.last.Name == value)
                {
                    this.last.Prev.Next = null;
                    if (this.last != null)
                    {
                        this.last = this.last.Prev;
                    }
                    else
                    {
                        this.length = 0;
                        return;
                    }
                    this.length--;
                }
                Teacher_two temp = this.first;
                if (this.first == null)
                {
                    return;
                }
                if (temp.Next != null)
                {
                    Teacher_two temp_next = temp.Next;
                    while (temp_next != null)
                    {
                        if (temp_next.Name == value)
                        {
                            temp.Next = temp_next.Next;
                            temp_next.Next.Prev = temp;
                            this.length--;
                        }
                    }
                }
            }
        }
        public override bool Edit(int position, string value)
        {
            Teacher_two temp = this.first;
            for (int i = 0; i < position; i++)
            {
                if (temp == null)
                {
                    return false;
                }
                temp = temp.Next;
            }
            temp.Name = value;
            return true;
        }
        public override void Replace(string value, string new_value)
        {
            Teacher_two temp = this.first;
            while (temp != null)
            {
                if (temp.Name == value)
                {
                    temp.Name = new_value;
                }
                temp = temp.Next;
            }
        }
        public override void Find(string value)
        {
            Teacher_two temp = this.first;
            for (int i = 0; i < this.length; i++)
            {
                if (temp == null)
                {
                    return;
                }
                else
                {
                    if (temp.Name == value)
                    {
                        Console.WriteLine($"ID: {i}\tvalue: {temp.Name}");
                        temp = temp.Next;
                    }
                }
            }
        }
        private bool swap(Teacher_two one, Teacher_two two)
        {
            Teacher_two temp;
            Teacher_two temp_two;
            if (this.first == null)
            {
                return false;
            }
            if (one == this.first || two == this.first)
            {
                if (one == this.first && two == this.first)
                {
                    return true;
                }
                else if (one == this.first && two != this.first)
                {
                    temp_two = this.first;
                    while (temp_two != two)
                    {
                        if (temp_two.Next == null)
                        {
                            return false;
                        }
                        temp_two = temp_two.Next;
                    }
                    Teacher_two tmp = this.first.Next;
                    if (this.first.Next == temp_two)
                    {
                        this.first.Next = temp_two.Next;
                        this.first.Prev = temp_two;
                        temp_two.Prev = null;
                        temp_two.Next = this.first;
                    }
                    else
                    {
                        this.first.Next.Prev = temp_two;
                        temp_two.Prev.Next = this.first;
                        if (temp_two.Next != null)
                        {
                            temp_two.Next.Prev = this.first;
                        }
                        this.first.Next = temp_two.Next;
                        this.first.Prev = temp_two.Prev;
                        temp_two.Prev = null;
                        temp_two.Next = tmp;
                    }
                    if (this.last == temp_two)
                    {
                        this.last = this.first;
                    }
                    this.first = temp_two;
                    return true;
                }
                else if (one != this.first && two == this.first)
                {
                    temp = this.first;
                    while (temp != one)
                    {
                        if (temp.Next == null)
                        {
                            return false;
                        }
                        temp = temp.Next;
                    }
                    Teacher_two tmp = this.first.Next;
                    if (this.first.Next == temp)
                    {
                        this.first.Next = temp.Next;
                        this.first.Prev = temp;
                        temp.Prev = null;
                        temp.Next = this.first;
                    }
                    else
                    {
                        this.first.Next.Prev = temp;
                        temp.Prev.Next = this.first;
                        if (temp.Next != null)
                        {
                            temp.Next.Prev = this.first;
                        }
                        this.first.Next = temp.Next;
                        this.first.Prev = temp.Prev;
                        temp.Prev = null;
                        temp.Next = tmp;
                    }
                    if (this.last == temp)
                    {
                        this.last = this.first;
                    }
                    this.first = temp;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (one == this.last || two == this.last)
            {
                if (one == this.last && two == this.last)
                {
                    return true;
                }
                else if (one == this.last && two != this.last)
                {
                    temp_two = this.first;
                    while (temp_two != two)
                    {
                        if (temp_two.Next == null)
                        {
                            return false;
                        }
                        temp_two = temp_two.Next;
                    }
                    Teacher_two tmp = this.last.Prev;
                    if (this.last.Prev == temp_two)
                    {
                        this.last.Next = temp_two;
                        this.last.Prev = temp_two.Prev;
                        temp_two.Next = null;
                        temp_two.Prev = this.last;
                    }
                    else
                    {
                        this.last.Prev.Next = temp_two;
                        if (temp_two.Prev != null)
                        {
                            temp_two.Prev.Next = this.last;
                        }
                        temp_two.Next.Prev = this.last;
                        this.last.Next = temp_two.Next;
                        this.last.Prev = temp_two.Prev;
                        temp_two.Next = null;
                        temp_two.Prev = tmp;
                    }
                    this.last = temp_two;
                    return true;
                }
                else if (one != this.last && two == this.last)
                {
                    temp = this.first;
                    while (temp != one)
                    {
                        if (temp.Next == null)
                        {
                            return false;
                        }
                        temp = temp.Next;
                    }
                    Teacher_two tmp = this.last.Prev;
                    if (this.last.Prev == temp)
                    {
                        this.last.Next = temp;
                        this.last.Prev = temp.Prev;
                        temp.Next = null;
                        temp.Prev = this.last;
                    }
                    else
                    {
                        this.last.Prev.Next = temp;
                        if (temp.Next != null)
                        {
                            temp.Prev.Next = this.last;
                        }
                        temp.Next.Prev = this.last;
                        this.last.Next = temp.Next;
                        this.last.Prev = temp.Prev;
                        temp.Next = null;
                        temp.Prev = tmp;
                    }
                    this.first = temp;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                temp = this.first;
                while (temp != one)
                {
                    if (temp.Next == null)
                    {
                        return false;
                    }
                    temp = temp.Next;
                }
                temp_two = this.first;
                while (temp_two != two)
                {
                    if (temp_two.Next == null)
                    {
                        return false;
                    }
                    temp_two = temp_two.Next;
                }
                Teacher_two tmp_next = temp.Next;
                Teacher_two tmp_prev = temp.Prev;
                if (temp.Next == temp_two)
                {
                    if (temp.Prev != null)
                    {
                        temp.Prev.Next = temp_two;
                    }
                    if (temp_two.Next != null)
                    {
                        temp_two.Next.Prev = temp;
                    }
                    temp.Prev = temp_two;
                    temp.Next = temp_two.Next;
                    temp_two.Next = temp;
                    temp_two.Prev = tmp_prev;
                }
                else if (temp_two.Next == temp)
                {
                    if (temp_two.Prev != null)
                    {
                        temp_two.Prev.Next = temp;
                    }
                    if (temp.Next != null)
                    {
                        temp.Next.Prev = temp_two;
                    }
                    temp.Next = temp_two;
                    temp.Prev = temp_two.Prev;
                    temp_two.Prev = temp;
                    temp_two.Next = tmp_next;
                }
                else
                {
                    if (temp.Next != null)
                    {
                        temp.Next.Prev = temp_two;
                    }
                    if (temp.Prev != null)
                    {
                        temp.Prev.Next = temp_two;
                    }
                    if (temp_two.Prev != null)
                    {
                        temp_two.Prev.Next = temp;
                    }
                    if (temp_two.Next != null)
                    {
                        temp_two.Next.Prev = temp;
                    }
                    temp.Next = temp_two.Next;
                    temp.Prev = temp_two.Prev;
                    temp_two.Next = tmp_next;
                    temp_two.Prev = tmp_prev;
                }
                return true;
            }
        }
        public override void Sort(string key = "alphabet")
        {
            Teacher_two temp = this.first;
            if (temp == null)
            {
                return;
            }
            Teacher_two check = temp.Next;
            switch (key)
            {
                case "alphabet":
                    while (temp != null)
                    {
                        check = temp.Next;
                        while (check != null)
                        {
                            bool swapped = false;
                            bool same = true;
                            for (int i = 0; i < temp.Name.Length && i < check.Name.Length; i++)
                            {
                                if (temp.Name[i] > check.Name[i])
                                {
                                    if (!swap(temp, check))
                                    {
                                        return;
                                    }
                                    Teacher_two tmp = temp;
                                    temp = check;
                                    check = tmp;
                                    swapped = true;
                                    break;
                                }
                                if (temp.Name[i] != check.Name[i])
                                {
                                    same = false;
                                }
                            }
                            if (same && !swapped)
                            {
                                if (temp.Name.Length > check.Name.Length)
                                {
                                    if (!swap(temp, check))
                                    {
                                        return;
                                    }
                                    Teacher_two tmp = temp;
                                    temp = check;
                                    check = tmp;
                                }
                            }
                            check = check.Next;
                        }
                        temp = temp.Next;
                    }
                    break;
                default:
                    break;
            }
        }
        public override void Save(string path)
        {
            StreamWriter file_write = new StreamWriter(path);
            Teacher_two temp = this.first;
            while (temp != null)
            {
                file_write.WriteLine(temp.Name);
                temp = temp.Next;
            }
            file_write.Close();
        }
        public override void Read(string path)
        {
            StreamReader file_read = new StreamReader(path);
            string read_name = file_read.ReadLine();
            if (read_name != "" && read_name != null)
            {
                this.first = new Teacher_two(read_name);
                this.last = this.first;
            }
            read_name = file_read.ReadLine();
            Teacher_two temp = this.first;
            while (read_name != "" && read_name != null)
            {
                temp.Next = new Teacher_two(read_name);
                temp.Next.Prev = temp;
                read_name = file_read.ReadLine();
                temp = temp.Next;
                this.last = temp;
            }
            file_read.Close();
        }
    }
}
