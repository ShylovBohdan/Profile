using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_15_1
{
    public class Teacher_two : Teacher_one
    {
        private Teacher_two prev;
        private Teacher_two next;
        public Teacher_two()
        {

        }
        public Teacher_two(string name_)
        {
            this.name = name_;
        }
        public Teacher_two Prev { get { return this.prev; } set { this.prev = value; } }
        public new Teacher_two Next { get { return this.next; } set { this.next = value; } }
    }
}
