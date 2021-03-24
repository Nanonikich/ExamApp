
namespace ExamApp
{
    partial class MyUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProdN = new System.Windows.Forms.Label();
            this.ProdArt = new System.Windows.Forms.Label();
            this.ProdPri = new System.Windows.Forms.Label();
            this.ProdNalich = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProdN
            // 
            this.ProdN.Location = new System.Drawing.Point(3, 150);
            this.ProdN.Name = "ProdN";
            this.ProdN.Size = new System.Drawing.Size(100, 23);
            this.ProdN.TabIndex = 0;
            this.ProdN.Text = "label1";
            // 
            // ProdArt
            // 
            this.ProdArt.Location = new System.Drawing.Point(3, 173);
            this.ProdArt.Name = "ProdArt";
            this.ProdArt.Size = new System.Drawing.Size(100, 23);
            this.ProdArt.TabIndex = 1;
            this.ProdArt.Text = "label2";
            // 
            // ProdPri
            // 
            this.ProdPri.Location = new System.Drawing.Point(142, 196);
            this.ProdPri.Name = "ProdPri";
            this.ProdPri.Size = new System.Drawing.Size(92, 23);
            this.ProdPri.TabIndex = 2;
            this.ProdPri.Text = "label4";
            // 
            // ProdNalich
            // 
            this.ProdNalich.Location = new System.Drawing.Point(3, 196);
            this.ProdNalich.Name = "ProdNalich";
            this.ProdNalich.Size = new System.Drawing.Size(100, 23);
            this.ProdNalich.TabIndex = 3;
            this.ProdNalich.Text = "label3";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(20, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(197, 132);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // MyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.ProdNalich);
            this.Controls.Add(this.ProdPri);
            this.Controls.Add(this.ProdArt);
            this.Controls.Add(this.ProdN);
            this.Name = "MyUserControl";
            this.Size = new System.Drawing.Size(237, 235);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ProdN;
        private System.Windows.Forms.Label ProdArt;
        private System.Windows.Forms.Label ProdPri;
        private System.Windows.Forms.Label ProdNalich;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}
