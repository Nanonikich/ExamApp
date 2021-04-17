
namespace ExamApp.Forms
{
    partial class DescripWindow
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
            this.labelName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labPr = new System.Windows.Forms.Label();
            this.labelArt = new System.Windows.Forms.Label();
            this.lab = new System.Windows.Forms.Label();
            this.labDescr = new System.Windows.Forms.Label();
            this.pictBoxDescr = new System.Windows.Forms.PictureBox();
            this.butShop = new System.Windows.Forms.Button();
            this.butBack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxDescr)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(21, 7);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(70, 27);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "label4";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelPrice);
            this.panel1.Controls.Add(this.labPr);
            this.panel1.Controls.Add(this.labelArt);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.lab);
            this.panel1.Controls.Add(this.labDescr);
            this.panel1.Controls.Add(this.pictBoxDescr);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 332);
            this.panel1.TabIndex = 1;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.Location = new System.Drawing.Point(354, 307);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(45, 19);
            this.labelPrice.TabIndex = 5;
            this.labelPrice.Text = "label6";
            // 
            // labPr
            // 
            this.labPr.AutoSize = true;
            this.labPr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labPr.Location = new System.Drawing.Point(305, 307);
            this.labPr.Name = "labPr";
            this.labPr.Size = new System.Drawing.Size(43, 19);
            this.labPr.TabIndex = 4;
            this.labPr.Text = "Price:";
            // 
            // labelArt
            // 
            this.labelArt.AutoSize = true;
            this.labelArt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelArt.Location = new System.Drawing.Point(673, 7);
            this.labelArt.Name = "labelArt";
            this.labelArt.Size = new System.Drawing.Size(45, 19);
            this.labelArt.TabIndex = 3;
            this.labelArt.Text = "label2";
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab.Location = new System.Drawing.Point(573, 7);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(94, 19);
            this.lab.TabIndex = 2;
            this.lab.Text = "Vendor Code:";
            // 
            // labDescr
            // 
            this.labDescr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labDescr.Location = new System.Drawing.Point(305, 35);
            this.labDescr.Name = "labDescr";
            this.labDescr.Size = new System.Drawing.Size(454, 267);
            this.labDescr.TabIndex = 1;
            this.labDescr.Text = "label5";
            // 
            // pictBoxDescr
            // 
            this.pictBoxDescr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictBoxDescr.Location = new System.Drawing.Point(26, 35);
            this.pictBoxDescr.Name = "pictBoxDescr";
            this.pictBoxDescr.Size = new System.Drawing.Size(256, 267);
            this.pictBoxDescr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBoxDescr.TabIndex = 0;
            this.pictBoxDescr.TabStop = false;
            // 
            // butShop
            // 
            this.butShop.BackColor = System.Drawing.Color.Purple;
            this.butShop.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butShop.ForeColor = System.Drawing.Color.White;
            this.butShop.Location = new System.Drawing.Point(268, 400);
            this.butShop.Name = "butShop";
            this.butShop.Size = new System.Drawing.Size(119, 41);
            this.butShop.TabIndex = 2;
            this.butShop.Text = "Buy";
            this.butShop.UseVisualStyleBackColor = false;
            this.butShop.Click += new System.EventHandler(this.ButShop_Click);
            // 
            // butBack
            // 
            this.butBack.BackColor = System.Drawing.Color.Purple;
            this.butBack.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butBack.ForeColor = System.Drawing.Color.White;
            this.butBack.Location = new System.Drawing.Point(431, 400);
            this.butBack.Name = "butBack";
            this.butBack.Size = new System.Drawing.Size(119, 41);
            this.butBack.TabIndex = 3;
            this.butBack.Text = "Back";
            this.butBack.UseVisualStyleBackColor = false;
            this.butBack.Click += new System.EventHandler(this.ButBack_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.butShop);
            this.panel2.Controls.Add(this.butBack);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 450);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(202, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Information about product";
            // 
            // DescripWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "DescripWindow";
            this.Text = "DescripWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DescripWindow_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxDescr)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butShop;
        private System.Windows.Forms.Button butBack;
        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.PictureBox pictBoxDescr;
        public System.Windows.Forms.Label labDescr;
        private System.Windows.Forms.Label lab;
        public System.Windows.Forms.Label labelArt;
        public System.Windows.Forms.Label labelPrice;
        public System.Windows.Forms.Label labPr;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}