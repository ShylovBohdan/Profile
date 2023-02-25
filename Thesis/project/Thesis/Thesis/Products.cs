using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Thesis
{
    public class Products
    {
        private List<Product> data = new List<Product>();
        public void Add_product(Product add_product)
        {
            this.data.Add(add_product);
        }
        public void Delete_product(Product del_product)
        {
            this.data.Remove(del_product);
        }
        public void Read_file(string path)
        {
            try
            {
                this.data = new List<Product>();
                StreamReader reader = new StreamReader(path);
                string line = reader.ReadLine();
                int i = 0;
                while (line != "" && line != null)
                {
                    this.data.Add(new Product());
                    string[] words = line.Split(' ');
                    if (words.Length != 7)
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    this.data[i].Name = words[0];
                    this.data[i].Unit = words[1];
                    double read_price = 0;
                    if (double.TryParse(words[2], out read_price))
                    {
                        this.data[i].Price = read_price;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    int read_amount = 0;
                    if (int.TryParse(words[3], out read_amount))
                    {
                        this.data[i].Amount = read_amount;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    int read_day;
                    if (int.TryParse(words[4], out read_day))
                    {
                        this.data[i].Date.Day = read_day;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    int read_month = 0;
                    if (int.TryParse(words[5], out read_month))
                    {
                        this.data[i].Date.Month = read_month;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    int read_year = 0;
                    if (int.TryParse(words[6], out read_year))
                    {
                        this.data[i].Date.Year = read_year;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    line = reader.ReadLine();
                    i++;
                }
                reader.Close();
            }
            catch (IncorrectDataException exept)
            {
                exept.ShowMessageBox();
            }
        }
        public void Save_file(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            this.data.ForEach(product => {
                this.write_data(writer, product.Name);
                this.write_data(writer, product.Unit);
                this.write_data(writer, product.Price);
                this.write_data(writer, product.Amount);
                this.write_data(writer, product.Date.Day);
                this.write_data(writer, product.Date.Month);
                writer.Write(product.Date.Year);
                writer.WriteLine();
            });
            writer.Close();
        }
        private void write_data(StreamWriter writer, object write_data)
        {
            writer.Write(write_data);
            writer.Write(" ");
        }
        public void Add_file(string path)
        {
            try
            {
                List<Product> data_read = new List<Product>();
                StreamReader reader = new StreamReader(path);
                string line = reader.ReadLine();
                int i = 0;
                while (line != "" && line != null)
                {
                    data_read.Add(new Product());
                    string[] words = line.Split(' ');
                    if (words.Length != 7)
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    data_read[i].Name = words[0];
                    data_read[i].Unit = words[1];
                    double read_price = 0;
                    if (double.TryParse(words[2], out read_price))
                    {
                        data_read[i].Price = read_price;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    int read_amount = 0;
                    if (int.TryParse(words[3], out read_amount))
                    {
                        data_read[i].Amount = read_amount;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    int read_day;
                    if (int.TryParse(words[4], out read_day))
                    {
                        data_read[i].Date.Day = read_day;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    int read_month = 0;
                    if (int.TryParse(words[5], out read_month))
                    {
                        data_read[i].Date.Month = read_month;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    int read_year = 0;
                    if (int.TryParse(words[6], out read_year))
                    {
                        data_read[i].Date.Year = read_year;
                    }
                    else
                    {
                        reader.Close();
                        throw new IncorrectDataException();
                    }
                    line = reader.ReadLine();
                    i++;
                }
                reader.Close();
                for(int j = 0; j < this.data.Count; j++)
                {
                    bool searched = false;
                    for(int k = 0; k < data_read.Count; k++)
                    {
                        if(this.data[j].Name == data_read[k].Name && this.data[j].Unit == data_read[k].Unit && this.data[j].Price == data_read[k].Price && this.data[j].Date.Day == data_read[k].Date.Day && this.data[j].Date.Month == data_read[k].Date.Month && this.data[j].Date.Year == data_read[k].Date.Year)
                        {
                            data_read[k].Amount += this.data[j].Amount;
                            searched = true;
                            break;
                        }
                    }
                    if (!searched)
                    {
                        data_read.Add(this.data[j]);
                    }
                }
                StreamWriter writer = new StreamWriter(path);
                data_read.ForEach(product => {
                    this.write_data(writer, product.Name);
                    this.write_data(writer, product.Unit);
                    this.write_data(writer, product.Price);
                    this.write_data(writer, product.Amount);
                    this.write_data(writer, product.Date.Day);
                    this.write_data(writer, product.Date.Month);
                    writer.Write(product.Date.Year);
                    writer.WriteLine();
                });
                writer.Close();
            }
            catch (IncorrectDataException exept)
            {
                exept.ShowMessageBox();
            }
        }
        public int Length
        {
            get
            {
                if (this.data == null)
                {
                    return 0;
                }
                return this.data.Count;
            }
        }
        public List<Product> Data { get { return this.data; } }
    }
}
