
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
            this.EdProf = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.butBack = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.cart_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cart_img = new System.Windows.Forms.DataGridViewImageColumn();
            this.cart_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cart_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cart_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cart_cust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // EdProf
            // 
            this.EdProf.BackColor = System.Drawing.Color.Blue;
            this.EdProf.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EdProf.ForeColor = System.Drawing.Color.White;
            this.EdProf.Location = new System.Drawing.Point(43, 275);
            this.EdProf.Name = "EdProf";
            this.EdProf.Size = new System.Drawing.Size(92, 42);
            this.EdProf.TabIndex = 1;
            this.EdProf.Text = "Edit Profile";
            this.EdProf.UseVisualStyleBackColor = false;
            this.EdProf.Click += new System.EventHandler(this.EdProf_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(257, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // butBack
            // 
            this.butBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butBack.ForeColor = System.Drawing.Color.White;
            this.butBack.Location = new System.Drawing.Point(410, 391);
            this.butBack.Name = "butBack";
            this.butBack.Size = new System.Drawing.Size(121, 47);
            this.butBack.TabIndex = 3;
            this.butBack.Text = "Back";
            this.butBack.UseVisualStyleBackColor = false;
            this.butBack.Click += new System.EventHandler(this.ButBack_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotal.Location = new System.Drawing.Point(674, 217);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(42, 19);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "Total:";
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cart_id,
            this.cart_img,
            this.cart_name,
            this.cart_count,
            this.cart_price,
            this.cart_cust,
            this.DELETE});
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCart.Location = new System.Drawing.Point(0, 0);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowTemplate.Height = 110;
            this.dgvCart.Size = new System.Drawing.Size(800, 198);
            this.dgvCart.TabIndex = 5;
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCart_CellContentClick);
            // 
            // cart_id
            // 
            this.cart_id.HeaderText = "Id";
            this.cart_id.Name = "cart_id";
            this.cart_id.ReadOnly = true;
            // 
            // cart_img
            // 
            this.cart_img.HeaderText = "Image";
            this.cart_img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.cart_img.Name = "cart_img";
            this.cart_img.ReadOnly = true;
            // 
            // cart_name
            // 
            this.cart_name.HeaderText = "Name";
            this.cart_name.Name = "cart_name";
            this.cart_name.ReadOnly = true;
            // 
            // cart_count
            // 
            this.cart_count.HeaderText = "Count";
            this.cart_count.Name = "cart_count";
            // 
            // cart_price
            // 
            this.cart_price.HeaderText = "Price";
            this.cart_price.Name = "cart_price";
            this.cart_price.ReadOnly = true;
            // 
            // cart_cust
            // 
            this.cart_cust.HeaderText = "Buyer ID";
            this.cart_cust.Name = "cart_cust";
            this.cart_cust.ReadOnly = true;
            this.cart_cust.Visible = false;
            // 
            // DELETE
            // 
            this.DELETE.HeaderText = "Delete";
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DELETE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DELETE.Text = "DELETE";
            this.DELETE.UseColumnTextForButtonValue = true;
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.butBack);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EdProf);
            this.Name = "Cart";
            this.Text = "Cart";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Cart_FormClosed);
            this.Load += new System.EventHandler(this.Cart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button EdProf;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button butBack;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cart_id;
        private System.Windows.Forms.DataGridViewImageColumn cart_img;
        private System.Windows.Forms.DataGridViewTextBoxColumn cart_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cart_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn cart_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn cart_cust;
        private System.Windows.Forms.DataGridViewButtonColumn DELETE;
    }
}