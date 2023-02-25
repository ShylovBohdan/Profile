using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_15_1
{
    public class Teacher_one
    {
        protected string name;
        private Teacher_one next;
        public Teacher_one()
        {

        }
        public Teacher_one(string name_)
        {
            this.name = name_;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
        public Teacher_one Next { get { return this.next; } set { this.next = value; } }
    }
}
