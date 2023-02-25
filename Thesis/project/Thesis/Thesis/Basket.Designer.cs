namespace Thesis
{
    partial class Basket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Basket));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_name,
            this.Product_unit,
            this.Product_price,
            this.Product_amount});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(523, 357);
            this.dataGridView1.TabIndex = 1;
            // 
            // Product_name
            // 
            this.Product_name.HeaderText = "Name";
            this.Product_name.Name = "Product_name";
            // 
            // Product_unit
            // 
            this.Product_unit.HeaderText = "Unit";
            this.Product_unit.Name = "Product_unit";
            // 
            // Product_price
            // 
            this.Product_price.HeaderText = "Price";
            this.Product_price.Name = "Product_price";
            // 
            // Product_amount
            // 
            this.Product_amount.HeaderText = "Amount";
            this.Product_amount.Name = "Product_amount";
            // 
            // Basket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 357);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Basket";
            this.Text = "Basket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Basket_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_amount;
    }
}