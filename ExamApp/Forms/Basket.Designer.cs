
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
            this.butBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBasket
            // 
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Location = new System.Drawing.Point(0, 0);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.Size = new System.Drawing.Size(800, 270);
            this.dgvBasket.TabIndex = 0;
            // 
            // butBack
            // 
            this.butBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butBack.ForeColor = System.Drawing.Color.White;
            this.butBack.Location = new System.Drawing.Point(321, 292);
            this.butBack.Name = "butBack";
            this.butBack.Size = new System.Drawing.Size(167, 78);
            this.butBack.TabIndex = 1;
            this.butBack.Text = "Back";
            this.butBack.UseVisualStyleBackColor = false;
            this.butBack.Click += new System.EventHandler(this.ButBack_Click);
            // 
            // Basket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butBack);
            this.Controls.Add(this.dgvBasket);
            this.Name = "Basket";
            this.Text = "Basket";
            this.Load += new System.EventHandler(this.Basket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.Button butBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn baskidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baskimgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn basknameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baskcountprodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baskpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baskcustomDataGridViewTextBoxColumn;
    }
}