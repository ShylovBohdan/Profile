namespace Thesis
{
    partial class Bill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bill));
            this.ok_button = new System.Windows.Forms.Button();
            this.Your_bill = new System.Windows.Forms.Label();
            this.Products_text = new System.Windows.Forms.RichTextBox();
            this.Total = new System.Windows.Forms.Label();
            this.Sum = new System.Windows.Forms.Label();
            this.Thanks = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(117, 302);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 0;
            this.ok_button.Text = "Ok";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // Your_bill
            // 
            this.Your_bill.AutoSize = true;
            this.Your_bill.Location = new System.Drawing.Point(130, 9);
            this.Your_bill.Name = "Your_bill";
            this.Your_bill.Size = new System.Drawing.Size(50, 15);
            this.Your_bill.TabIndex = 1;
            this.Your_bill.Text = "Your bill";
            // 
            // Products_text
            // 
            this.Products_text.Location = new System.Drawing.Point(12, 35);
            this.Products_text.Name = "Products_text";
            this.Products_text.Size = new System.Drawing.Size(288, 195);
            this.Products_text.TabIndex = 2;
            this.Products_text.Text = "";
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(18, 255);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(33, 15);
            this.Total.TabIndex = 3;
            this.Total.Text = "Total";
            // 
            // Sum
            // 
            this.Sum.AutoSize = true;
            this.Sum.Location = new System.Drawing.Point(248, 255);
            this.Sum.Name = "Sum";
            this.Sum.Size = new System.Drawing.Size(0, 15);
            this.Sum.TabIndex = 4;
            // 
            // Thanks
            // 
            this.Thanks.AutoSize = true;
            this.Thanks.Location = new System.Drawing.Point(92, 284);
            this.Thanks.Name = "Thanks";
            this.Thanks.Size = new System.Drawing.Size(121, 15);
            this.Thanks.TabIndex = 5;
            this.Thanks.Text = "Thank you for buying";
            // 
            // Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 337);
            this.Controls.Add(this.Thanks);
            this.Controls.Add(this.Sum);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.Products_text);
            this.Controls.Add(this.Your_bill);
            this.Controls.Add(this.ok_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bill";
            this.Text = "Bill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Label Your_bill;
        private System.Windows.Forms.RichTextBox Products_text;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.Label Sum;
        private System.Windows.Forms.Label Thanks;
    }
}