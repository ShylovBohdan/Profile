using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab_15_1
{
    
public class list_one
{
    private Teacher_one first;
    protected int length;
    public int Length { get { return this.length; } set { this.length = value; } }
    public list_one()
    {
        this.first = null;
        this.length = 0;
    }
    public virtual void Show()
    {
        Teacher_one temp = this.first;
        while (temp != null)
        {
            Console.WriteLine(temp.Name);
            temp = temp.Next;
        }
    }
    public virtual int Count()
    {
        int count = 0;
        Teacher_one temp = this.first;
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        length = count;
        return count;
    }
    public virtual bool Check()
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
    public virtual void Insert(string value)
    {
        Teacher_one new_first = new Teacher_one();
        new_first.Name = value;
        new_first.Next = this.first;
        this.first = new_first;
        this.length++;
    }
    public virtual void InsertEnd(string value)
    {
        Teacher_one temp = this.first;
        Teacher_one new_element = new Teacher_one();
        new_element.Name = value;
        if (temp == null)
        {
            this.first = new_element;
            return;
        }
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = new_element;
        this.length++;
    }
    public virtual bool InsertPos(string value, int pos)
    {
        Teacher_one temp = this.first;
        for (int i = 0; i < pos - 1; i++)
        {
            if (temp == null)
            {
                return false;
            }
            temp = temp.Next;
        }
        Teacher_one new_element = new Teacher_one();
        new_element.Name = value;
        var next_element = temp.Next;
        temp.Next = new_element;
        new_element.Next = next_element;
        this.length++;
        return true;
    }
    public virtual void Clear()
    {
        Teacher_one temp = this.first;
        Teacher_one temp_next = null;
        while (temp != null)
        {
            temp_next = temp.Next;
            temp.Next = null;
            temp = temp_next;
        }
        this.length = 0;
        this.first = null;
    }
    public virtual void ClearAll()
    {
        Teacher_one temp = this.first;
        Teacher_one temp_next = null;
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
    public virtual bool DelPos(int position)
    {
        Teacher_one temp = this.first;
        for (int i = 0; i < position - 1; i++)
        {
            if (temp == null)
            {
                return false;
            }
            temp = temp.Next;
        }
        Teacher_one temp_next = temp.Next;
        if (temp_next == null)
        {
            return false;
        }
        temp.Next = temp_next.Next;
        this.length--;
        return true;
    }
    public virtual void DelValue(string value)
    {
        if (this.first != null)
        {
            if (this.first.Name == value)
            {
                this.first = this.first.Next;
                this.length--;
                return;
            }
            Teacher_one temp = this.first;
            if (temp.Next != null)
            {
                Teacher_one temp_next = temp.Next;
                while (temp_next != null)
                {
                    if (temp_next.Name == value)
                    {
                        temp.Next = temp_next.Next;
                        this.length--;
                        return;
                    }
                }
            }
        }
    }
    public virtual void DelValueAll(string value)
    {
        if (this.first != null)
        {
            if (this.first.Name == value)
            {
                this.first = this.first.Next;
                this.length--;
            }
            Teacher_one temp = this.first;
            if (temp.Next != null)
            {
                Teacher_one temp_next = temp.Next;
                while (temp_next != null)
                {
                    if (temp_next.Name == value)
                    {
                        temp.Next = temp_next.Next;
                        this.length--;
                    }
                }
            }
        }
    }
    public virtual bool Edit(int position, string value)
    {
        Teacher_one temp = this.first;
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
    public virtual void Replace(string value, string new_value)
    {
        Teacher_one temp = this.first;
        while (temp != null)
        {
            if (temp.Name == value)
            {
                temp.Name = new_value;
            }
            temp = temp.Next;
        }
    }
    public virtual void Find(string value)
    {
        Teacher_one temp = this.first;
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
    private bool swap(Teacher_one one, Teacher_one two)
    {
        Teacher_one temp = this.first;
        Teacher_one temp_two = this.first;
        if (temp == null)
        {
            return false;
        }
        if (temp != one && temp != two)
        {
            while (temp.Next != one)
            {
                if (temp.Next == null)
                {
                    return false;
                }
                temp = temp.Next;
            }
            while (temp_two.Next != two)
            {
                if (temp_two.Next == null)
                {
                    return false;
                }
                temp_two = temp_two.Next;
            }
            temp.Next = two;
            temp_two.Next = one;
            Teacher_one temp_next = one.Next;
            one.Next = two.Next;
            two.Next = temp_next;
            return true;
        }
        else if (temp == one && temp != two)
        {
            while (temp_two.Next != two)
            {
                if (temp_two.Next == null)
                {
                    return false;
                }
                temp_two = temp_two.Next;
            }
            this.first = two;
            temp_two.Next = one;
            Teacher_one temp_next = one.Next;
            one.Next = two.Next;
            two.Next = temp_next;
            return true;
        }
        else if (temp != one && temp == two)
        {
            while (temp.Next != one)
            {
                if (temp.Next == null)
                {
                    return false;
                }
                temp = temp.Next;
            }
            temp.Next = two;
            this.first = one;
            Teacher_one temp_next = one.Next;
            one.Next = two.Next;
            two.Next = temp_next;
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual void Sort(string key = "alphabet")
    {
        Teacher_one temp = this.first;
        if (temp == null)
        {
            return;
        }
        Teacher_one check = temp.Next;
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
                                Teacher_one tmp = temp;
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
                                Teacher_one tmp = temp;
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
    public virtual void Save(string path)
    {
        StreamWriter file_write = new StreamWriter(path);
        Teacher_one temp = this.first;
        while (temp != null)
        {
            file_write.WriteLine(temp.Name);
            temp = temp.Next;
        }
        file_write.Close();
    }
    public virtual void Read(string path)
    {
        StreamReader file_read = new StreamReader(path);
        string read_name = file_read.ReadLine();
        if (read_name != "" && read_name != null)
        {
            this.first = new Teacher_one(read_name);
        }
        read_name = file_read.ReadLine();
        Teacher_one temp = this.first;
        while (read_name != "" && read_name != null)
        {
            temp.Next = new Teacher_one(read_name);
            read_name = file_read.ReadLine();
            temp = temp.Next;
        }
        file_read.Close();
    }
}
}
