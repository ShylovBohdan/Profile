using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Thesis
{
    
    public partial class Form1 : Form
    {
        private Basket Basket_window;
        private TextBox[] SearchBoxes;
        private TextBox[] RegisterBoxes;
        private TextBox[] FilterBoxes;
        private TextBox[] SellBoxes;
        private Product SearchData = new Product();
        private Product FilterData = new Product();
        private Products products = new Products();
        private Products basket = new Products();
        private Product SellData = new Product();
        private bool addBoxOpen = false;
        private bool filterBoxOpen = false;
        private bool searchBoxOpen = false;
        private bool sellBoxOpen = false;
        private bool helpOpen = false;
        private bool basketOpen = false;
        private bool filterOn = false;
        private bool searchOn = false;
        private bool aboutOpen = false;
        private Bill bill;
        private AboutUs aboutUs;
        private Help help;
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToAddRows = false;
            this.SearchBoxes = new TextBox[5];
            this.RegisterBoxes = new TextBox[5];
            this.FilterBoxes = new TextBox[5];
            this.SellBoxes = new TextBox[4];
            this.SearchBoxes[0] = this.Search_name_data;
            this.SearchBoxes[1] = this.Search_unit_data;
            this.SearchBoxes[2] = this.Search_price_data;
            this.SearchBoxes[3] = this.Search_amount_data;
            this.SearchBoxes[4] = this.Search_date_data;
            this.RegisterBoxes[0] = this.Registration_name_data;
            this.RegisterBoxes[1] = this.Registration_unit_data;
            this.RegisterBoxes[2] = this.Registration_price_data;
            this.RegisterBoxes[3] = this.Registration_amount_data;
            this.RegisterBoxes[4] = this.Registration_date_data;
            this.FilterBoxes[0] = this.Filter_name_data;
            this.FilterBoxes[1] = this.Filter_unit_data;
            this.FilterBoxes[2] = this.Filter_price_data;
            this.FilterBoxes[3] = this.Filter_amount_data;
            this.FilterBoxes[4] = this.Filter_date_data;
            this.SellBoxes[0] = this.Sell_name_data;
            this.SellBoxes[1] = this.Sell_unit_data;
            this.SellBoxes[2] = this.Sell_price_data;
            this.SellBoxes[3] = this.Sell_amount_data;
            this.dataGridView1.ReadOnly = true;
            this.addMenuItem.Image = Properties.Resources.add_closed;
            this.filterMenuItem.Image = Properties.Resources.adjust_closed;
            this.searchMenuItem.Image = Properties.Resources.search_closed;
            this.sellMenuItem.Image = Properties.Resources.sell_closed;
            this.basketMenuItem.Image = Properties.Resources.basket_closed;
            this.aboutUsMenuItem.Image = Properties.Resources.about_us_closed;
            this.helpMenuItem.Image = Properties.Resources.help_closed;
            this.splitContainer1.Panel1.Enabled = false;
            this.splitContainer2.Panel1.Enabled = false;
            this.splitContainer3.Panel1.Enabled = false;
            this.splitContainer3.Panel2.Enabled = false;
            this.splitContainer4.Panel1.Enabled = false;
            this.splitContainer4.Panel2.Enabled = false;
            this.splitContainer2.Panel1Collapsed = true;
            this.splitContainer3.Panel1Collapsed = true;
            this.splitContainer3.Panel2Collapsed = true;
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer4.Panel1Collapsed = true;
            this.splitContainer4.Panel2Collapsed = true;
            this.splitContainer2.SplitterDistance = this.splitContainer2.Width / 5;
            this.splitContainer2.Panel1.AutoScroll = true;
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            try
            {
                bool dataEmpty = false;
                for(int i = 0; i < this.SearchBoxes.Length; i++)
                {
                    if(SearchBoxes[i].Text == "")
                    {
                        dataEmpty = true;
                        break;
                    }
                }
                if (dataEmpty)
                {
                    throw new EmptySearchDataException();
                }
                try
                {
                    this.SearchData.Name = this.SearchBoxes[0].Text;
                    this.SearchData.Unit = this.SearchBoxes[1].Text;
                    double search_price = 0;
                    if (double.TryParse(this.SearchBoxes[2].Text, out search_price))
                    {
                        this.SearchData.Price = search_price;
                    }
                    else
                    {
                        throw new IncorrectSearchDataException();
                    }
                    int search_amount = 0;
                    if (int.TryParse(this.SearchBoxes[3].Text, out search_amount))
                    {
                        this.SearchData.Amount = search_amount;
                    }
                    else
                    {
                        throw new IncorrectSearchDataException();
                    }
                    string[] day_words = this.SearchBoxes[4].Text.Split('.');
                    if (day_words.Length != 3)
                    {
                        throw new IncorrectSearchDataException();
                    }
                    else
                    {
                        int[] day_int = new int[day_words.Length];
                        if (!int.TryParse(day_words[0], out day_int[0]))
                        {
                            throw new IncorrectSearchDataException();
                        }
                        if (!int.TryParse(day_words[1], out day_int[1]))
                        {
                            throw new IncorrectSearchDataException();
                        }
                        if (!int.TryParse(day_words[2], out day_int[2]))
                        {
                            throw new IncorrectSearchDataException();
                        }
                        if ((day_int[1] > 12) || (day_int[1] < 1))
                        {
                            throw new IncorrectSearchDataException();
                        }
                        if (day_int[2] < 1)
                        {
                            throw new IncorrectSearchDataException();
                        }
                        if (((day_int[1] == 2) && (day_int[2] % 4 != 0) && (day_int[0] > 28)) || ((day_int[1] == 2) && (day_int[2] % 4 == 0) && (day_int[0] > 29)) || (((day_int[1] == 1) || (day_int[1] == 3) || (day_int[1] == 5) || (day_int[1] == 7) || (day_int[1] == 8) || (day_int[1] == 10) || (day_int[1] == 12)) && day_int[0] > 31) || (((day_int[1] == 4) || (day_int[1] == 6) || (day_int[1] == 9) || (day_int[1] == 11)) && day_int[0] > 30) || day_int[0] < 1)
                        {
                            throw new IncorrectSearchDataException();
                        }
                        this.SearchData.Date.Day = day_int[0];
                        this.SearchData.Date.Month = day_int[1];
                        this.SearchData.Date.Year = day_int[2];
                    }
                    this.searchOn = true;
                    this.filterOn = false;
                    this.UpdateDataGrid();
                }
                catch (IncorrectSearchDataException exept)
                {
                    exept.ShowMessageBox();
                }

            }
            catch (EmptyDataException exept)
            {
                exept.ShowMessageBox();
            }
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.addBoxOpen)
            {
                this.splitContainer4.Panel1.Enabled = true;
                this.splitContainer4.Panel1Collapsed = false;
                this.addBoxOpen = true;
                this.addMenuItem.Image = Properties.Resources.add;
                if (!this.sellBoxOpen)
                {
                    this.splitContainer1.Panel1Collapsed = false;
                    this.splitContainer1.Panel1.Enabled = true;
                    this.splitContainer4.Panel2Collapsed = true;
                    this.splitContainer4.Panel2.Enabled = false;
                }
            }
            else
            {
                this.splitContainer4.Panel1Collapsed = true;
                this.splitContainer4.Panel1.Enabled = false;
                this.addBoxOpen = false;
                this.addMenuItem.Image = Properties.Resources.add_closed;
                if (!this.sellBoxOpen)
                {
                    this.splitContainer1.Panel1Collapsed = true;
                    this.splitContainer1.Panel1.Enabled = false;
                }
            }
        }

        private void searchMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.searchBoxOpen)
            {
                
                this.splitContainer3.Panel2Collapsed = false;
                this.splitContainer3.Panel2.Enabled = true;
                this.searchBoxOpen = true;
                this.searchMenuItem.Image = Properties.Resources.search;
                if (!this.filterBoxOpen)
                {
                    this.splitContainer2.Panel1Collapsed = false;
                    this.splitContainer2.Panel1.Enabled = true;
                    this.splitContainer3.Panel1Collapsed = true;
                    this.splitContainer3.Panel1.Enabled = false;
                }
            }
            else
            {
                this.splitContainer3.Panel2Collapsed = true;
                this.splitContainer3.Panel2.Enabled = false;
                this.searchBoxOpen = false;
                this.searchMenuItem.Image = Properties.Resources.search_closed;
                if (!this.filterBoxOpen)
                {
                    this.splitContainer2.Panel1Collapsed = true;
                    this.splitContainer2.Panel1.Enabled = false;
                }
            }
        }

        private void filterMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.filterBoxOpen)
            {
                this.splitContainer3.Panel1Collapsed = false;
                this.splitContainer3.Panel1.Enabled = true;
                this.filterBoxOpen = true;
                this.filterMenuItem.Image = Properties.Resources.adjust;
                if (!this.searchBoxOpen)
                {
                    this.splitContainer2.Panel1Collapsed = false;
                    this.splitContainer2.Panel1.Enabled = true;
                    this.splitContainer3.Panel2Collapsed = true;
                    this.splitContainer3.Panel2.Enabled = false;
                }
            }
            else
            {
                this.splitContainer3.Panel1Collapsed = true;
                this.splitContainer3.Panel1.Enabled = false;
                this.filterBoxOpen = false;
                this.filterMenuItem.Image = Properties.Resources.adjust_closed;
                if (!this.searchBoxOpen)
                {
                    this.splitContainer2.Panel1Collapsed = true;
                    this.splitContainer2.Panel1.Enabled = false;
                }
            }
        }

        private void sellMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.sellBoxOpen)
            {
                this.splitContainer4.Panel2.Enabled = true;
                this.splitContainer4.Panel2Collapsed = false;
                this.sellBoxOpen = true;
                this.sellMenuItem.Image = Properties.Resources.sell;
                if (!this.addBoxOpen)
                {
                    this.splitContainer1.Panel1Collapsed = false;
                    this.splitContainer1.Panel1.Enabled = true;
                    this.splitContainer4.Panel1Collapsed = true;
                    this.splitContainer4.Panel1.Enabled = false;
                }
            }
            else
            {
                this.splitContainer4.Panel2Collapsed = true;
                this.splitContainer4.Panel2.Enabled = false;
                this.sellBoxOpen = false;
                this.sellMenuItem.Image = Properties.Resources.sell_closed;
                if (!this.addBoxOpen)
                {
                    this.splitContainer1.Panel1Collapsed = true;
                    this.splitContainer1.Panel1.Enabled = false;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.OverwritePrompt = false;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(saveFileDialog.FileName != "")
                    {
                        path = saveFileDialog.FileName;
                    }
                }
            }
            this.products.Save_file(path);
        }

        private void saveAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.OverwritePrompt = false;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName != "")
                    {
                        path = saveFileDialog.FileName;
                    }
                }
            }
            this.products.Add_file(path);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(openFileDialog.FileName))
                        path = openFileDialog.FileName;
                }
            }
            this.products.Read_file(path);
            this.UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            this.dataGridView1.Rows.Clear();
            if (this.searchOn)
            {
                for(int i = 0; i < this.products.Data.Count; i++)
                {
                    bool searched = true;
                    if (this.products.Data[i].Name != this.SearchData.Name && this.SearchData.Name != "")
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Unit != this.SearchData.Unit && this.SearchData.Unit != "")
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Price != this.SearchData.Price && this.SearchData.Price != 0)
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Amount != this.SearchData.Amount && this.SearchData.Amount != 0)
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Date.Day != this.SearchData.Date.Day && this.SearchData.Date.Day != 0)
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Date.Month != this.SearchData.Date.Month && this.SearchData.Date.Month != 0)
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Date.Year != this.SearchData.Date.Year && this.SearchData.Date.Year != 0)
                    {
                        searched = false;
                    }
                    if (searched)
                    {
                        this.Add_product_To_DataGridView(this.products.Data[i]);
                    }
                }
            }
            else if (this.filterOn)
            {
                for (int i = 0; i < this.products.Data.Count; i++)
                {
                    bool searched = true;
                    if (this.products.Data[i].Name != this.FilterData.Name && this.FilterData.Name != "")
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Unit != this.FilterData.Unit && this.FilterData.Unit != "")
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Price != this.FilterData.Price && this.FilterData.Price != 0)
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Amount != this.FilterData.Amount && this.FilterData.Amount != 0)
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Date.Day != this.FilterData.Date.Day && this.FilterData.Date.Day != 0)
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Date.Month != this.FilterData.Date.Month && this.FilterData.Date.Month != 0)
                    {
                        searched = false;
                    }
                    if (this.products.Data[i].Date.Year != this.FilterData.Date.Year && this.FilterData.Date.Year != 0)
                    {
                        searched = false;
                    }
                    if (searched)
                    {
                        this.Add_product_To_DataGridView(this.products.Data[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.products.Data.Count; i++)
                {
                    this.Add_product_To_DataGridView(this.products.Data[i]);
                }
            }
        }
        private void Add_product_To_DataGridView(Product prod)
        {
            this.dataGridView1.Rows.Add(prod.Name, prod.Unit, prod.Price.ToString(), prod.Amount.ToString(), prod.Date.Day.ToString() + "." + prod.Date.Month.ToString() + "." + prod.Date.Year.ToString());
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            try
            {
                bool dataUnCorrect = false;
                for (int i = 0; i < this.RegisterBoxes.Length; i++)
                {
                    if (RegisterBoxes[i].Text == "")
                    {
                        dataUnCorrect = true;
                        break;
                    }
                }
                if (dataUnCorrect)
                {
                    throw new IncorrectRegisterDataException();
                }
                else
                {
                    try { 
                        Product new_prod = new Product();
                        new_prod.Name = this.RegisterBoxes[0].Text;
                        new_prod.Unit = this.RegisterBoxes[1].Text;
                        double register_price = 0;
                        if (double.TryParse(this.RegisterBoxes[2].Text, out register_price))
                        {
                            new_prod.Price = register_price;
                        }
                        else
                        {
                            throw new IncorrectRegisterDataException();
                        }
                        int register_amount = 0;
                        if (int.TryParse(this.RegisterBoxes[3].Text, out register_amount))
                        {
                            new_prod.Amount = register_amount;
                        }
                        else
                        {
                            throw new IncorrectRegisterDataException();
                        }
                        string[] day_words = this.RegisterBoxes[4].Text.Split('.');
                        if (day_words.Length != 3)
                        {
                            throw new IncorrectRegisterDataException();
                        }
                        else
                        {
                            int[] day_int = new int[day_words.Length];
                            if (!int.TryParse(day_words[0], out day_int[0]))
                            {
                                throw new IncorrectRegisterDataException();
                            }
                            if (!int.TryParse(day_words[1], out day_int[1]))
                            {
                                throw new IncorrectRegisterDataException();
                            }
                            if (!int.TryParse(day_words[2], out day_int[2]))
                            {
                                throw new IncorrectRegisterDataException();
                            }
                            if ((day_int[1] > 12) || (day_int[1] < 1))
                            {
                                throw new IncorrectRegisterDataException();
                            }
                            if (day_int[2] < 1)
                            {
                                throw new IncorrectRegisterDataException();
                            }
                            if (((day_int[1] == 2) && (day_int[2]%4!=0) && (day_int[0]>28))||((day_int[1] == 2) && (day_int[2] % 4 == 0) && (day_int[0] > 29)) || (((day_int[1] == 1)|| (day_int[1] == 3)|| (day_int[1] == 5)|| (day_int[1] == 7)|| (day_int[1] == 8)|| (day_int[1] == 10)|| (day_int[1] == 12)) && day_int[0] > 31) || (((day_int[1] == 4)|| (day_int[1] == 6)|| (day_int[1] == 9)|| (day_int[1] == 11)) && day_int[0] > 30) || day_int[0] < 1)
                            {
                                throw new IncorrectRegisterDataException();
                            }
                            new_prod.Date.Day = day_int[0];
                            new_prod.Date.Month = day_int[1];
                            new_prod.Date.Year = day_int[2];
                        }
                        bool productsExist = false;
                        if (this.products != null)
                        {
                            for (int i = 0; i < this.products.Length; i++)
                            {
                                if (this.products.Data[i].Name == new_prod.Name && this.products.Data[i].Unit == new_prod.Unit && this.products.Data[i].Price == new_prod.Price && this.products.Data[i].Date.Day == new_prod.Date.Day && this.products.Data[i].Date.Month == new_prod.Date.Month && this.products.Data[i].Date.Year == new_prod.Date.Year)
                                {
                                    this.products.Data[i].Amount += new_prod.Amount;
                                    productsExist = true;
                                    break;
                                }
                            }
                        }
                        if (!productsExist)
                        {
                            this.products.Add_product(new_prod);
                        }
                        this.UpdateDataGrid();
                    }
                    catch(IncorrectRegisterDataException exept)
                    {
                        exept.ShowMessageBox();
                    }
                }

            }
            catch (EmptyDataException exept)
            {
                exept.ShowMessageBox();
            }
        }

        private void Show_all_button_Click(object sender, EventArgs e)
        {
            this.searchOn = false;
            this.filterOn = false;
            this.UpdateDataGrid();
        }

        private void filter_button_Click(object sender, EventArgs e)
        {
            bool dataEmpty = true;
            for (int i = 0; i < this.FilterBoxes.Length; i++)
            {
                if (FilterBoxes[i].Text != "")
                {
                    dataEmpty = false;
                    break;
                }
            }
            if (dataEmpty)
            {
                this.searchOn = false;
                this.filterOn = false;
                this.UpdateDataGrid();
                return;
            }
            try
            {
                this.FilterData.Name = this.FilterBoxes[0].Text;
                this.FilterData.Unit = this.FilterBoxes[1].Text;
                double filter_price = 0;
                if (double.TryParse(this.FilterBoxes[2].Text, out filter_price))
                {
                    this.FilterData.Price = filter_price;
                }
                int filter_amount = 0;
                if (int.TryParse(this.FilterBoxes[3].Text, out filter_amount))
                {
                    this.FilterData.Amount = filter_amount;
                }
                string[] day_words = this.FilterBoxes[4].Text.Split('.');
                if (day_words.Length == 3 || (day_words.Length == 1 && day_words[0] == ""))
                {
                    if (day_words.Length == 3)
                    {
                        int[] day_int = new int[day_words.Length];
                        if (!int.TryParse(day_words[0], out day_int[0]))
                        {
                            throw new IncorrectFilterDataException();
                        }
                        if (!int.TryParse(day_words[1], out day_int[1]))
                        {
                            throw new IncorrectFilterDataException();
                        }
                        if (!int.TryParse(day_words[2], out day_int[2]))
                        {
                            throw new IncorrectFilterDataException();
                        }
                        if ((day_int[1] > 12) || (day_int[1] < 1))
                        {
                            throw new IncorrectFilterDataException();
                        }
                        if (day_int[2] < 1)
                        {
                            throw new IncorrectFilterDataException();
                        }
                        if (((day_int[1] == 2) && (day_int[2] % 4 != 0) && (day_int[0] > 28)) || ((day_int[1] == 2) && (day_int[2] % 4 == 0) && (day_int[0] > 29)) || (((day_int[1] == 1) || (day_int[1] == 3) || (day_int[1] == 5) || (day_int[1] == 7) || (day_int[1] == 8) || (day_int[1] == 10) || (day_int[1] == 12)) && day_int[0] > 31) || (((day_int[1] == 4) || (day_int[1] == 6) || (day_int[1] == 9) || (day_int[1] == 11)) && day_int[0] > 30) || day_int[0] < 1)
                        {
                            throw new IncorrectFilterDataException();
                        }
                        this.FilterData.Date.Day = day_int[0];
                        this.FilterData.Date.Month = day_int[1];
                        this.FilterData.Date.Year = day_int[2];
                    }
                }
                else
                {
                    throw new IncorrectFilterDataException();
                }
                this.searchOn = false;
                this.filterOn = true;
                this.UpdateDataGrid();
            }
            catch (IncorrectFilterDataException exept)
            {
                exept.ShowMessageBox();
            }
        }

        private void Write_off_button_Click(object sender, EventArgs e)
        {
            try
            {
                bool dataEmpty = false;
                for (int i = 0; i < this.SearchBoxes.Length; i++)
                {
                    if (SearchBoxes[i].Text == "")
                    {
                        dataEmpty = true;
                        break;
                    }
                }
                if (dataEmpty)
                {
                    throw new EmptySearchDataException();
                }
                try
                {
                    this.SearchData.Name = this.SearchBoxes[0].Text;
                    this.SearchData.Unit = this.SearchBoxes[1].Text;
                    double search_price = 0;
                    if (double.TryParse(this.SearchBoxes[2].Text, out search_price))
                    {
                        this.SearchData.Price = search_price;
                    }
                    else
                    {
                        throw new IncorrectWriteOffDataException();
                    }
                    int search_amount = 0;
                    if (int.TryParse(this.SearchBoxes[3].Text, out search_amount))
                    {
                        this.SearchData.Amount = search_amount;
                    }
                    else
                    {
                        throw new IncorrectWriteOffDataException();
                    }
                    string[] day_words = this.SearchBoxes[4].Text.Split('.');
                    if (day_words.Length != 3)
                    {
                        throw new IncorrectWriteOffDataException();
                    }
                    else
                    {
                        int[] day_int = new int[day_words.Length];
                        if (!int.TryParse(day_words[0], out day_int[0]))
                        {
                            throw new IncorrectWriteOffDataException();
                        }
                        if (!int.TryParse(day_words[1], out day_int[1]))
                        {
                            throw new IncorrectWriteOffDataException();
                        }
                        if (!int.TryParse(day_words[2], out day_int[2]))
                        {
                            throw new IncorrectWriteOffDataException();
                        }
                        if ((day_int[1] > 12) || (day_int[1] < 1))
                        {
                            throw new IncorrectWriteOffDataException();
                        }
                        if (day_int[2] < 1)
                        {
                            throw new IncorrectWriteOffDataException();
                        }
                        if (((day_int[1] == 2) && (day_int[2] % 4 != 0) && (day_int[0] > 28)) || ((day_int[1] == 2) && (day_int[2] % 4 == 0) && (day_int[0] > 29)) || (((day_int[1] == 1) || (day_int[1] == 3) || (day_int[1] == 5) || (day_int[1] == 7) || (day_int[1] == 8) || (day_int[1] == 10) || (day_int[1] == 12)) && day_int[0] > 31) || (((day_int[1] == 4) || (day_int[1] == 6) || (day_int[1] == 9) || (day_int[1] == 11)) && day_int[0] > 30) || day_int[0] < 1)
                        {
                            throw new IncorrectWriteOffDataException();
                        }
                        this.SearchData.Date.Day = day_int[0];
                        this.SearchData.Date.Month = day_int[1];
                        this.SearchData.Date.Year = day_int[2];
                    }
                    bool exist_product = false;
                    for(int i = 0; i < this.products.Data.Count; i++)
                    {
                        if (this.products.Data[i].Name == this.SearchData.Name&& this.products.Data[i].Unit == this.SearchData.Unit && this.products.Data[i].Price == this.SearchData.Price && this.products.Data[i].Date.Day == this.SearchData.Date.Day && this.products.Data[i].Date.Month == this.SearchData.Date.Month && this.products.Data[i].Date.Year == this.SearchData.Date.Year)
                        {
                            if (this.products.Data[i].Amount >= this.SearchData.Amount)
                            {
                                this.products.Data[i].Amount -= this.SearchData.Amount;
                                if(this.products.Data[i].Amount <= 0)
                                {
                                    this.products.Data.Remove(this.products.Data[i]);
                                }
                                exist_product = true;
                            }
                            else
                            {
                                throw new NotEnoughAmount();
                            }
                        }
                    }
                    if (!exist_product)
                    {
                        throw new IncorrectWriteOffDataException();
                    }
                    this.UpdateDataGrid();
                }
                catch (IncorrectWriteOffDataException exept)
                {
                    exept.ShowMessageBox();
                }
                catch(NotEnoughAmount exept)
                {
                    exept.ShowMessageBox();
                }

            }
            catch (EmptyDataException exept)
            {
                exept.ShowMessageBox();
            }
        }

        private void Count_sum_button_Click(object sender, EventArgs e)
        {
            double sum = 0;
            for(int i = 0; i < this.products.Data.Count; i++)
            {
                sum += this.products.Data[i].Price * this.products.Data[i].Amount;
            }
            MessageBox.Show("Sum: "+sum.ToString(), "Product sum", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Add_basket_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.SellData = new Product();
                bool dataEmpty = false;
                for (int i = 0; i < this.SellBoxes.Length; i++)
                {
                    if (SellBoxes[i].Text == "")
                    {
                        dataEmpty = true;
                        break;
                    }
                }
                if (dataEmpty)
                {
                    throw new IncorrectSellDataException();
                }
                this.SellData.Name = this.SellBoxes[0].Text;
                this.SellData.Unit = this.SellBoxes[1].Text;
                double sell_price = 0;
                if (double.TryParse(this.SellBoxes[2].Text, out sell_price))
                {
                    this.SellData.Price = sell_price;
                }
                else
                {
                    throw new IncorrectSellDataException();
                }
                int sell_amount = 0;
                if (int.TryParse(this.SellBoxes[3].Text, out sell_amount))
                {
                    this.SellData.Amount = sell_amount;
                }
                else
                {
                    throw new IncorrectSellDataException();
                }
                int sell_all_amount = this.SellData.Amount;
                bool exist = false;
                for (int i = 0; i < this.basket.Data.Count; i++)
                {
                    if (this.basket.Data[i].Name == this.SellData.Name && this.basket.Data[i].Unit == this.SellData.Unit && this.basket.Data[i].Price == this.SellData.Price)
                    {
                        exist = true;
                        sell_all_amount += this.basket.Data[i].Amount;
                    }
                }
                bool exist_product = false;
                int product_all_amount = 0;
                for (int i = 0; i < this.products.Data.Count; i++)
                {
                    if (this.products.Data[i].Name == this.SellData.Name && this.products.Data[i].Unit == this.SellData.Unit && this.products.Data[i].Price == this.SellData.Price)
                    {
                        product_all_amount += this.products.Data[i].Amount;
                        exist_product = true;
                    }
                }
                if (!exist_product)
                {
                    throw new IncorrectSellDataException();
                }
                if (product_all_amount < sell_all_amount)
                {
                    throw new NotEnoughAmount();
                }
                else
                {
                    if (exist)
                    {
                        for (int i = 0; i < this.basket.Data.Count; i++)
                        {
                            if (this.basket.Data[i].Name == this.SellData.Name && this.basket.Data[i].Unit == this.SellData.Unit && this.basket.Data[i].Price == this.SellData.Price)
                            {
                                this.basket.Data[i].Amount += this.SellData.Amount;
                                break;
                            }
                        }
                    }
                    else
                    {
                        this.basket.Add_product(this.SellData);
                    }
                }
                if (this.Basket_window != null)
                {
                    this.Basket_window.updateBasketDataGrid(this.basket);
                }
            }
            catch (NotEnoughAmount exept)
            {
                exept.ShowMessageBox();
            }
            catch (IncorrectSellDataException exept)
            {
                exept.ShowMessageBox();
            }
        }

        private void Sell_button_Click(object sender, EventArgs e)
        {
            try
            {
                string bill_text = "";
                double sum = 0;
                for (int i = 0; i < this.basket.Data.Count; i++)
                {
                    int current_amount = this.basket.Data[i].Amount;
                    for(int j = 0; j < this.products.Data.Count; j++)
                    {
                        if (this.products.Data[j].Name == this.basket.Data[i].Name && this.products.Data[j].Unit == this.basket.Data[i].Unit && this.products.Data[j].Price == this.basket.Data[i].Price)
                        {
                            if (this.products.Data[j].Amount < current_amount)
                            {
                                current_amount -= this.products.Data[j].Amount;
                                this.products.Data[j].Amount = 0;
                                this.products.Data.Remove(this.products.Data[j]);
                                j--;
                            }
                            else if(this.products.Data[j].Amount == current_amount)
                            {
                                current_amount -= this.products.Data[j].Amount;
                                this.products.Data[j].Amount = 0;
                                this.products.Data.Remove(this.products.Data[j]);
                                break;
                            }
                            else
                            {
                                this.products.Data[j].Amount -= current_amount;
                                current_amount = 0;
                                break;
                            }
                        }
                    }
                    if(current_amount > 0)
                    {
                        throw new NotEnoughAmount();
                    }
                    else
                    {
                        sum += this.basket.Data[i].Price * this.basket.Data[i].Amount;
                        bill_text += this.basket.Data[i].Name + "\t" + this.basket.Data[i].Unit + "\t" + this.basket.Data[i].Price.ToString() + "\t" + this.basket.Data[i].Amount.ToString() + "\t" + (this.basket.Data[i].Price * this.basket.Data[i].Amount).ToString()+"\n";
                    }
                }
                this.basket.Data.Clear();
                if (this.Basket_window != null)
                {
                    this.Basket_window.updateBasketDataGrid(this.basket);
                }
                this.UpdateDataGrid();
                this.bill = new Bill(bill_text, sum);
                this.bill.Show();
            }
            catch (NotEnoughAmount exept)
            {
                exept.ShowMessageBox();
            }
        }

        private void basketMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.basketOpen)
            {
                this.Basket_window = new Basket(this);
                this.Basket_window.Show();
                this.Basket_window.updateBasketDataGrid(this.basket);
                this.basketMenuItem.Image = Properties.Resources.basket;
                this.basketOpen = true;
            }
            else
            {
                if(this.Basket_window != null)
                {
                    this.Basket_window.Close();
                    this.basketMenuItem.Image = Properties.Resources.basket_closed;
                    this.basketOpen = false;
                }
            }
        }
        public void basket_closing()
        {
            this.basketMenuItem.Image = Properties.Resources.basket_closed;
        }
        public void about_us_closing()
        {
            this.aboutUsMenuItem.Image = Properties.Resources.about_us_closed;
            this.aboutOpen = false;
        }

        private void aboutUsMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.aboutOpen)
            {
                this.aboutUsMenuItem.Image = Properties.Resources.about_us;
                this.aboutUs = new AboutUs(this);
                this.aboutUs.Show();
                this.aboutOpen = true;
            }
            else
            {
                this.aboutUsMenuItem.Image = Properties.Resources.about_us_closed;
                if(this.aboutUs != null)
                {
                    this.aboutUs.Close();
                }
                this.aboutOpen = false;
            }
        }
        public void help_closing()
        {
            this.helpMenuItem.Image = Properties.Resources.help_closed;
        }

        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.helpOpen)
            {
                this.helpMenuItem.Image = Properties.Resources.help;
                this.help = new Help(this);
                this.help.Show();
                this.helpOpen = true;
            }
            else
            {
                this.helpOpen = false;
                this.helpMenuItem.Image = Properties.Resources.help_closed;
                if(this.help != null)
                {
                    this.help.Close();
                }
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            this.products.Data.Clear();
            this.basket.Data.Clear();
            this.UpdateDataGrid();
            if(this.Basket_window!= null)
            {
                this.Basket_window.updateBasketDataGrid(this.basket);
            }
            this.searchOn = false;
            this.filterOn = false;
        }
    }
}
