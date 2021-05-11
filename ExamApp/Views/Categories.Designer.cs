
namespace ExamApp.Forms
{
    partial class Categories
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
            this.dgvCateg = new System.Windows.Forms.DataGridView();
            this.buttBack = new System.Windows.Forms.Button();
            this.butAddCat = new System.Windows.Forms.Button();
            this.textBoxCat = new System.Windows.Forms.TextBox();
            this.butCategDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCateg)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCateg
            // 
            this.dgvCateg.AllowUserToAddRows = false;
            this.dgvCateg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCateg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCateg.BackgroundColor = System.Drawing.Color.White;
            this.dgvCateg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCateg.Location = new System.Drawing.Point(1, 0);
            this.dgvCateg.MultiSelect = false;
            this.dgvCateg.Name = "dgvCateg";
            this.dgvCateg.ReadOnly = true;
            this.dgvCateg.Size = new System.Drawing.Size(424, 169);
            this.dgvCateg.TabIndex = 0;
            // 
            // buttBack
            // 
            this.buttBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttBack.BackColor = System.Drawing.Color.Purple;
            this.buttBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttBack.ForeColor = System.Drawing.Color.White;
            this.buttBack.Location = new System.Drawing.Point(304, 224);
            this.buttBack.Name = "buttBack";
            this.buttBack.Size = new System.Drawing.Size(92, 33);
            this.buttBack.TabIndex = 2;
            this.buttBack.Text = "Back";
            this.buttBack.UseVisualStyleBackColor = false;
            this.buttBack.Click += new System.EventHandler(this.ButtBack_Click);
            // 
            // butAddCat
            // 
            this.butAddCat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butAddCat.BackColor = System.Drawing.Color.Purple;
            this.butAddCat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddCat.ForeColor = System.Drawing.Color.White;
            this.butAddCat.Location = new System.Drawing.Point(27, 185);
            this.butAddCat.Name = "butAddCat";
            this.butAddCat.Size = new System.Drawing.Size(92, 33);
            this.butAddCat.TabIndex = 3;
            this.butAddCat.Text = "Add";
            this.butAddCat.UseVisualStyleBackColor = false;
            this.butAddCat.Click += new System.EventHandler(this.ButAddCat_Click);
            // 
            // textBoxCat
            // 
            this.textBoxCat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCat.Location = new System.Drawing.Point(125, 185);
            this.textBoxCat.MaxLength = 25;
            this.textBoxCat.Multiline = true;
            this.textBoxCat.Name = "textBoxCat";
            this.textBoxCat.Size = new System.Drawing.Size(271, 33);
            this.textBoxCat.TabIndex = 4;
            this.textBoxCat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxCat_KeyDown);
            // 
            // butCategDel
            // 
            this.butCategDel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCategDel.BackColor = System.Drawing.Color.Purple;
            this.butCategDel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCategDel.ForeColor = System.Drawing.Color.White;
            this.butCategDel.Location = new System.Drawing.Point(27, 224);
            this.butCategDel.Name = "butCategDel";
            this.butCategDel.Size = new System.Drawing.Size(92, 33);
            this.butCategDel.TabIndex = 5;
            this.butCategDel.Text = "Delete";
            this.butCategDel.UseVisualStyleBackColor = false;
            this.butCategDel.Click += new System.EventHandler(this.ButCategDel_Click);
            // 
            // Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(425, 267);
            this.Controls.Add(this.butCategDel);
            this.Controls.Add(this.textBoxCat);
            this.Controls.Add(this.butAddCat);
            this.Controls.Add(this.buttBack);
            this.Controls.Add(this.dgvCateg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(441, 306);
            this.Name = "Categories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Categories";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Categories_FormClosed);
            this.Load += new System.EventHandler(this.Categories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCateg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCateg;
        private System.Windows.Forms.Button buttBack;
        private System.Windows.Forms.Button butAddCat;
        private System.Windows.Forms.TextBox textBoxCat;
        private System.Windows.Forms.Button butCategDel;
    }
}