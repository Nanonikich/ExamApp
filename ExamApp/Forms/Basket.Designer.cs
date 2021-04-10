
namespace ExamApp.Forms
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
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.bask_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bask_img = new System.Windows.Forms.DataGridViewImageColumn();
            this.bask_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bask_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bask_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bask_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_prod_basket = new System.Windows.Forms.DataGridViewButtonColumn();
            this.butBack = new System.Windows.Forms.Button();
            this.butApply = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBasket
            // 
            this.dgvBasket.AllowUserToAddRows = false;
            this.dgvBasket.AllowUserToDeleteRows = false;
            this.dgvBasket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bask_id,
            this.bask_img,
            this.bask_name,
            this.bask_count,
            this.bask_price,
            this.bask_customer,
            this.del_prod_basket});
            this.dgvBasket.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBasket.GridColor = System.Drawing.Color.Black;
            this.dgvBasket.Location = new System.Drawing.Point(0, 0);
            this.dgvBasket.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.RowHeadersWidth = 51;
            this.dgvBasket.RowTemplate.Height = 100;
            this.dgvBasket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBasket.Size = new System.Drawing.Size(800, 203);
            this.dgvBasket.StandardTab = true;
            this.dgvBasket.TabIndex = 11;
            this.dgvBasket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBasket_CellContentClick);
            // 
            // bask_id
            // 
            this.bask_id.HeaderText = "Id";
            this.bask_id.Name = "bask_id";
            this.bask_id.Visible = false;
            // 
            // bask_img
            // 
            this.bask_img.HeaderText = "Image";
            this.bask_img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.bask_img.Name = "bask_img";
            this.bask_img.ReadOnly = true;
            // 
            // bask_name
            // 
            this.bask_name.HeaderText = "Name";
            this.bask_name.Name = "bask_name";
            this.bask_name.ReadOnly = true;
            // 
            // bask_count
            // 
            this.bask_count.HeaderText = "Count";
            this.bask_count.Name = "bask_count";
            // 
            // bask_price
            // 
            this.bask_price.HeaderText = "Price";
            this.bask_price.Name = "bask_price";
            this.bask_price.ReadOnly = true;
            // 
            // bask_customer
            // 
            this.bask_customer.HeaderText = "Buyer ID";
            this.bask_customer.Name = "bask_customer";
            this.bask_customer.ReadOnly = true;
            this.bask_customer.Visible = false;
            // 
            // del_prod_basket
            // 
            this.del_prod_basket.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.del_prod_basket.HeaderText = "Delete";
            this.del_prod_basket.Name = "del_prod_basket";
            this.del_prod_basket.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.del_prod_basket.Text = "DELETE";
            this.del_prod_basket.UseColumnTextForButtonValue = true;
            // 
            // butBack
            // 
            this.butBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butBack.ForeColor = System.Drawing.Color.White;
            this.butBack.Location = new System.Drawing.Point(410, 391);
            this.butBack.Name = "butBack";
            this.butBack.Size = new System.Drawing.Size(121, 47);
            this.butBack.TabIndex = 1;
            this.butBack.Text = "Back";
            this.butBack.UseVisualStyleBackColor = false;
            this.butBack.Click += new System.EventHandler(this.ButBack_Click);
            // 
            // butApply
            // 
            this.butApply.BackColor = System.Drawing.Color.Green;
            this.butApply.ForeColor = System.Drawing.Color.White;
            this.butApply.Location = new System.Drawing.Point(257, 391);
            this.butApply.Name = "butApply";
            this.butApply.Size = new System.Drawing.Size(121, 47);
            this.butApply.TabIndex = 12;
            this.butApply.Text = "Apply";
            this.butApply.UseVisualStyleBackColor = false;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(674, 217);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(34, 13);
            this.labelTotal.TabIndex = 14;
            this.labelTotal.Text = "Total:";
            // 
            // Basket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.butApply);
            this.Controls.Add(this.butBack);
            this.Controls.Add(this.dgvBasket);
            this.Name = "Basket";
            this.Text = "Basket";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Basket_FormClosed);
            this.Load += new System.EventHandler(this.Basket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.Button butBack;
        private System.Windows.Forms.Button butApply;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn bask_id;
        private System.Windows.Forms.DataGridViewImageColumn bask_img;
        private System.Windows.Forms.DataGridViewTextBoxColumn bask_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bask_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn bask_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn bask_customer;
        private System.Windows.Forms.DataGridViewButtonColumn del_prod_basket;
    }
}