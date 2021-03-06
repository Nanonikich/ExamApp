
namespace ExamApp
{
    partial class AddProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProd));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxVC = new System.Windows.Forms.TextBox();
            this.textBoxNam = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.textBoxPr = new System.Windows.Forms.TextBox();
            this.buttAddPr = new System.Windows.Forms.Button();
            this.buttEdit = new System.Windows.Forms.Button();
            this.buttBack = new System.Windows.Forms.Button();
            this.buttonPict = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combBoxCateg = new System.Windows.Forms.ComboBox();
            this.butCategAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Наименование";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Артикул";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Описание";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Цена";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Картинка";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Категория";
            // 
            // textBoxVC
            // 
            this.textBoxVC.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxVC.Location = new System.Drawing.Point(120, 12);
            this.textBoxVC.MaxLength = 80;
            this.textBoxVC.Multiline = true;
            this.textBoxVC.Name = "textBoxVC";
            this.textBoxVC.Size = new System.Drawing.Size(196, 32);
            this.textBoxVC.TabIndex = 7;
            this.textBoxVC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxVC_KeyDown);
            this.textBoxVC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxVC_KeyPress);
            // 
            // textBoxNam
            // 
            this.textBoxNam.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNam.Location = new System.Drawing.Point(120, 50);
            this.textBoxNam.MaxLength = 150;
            this.textBoxNam.Multiline = true;
            this.textBoxNam.Name = "textBoxNam";
            this.textBoxNam.Size = new System.Drawing.Size(196, 32);
            this.textBoxNam.TabIndex = 8;
            this.textBoxNam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxVC_KeyDown);
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDesc.Location = new System.Drawing.Point(120, 88);
            this.textBoxDesc.Multiline = true;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(196, 32);
            this.textBoxDesc.TabIndex = 9;
            // 
            // textBoxPr
            // 
            this.textBoxPr.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPr.Location = new System.Drawing.Point(120, 127);
            this.textBoxPr.MaxLength = 18;
            this.textBoxPr.Multiline = true;
            this.textBoxPr.Name = "textBoxPr";
            this.textBoxPr.Size = new System.Drawing.Size(196, 32);
            this.textBoxPr.TabIndex = 10;
            this.textBoxPr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxVC_KeyDown);
            this.textBoxPr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxVC_KeyPress);
            // 
            // buttAddPr
            // 
            this.buttAddPr.BackColor = System.Drawing.Color.Purple;
            this.buttAddPr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttAddPr.ForeColor = System.Drawing.Color.White;
            this.buttAddPr.Location = new System.Drawing.Point(67, 343);
            this.buttAddPr.Name = "buttAddPr";
            this.buttAddPr.Size = new System.Drawing.Size(196, 34);
            this.buttAddPr.TabIndex = 15;
            this.buttAddPr.Text = "Добавить";
            this.buttAddPr.UseVisualStyleBackColor = false;
            this.buttAddPr.Click += new System.EventHandler(this.ButtAddPr_Click);
            // 
            // buttEdit
            // 
            this.buttEdit.BackColor = System.Drawing.Color.Purple;
            this.buttEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttEdit.ForeColor = System.Drawing.Color.White;
            this.buttEdit.Location = new System.Drawing.Point(67, 343);
            this.buttEdit.Name = "buttEdit";
            this.buttEdit.Size = new System.Drawing.Size(196, 34);
            this.buttEdit.TabIndex = 14;
            this.buttEdit.Text = "Изменить";
            this.buttEdit.UseVisualStyleBackColor = false;
            this.buttEdit.Click += new System.EventHandler(this.ButtEdit_Click);
            // 
            // buttBack
            // 
            this.buttBack.BackColor = System.Drawing.Color.Purple;
            this.buttBack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttBack.ForeColor = System.Drawing.Color.White;
            this.buttBack.Location = new System.Drawing.Point(67, 383);
            this.buttBack.Name = "buttBack";
            this.buttBack.Size = new System.Drawing.Size(196, 34);
            this.buttBack.TabIndex = 16;
            this.buttBack.Text = "Назад";
            this.buttBack.UseVisualStyleBackColor = false;
            this.buttBack.Click += new System.EventHandler(this.ButtBack_Click);
            // 
            // buttonPict
            // 
            this.buttonPict.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonPict.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPict.ForeColor = System.Drawing.Color.White;
            this.buttonPict.Location = new System.Drawing.Point(78, 240);
            this.buttonPict.Name = "buttonPict";
            this.buttonPict.Size = new System.Drawing.Size(36, 32);
            this.buttonPict.TabIndex = 14;
            this.buttonPict.Text = "In";
            this.buttonPict.UseVisualStyleBackColor = false;
            this.buttonPict.Click += new System.EventHandler(this.ButtonPict_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(120, 241);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(196, 92);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 18;
            this.pictureBox.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(2, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "200x200";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCount.Location = new System.Drawing.Point(120, 165);
            this.textBoxCount.MaxLength = 15;
            this.textBoxCount.Multiline = true;
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(196, 32);
            this.textBoxCount.TabIndex = 11;
            this.textBoxCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxVC_KeyDown);
            this.textBoxCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxVC_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 21;
            this.label5.Text = "Количество";
            // 
            // combBoxCateg
            // 
            this.combBoxCateg.BackColor = System.Drawing.Color.White;
            this.combBoxCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBoxCateg.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.combBoxCateg.FormattingEnabled = true;
            this.combBoxCateg.Location = new System.Drawing.Point(120, 204);
            this.combBoxCateg.Name = "combBoxCateg";
            this.combBoxCateg.Size = new System.Drawing.Size(196, 29);
            this.combBoxCateg.TabIndex = 13;
            // 
            // butCategAdd
            // 
            this.butCategAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.butCategAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCategAdd.ForeColor = System.Drawing.Color.White;
            this.butCategAdd.Location = new System.Drawing.Point(78, 204);
            this.butCategAdd.Name = "butCategAdd";
            this.butCategAdd.Size = new System.Drawing.Size(36, 29);
            this.butCategAdd.TabIndex = 12;
            this.butCategAdd.Text = "+";
            this.butCategAdd.UseVisualStyleBackColor = false;
            this.butCategAdd.Click += new System.EventHandler(this.ButCategAdd_Click);
            // 
            // AddProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(328, 425);
            this.Controls.Add(this.butCategAdd);
            this.Controls.Add(this.combBoxCateg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonPict);
            this.Controls.Add(this.buttBack);
            this.Controls.Add(this.buttAddPr);
            this.Controls.Add(this.textBoxPr);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.textBoxNam);
            this.Controls.Add(this.textBoxVC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AddProd";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddProd_FormClosed);
            this.Load += new System.EventHandler(this.AddProd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttBack;
        private System.Windows.Forms.Button buttonPict;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button buttEdit;
        public System.Windows.Forms.Button buttAddPr;
        public System.Windows.Forms.TextBox textBoxVC;
        public System.Windows.Forms.TextBox textBoxNam;
        public System.Windows.Forms.TextBox textBoxDesc;
        public System.Windows.Forms.TextBox textBoxPr;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxCount;
        public System.Windows.Forms.ComboBox combBoxCateg;
        private System.Windows.Forms.Button butCategAdd;
    }
}