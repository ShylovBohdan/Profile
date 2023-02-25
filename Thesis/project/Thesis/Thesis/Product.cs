using System;
using System.Collections.Generic;
using System.Text;

namespace Thesis
{
    public class Product
    {
        private string name;
        private string unit;
        private double price;
        private int amount;
        private Date date = new Date();

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Unit { get { return this.unit; } set { this.unit = value; } }
        public double Price { get { return this.price; } set { this.price = value; } }
        public int Amount { get { return this.amount; } set { this.amount = value; } }
        public Date Date { get { return this.date; } set { this.date = value; } }
    }
}
