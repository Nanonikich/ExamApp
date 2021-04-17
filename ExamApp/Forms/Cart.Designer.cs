
namespace ExamApp.Forms
{
    partial class Cart
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
            this.dgvCart = new System.Windows.Forms.DataGridView();
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
            this.EdProf = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bask_id,
            this.bask_img,
            this.bask_name,
            this.bask_count,
            this.bask_price,
            this.bask_customer,
            this.del_prod_basket});
            this.dgvCart.GridColor = System.Drawing.Color.Black;
            this.dgvCart.Location = new System.Drawing.Point(0, 42);
            this.dgvCart.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 100;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(800, 203);
            this.dgvCart.StandardTab = true;
            this.dgvCart.TabIndex = 11;
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCart_CellContentClick);
            this.dgvCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCart_CellValueChanged);
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
            this.butBack.BackColor = System.Drawing.Color.Purple;
            this.butBack.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butBack.ForeColor = System.Drawing.Color.White;
            this.butBack.Location = new System.Drawing.Point(436, 9);
            this.butBack.Name = "butBack";
            this.butBack.Size = new System.Drawing.Size(119, 41);
            this.butBack.TabIndex = 1;
            this.butBack.Text = "Back";
            this.butBack.UseVisualStyleBackColor = false;
            this.butBack.Click += new System.EventHandler(this.ButBack_Click);
            // 
            // butApply
            // 
            this.butApply.BackColor = System.Drawing.Color.Purple;
            this.butApply.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butApply.ForeColor = System.Drawing.Color.White;
            this.butApply.Location = new System.Drawing.Point(261, 9);
            this.butApply.Name = "butApply";
            this.butApply.Size = new System.Drawing.Size(119, 41);
            this.butApply.TabIndex = 12;
            this.butApply.Text = "Apply";
            this.butApply.UseVisualStyleBackColor = false;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotal.Location = new System.Drawing.Point(432, 255);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(59, 23);
            this.labelTotal.TabIndex = 14;
            this.labelTotal.Text = "Total:";
            // 
            // EdProf
            // 
            this.EdProf.BackColor = System.Drawing.Color.Blue;
            this.EdProf.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EdProf.ForeColor = System.Drawing.Color.White;
            this.EdProf.Location = new System.Drawing.Point(150, 104);
            this.EdProf.Name = "EdProf";
            this.EdProf.Size = new System.Drawing.Size(98, 36);
            this.EdProf.TabIndex = 15;
            this.EdProf.Text = "Edit Profile";
            this.EdProf.UseVisualStyleBackColor = false;
            this.EdProf.Click += new System.EventHandler(this.EdProf_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(364, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cart";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.butApply);
            this.panel2.Controls.Add(this.butBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 391);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 59);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.EdProf);
            this.panel3.Location = new System.Drawing.Point(0, 244);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(408, 159);
            this.panel3.TabIndex = 18;
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "Cart";
            this.Text = "Basket";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Basket_FormClosed);
            this.Load += new System.EventHandler(this.Basket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvCart;
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
        private System.Windows.Forms.Button EdProf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}