using System;
using System.Collections.Generic;
using System.Text;

namespace Thesis
{
    public class Date
    {
        private int day;
        private int month;
        private int year;
        public static bool operator <(Date a, Date b)
        {
            if (a.year < b.year)
            {
                return true;
            }
            else if (a.year == b.year)
            {
                if (a.month < b.month)
                {
                    return true;
                }
                else if (a.month == b.month)
                {
                    if (a.Day < b.Day)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Date a, Date b)
        {
            if (a.year > b.year)
            {
                return true;
            }
            else if (a.year == b.year)
            {
                if (a.month > b.month)
                {
                    return true;
                }
                else if (a.month == b.month)
                {
                    if (a.Day > b.Day)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public int Day { get { return this.day; } set { this.day = value; } }
        public int Month { get { return this.month; } set { if (value <= 12) { this.month = value; } } }
        public int Year { get { return this.year; } set { this.year = value; } }
    }
}
