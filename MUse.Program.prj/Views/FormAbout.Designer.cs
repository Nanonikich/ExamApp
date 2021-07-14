namespace ExamApp
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.buttonGetUpdateForApp = new System.Windows.Forms.Button();
            this.labelUpdateType = new System.Windows.Forms.Label();
            this.radioButtonByPK = new System.Windows.Forms.RadioButton();
            this.radioButtonByKeyID = new System.Windows.Forms.RadioButton();
            this.textBoxPK = new System.Windows.Forms.TextBox();
            this.buttonActivatePK = new System.Windows.Forms.Button();
            this.buttonGetUpdateByKeyID = new System.Windows.Forms.Button();
            this.labelLicenseInfo = new System.Windows.Forms.Label();
            this.textBoxLicenseInfo = new System.Windows.Forms.TextBox();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.buttonGetTrial = new System.Windows.Forms.Button();
            this.buttonCancelDetach = new System.Windows.Forms.Button();
            this.numericUpDownDaysForDetach = new System.Windows.Forms.NumericUpDown();
            this.labelNumberOfDaysForDetach = new System.Windows.Forms.Label();
            this.buttonDetach = new System.Windows.Forms.Button();
            this.buttonAddNewIbaStr = new System.Windows.Forms.Button();
            this.checkBoxAddNewIbaStr = new System.Windows.Forms.CheckBox();
            this.textBoxAddNewIbaStr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaysForDetach)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetUpdateForApp
            // 
            this.buttonGetUpdateForApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGetUpdateForApp.Location = new System.Drawing.Point(10, 254);
            this.buttonGetUpdateForApp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonGetUpdateForApp.Name = "buttonGetUpdateForApp";
            this.buttonGetUpdateForApp.Size = new System.Drawing.Size(354, 22);
            this.buttonGetUpdateForApp.TabIndex = 0;
            this.buttonGetUpdateForApp.Text = "Request update for app";
            this.buttonGetUpdateForApp.UseVisualStyleBackColor = true;
            this.buttonGetUpdateForApp.Click += new System.EventHandler(this.ButtonGetUpdateForApp_Click);
            // 
            // labelUpdateType
            // 
            this.labelUpdateType.AutoSize = true;
            this.labelUpdateType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUpdateType.Location = new System.Drawing.Point(9, 7);
            this.labelUpdateType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUpdateType.Name = "labelUpdateType";
            this.labelUpdateType.Size = new System.Drawing.Size(105, 13);
            this.labelUpdateType.TabIndex = 1;
            this.labelUpdateType.Text = "Activate/Update:";
            // 
            // radioButtonByPK
            // 
            this.radioButtonByPK.AutoSize = true;
            this.radioButtonByPK.Checked = true;
            this.radioButtonByPK.Location = new System.Drawing.Point(11, 28);
            this.radioButtonByPK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonByPK.Name = "radioButtonByPK";
            this.radioButtonByPK.Size = new System.Drawing.Size(57, 17);
            this.radioButtonByPK.TabIndex = 2;
            this.radioButtonByPK.TabStop = true;
            this.radioButtonByPK.Text = "By PK:";
            this.radioButtonByPK.UseVisualStyleBackColor = true;
            this.radioButtonByPK.CheckedChanged += new System.EventHandler(this.RadioButtonByPK_CheckedChanged);
            // 
            // radioButtonByKeyID
            // 
            this.radioButtonByKeyID.AutoSize = true;
            this.radioButtonByKeyID.Location = new System.Drawing.Point(12, 56);
            this.radioButtonByKeyID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonByKeyID.Name = "radioButtonByKeyID";
            this.radioButtonByKeyID.Size = new System.Drawing.Size(87, 17);
            this.radioButtonByKeyID.TabIndex = 3;
            this.radioButtonByKeyID.TabStop = true;
            this.radioButtonByKeyID.Text = "For exist key:";
            this.radioButtonByKeyID.UseVisualStyleBackColor = true;
            this.radioButtonByKeyID.CheckedChanged += new System.EventHandler(this.RadioButtonByKeyID_CheckedChanged);
            // 
            // textBoxPK
            // 
            this.textBoxPK.Location = new System.Drawing.Point(72, 26);
            this.textBoxPK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxPK.Name = "textBoxPK";
            this.textBoxPK.Size = new System.Drawing.Size(191, 20);
            this.textBoxPK.TabIndex = 4;
            // 
            // buttonActivatePK
            // 
            this.buttonActivatePK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonActivatePK.Location = new System.Drawing.Point(268, 25);
            this.buttonActivatePK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonActivatePK.Name = "buttonActivatePK";
            this.buttonActivatePK.Size = new System.Drawing.Size(95, 22);
            this.buttonActivatePK.TabIndex = 5;
            this.buttonActivatePK.Text = "Go";
            this.buttonActivatePK.UseVisualStyleBackColor = true;
            this.buttonActivatePK.Click += new System.EventHandler(this.ButtonActivatePK_Click);
            // 
            // buttonGetUpdateByKeyID
            // 
            this.buttonGetUpdateByKeyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGetUpdateByKeyID.Location = new System.Drawing.Point(268, 53);
            this.buttonGetUpdateByKeyID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonGetUpdateByKeyID.Name = "buttonGetUpdateByKeyID";
            this.buttonGetUpdateByKeyID.Size = new System.Drawing.Size(95, 22);
            this.buttonGetUpdateByKeyID.TabIndex = 6;
            this.buttonGetUpdateByKeyID.Text = "Check";
            this.buttonGetUpdateByKeyID.UseVisualStyleBackColor = true;
            this.buttonGetUpdateByKeyID.Click += new System.EventHandler(this.ButtonGetUpdateByKeyID_Click);
            // 
            // labelLicenseInfo
            // 
            this.labelLicenseInfo.AutoSize = true;
            this.labelLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLicenseInfo.Location = new System.Drawing.Point(11, 104);
            this.labelLicenseInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLicenseInfo.Name = "labelLicenseInfo";
            this.labelLicenseInfo.Size = new System.Drawing.Size(80, 13);
            this.labelLicenseInfo.TabIndex = 7;
            this.labelLicenseInfo.Text = "License info:";
            this.labelLicenseInfo.Visible = false;
            // 
            // textBoxLicenseInfo
            // 
            this.textBoxLicenseInfo.Location = new System.Drawing.Point(11, 120);
            this.textBoxLicenseInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxLicenseInfo.Multiline = true;
            this.textBoxLicenseInfo.Name = "textBoxLicenseInfo";
            this.textBoxLicenseInfo.ReadOnly = true;
            this.textBoxLicenseInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLicenseInfo.Size = new System.Drawing.Size(352, 59);
            this.textBoxLicenseInfo.TabIndex = 8;
            this.textBoxLicenseInfo.Visible = false;
            // 
            // labelCurrentVersion
            // 
            this.labelCurrentVersion.AutoSize = true;
            this.labelCurrentVersion.Location = new System.Drawing.Point(11, 279);
            this.labelCurrentVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            this.labelCurrentVersion.Size = new System.Drawing.Size(135, 13);
            this.labelCurrentVersion.TabIndex = 9;
            this.labelCurrentVersion.Text = "Current version application:";
            // 
            // buttonGetTrial
            // 
            this.buttonGetTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGetTrial.Location = new System.Drawing.Point(11, 80);
            this.buttonGetTrial.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGetTrial.Name = "buttonGetTrial";
            this.buttonGetTrial.Size = new System.Drawing.Size(352, 22);
            this.buttonGetTrial.TabIndex = 10;
            this.buttonGetTrial.Text = "Get Trial!";
            this.buttonGetTrial.UseVisualStyleBackColor = true;
            this.buttonGetTrial.Click += new System.EventHandler(this.ButtonGetTrial_Click);
            // 
            // buttonCancelDetach
            // 
            this.buttonCancelDetach.Enabled = false;
            this.buttonCancelDetach.Location = new System.Drawing.Point(299, 185);
            this.buttonCancelDetach.Name = "buttonCancelDetach";
            this.buttonCancelDetach.Size = new System.Drawing.Size(65, 22);
            this.buttonCancelDetach.TabIndex = 14;
            this.buttonCancelDetach.Text = "Return";
            this.buttonCancelDetach.UseVisualStyleBackColor = true;
            this.buttonCancelDetach.Visible = false;
            this.buttonCancelDetach.Click += new System.EventHandler(this.ButtonCancelDetach_Click);
            // 
            // numericUpDownDaysForDetach
            // 
            this.numericUpDownDaysForDetach.Enabled = false;
            this.numericUpDownDaysForDetach.Location = new System.Drawing.Point(168, 186);
            this.numericUpDownDaysForDetach.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownDaysForDetach.Maximum = new decimal(new int[] {
            9998,
            0,
            0,
            0});
            this.numericUpDownDaysForDetach.Name = "numericUpDownDaysForDetach";
            this.numericUpDownDaysForDetach.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownDaysForDetach.TabIndex = 13;
            this.numericUpDownDaysForDetach.Visible = false;
            // 
            // labelNumberOfDaysForDetach
            // 
            this.labelNumberOfDaysForDetach.AutoSize = true;
            this.labelNumberOfDaysForDetach.Enabled = false;
            this.labelNumberOfDaysForDetach.Location = new System.Drawing.Point(11, 190);
            this.labelNumberOfDaysForDetach.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumberOfDaysForDetach.Name = "labelNumberOfDaysForDetach";
            this.labelNumberOfDaysForDetach.Size = new System.Drawing.Size(133, 13);
            this.labelNumberOfDaysForDetach.TabIndex = 12;
            this.labelNumberOfDaysForDetach.Text = "Number of days for Cache:";
            this.labelNumberOfDaysForDetach.Visible = false;
            // 
            // buttonDetach
            // 
            this.buttonDetach.Enabled = false;
            this.buttonDetach.Location = new System.Drawing.Point(217, 185);
            this.buttonDetach.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDetach.Name = "buttonDetach";
            this.buttonDetach.Size = new System.Drawing.Size(77, 22);
            this.buttonDetach.TabIndex = 11;
            this.buttonDetach.Text = "Cache";
            this.buttonDetach.UseVisualStyleBackColor = true;
            this.buttonDetach.Visible = false;
            this.buttonDetach.Click += new System.EventHandler(this.ButtonDetach_Click);
            // 
            // buttonAddNewIbaStr
            // 
            this.buttonAddNewIbaStr.Enabled = false;
            this.buttonAddNewIbaStr.Location = new System.Drawing.Point(299, 213);
            this.buttonAddNewIbaStr.Name = "buttonAddNewIbaStr";
            this.buttonAddNewIbaStr.Size = new System.Drawing.Size(65, 22);
            this.buttonAddNewIbaStr.TabIndex = 15;
            this.buttonAddNewIbaStr.Text = "Add";
            this.buttonAddNewIbaStr.UseVisualStyleBackColor = true;
            this.buttonAddNewIbaStr.Visible = false;
            this.buttonAddNewIbaStr.Click += new System.EventHandler(this.ButtonAddNewIbaStr_Click);
            // 
            // checkBoxAddNewIbaStr
            // 
            this.checkBoxAddNewIbaStr.AutoSize = true;
            this.checkBoxAddNewIbaStr.Location = new System.Drawing.Point(12, 216);
            this.checkBoxAddNewIbaStr.Name = "checkBoxAddNewIbaStr";
            this.checkBoxAddNewIbaStr.Size = new System.Drawing.Size(119, 17);
            this.checkBoxAddNewIbaStr.TabIndex = 16;
            this.checkBoxAddNewIbaStr.Text = "Add new IBA string:";
            this.checkBoxAddNewIbaStr.UseVisualStyleBackColor = true;
            this.checkBoxAddNewIbaStr.Visible = false;
            this.checkBoxAddNewIbaStr.CheckedChanged += new System.EventHandler(this.CheckBoxAddNewIbaStr_CheckedChanged);
            // 
            // textBoxAddNewIbaStr
            // 
            this.textBoxAddNewIbaStr.Enabled = false;
            this.textBoxAddNewIbaStr.Location = new System.Drawing.Point(168, 214);
            this.textBoxAddNewIbaStr.Name = "textBoxAddNewIbaStr";
            this.textBoxAddNewIbaStr.Size = new System.Drawing.Size(126, 20);
            this.textBoxAddNewIbaStr.TabIndex = 17;
            this.textBoxAddNewIbaStr.Visible = false;
            this.textBoxAddNewIbaStr.TextChanged += new System.EventHandler(this.TextBoxAddNewIbaStr_TextChanged);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 301);
            this.Controls.Add(this.textBoxAddNewIbaStr);
            this.Controls.Add(this.checkBoxAddNewIbaStr);
            this.Controls.Add(this.buttonAddNewIbaStr);
            this.Controls.Add(this.buttonCancelDetach);
            this.Controls.Add(this.numericUpDownDaysForDetach);
            this.Controls.Add(this.labelNumberOfDaysForDetach);
            this.Controls.Add(this.buttonDetach);
            this.Controls.Add(this.buttonGetTrial);
            this.Controls.Add(this.labelCurrentVersion);
            this.Controls.Add(this.textBoxLicenseInfo);
            this.Controls.Add(this.labelLicenseInfo);
            this.Controls.Add(this.buttonGetUpdateByKeyID);
            this.Controls.Add(this.buttonActivatePK);
            this.Controls.Add(this.textBoxPK);
            this.Controls.Add(this.radioButtonByKeyID);
            this.Controls.Add(this.radioButtonByPK);
            this.Controls.Add(this.labelUpdateType);
            this.Controls.Add(this.buttonGetUpdateForApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximumSize = new System.Drawing.Size(390, 340);
            this.MinimumSize = new System.Drawing.Size(390, 340);
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAbout_FormClosing);
            this.Load += new System.EventHandler(this.FormAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaysForDetach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetUpdateForApp;
        private System.Windows.Forms.Label labelUpdateType;
        private System.Windows.Forms.RadioButton radioButtonByPK;
        private System.Windows.Forms.RadioButton radioButtonByKeyID;
        private System.Windows.Forms.TextBox textBoxPK;
        private System.Windows.Forms.Button buttonActivatePK;
        private System.Windows.Forms.Button buttonGetUpdateByKeyID;
        private System.Windows.Forms.Label labelLicenseInfo;
        private System.Windows.Forms.Label labelCurrentVersion;
        private System.Windows.Forms.Button buttonGetTrial;
        private System.Windows.Forms.Button buttonCancelDetach;
        private System.Windows.Forms.NumericUpDown numericUpDownDaysForDetach;
        private System.Windows.Forms.Label labelNumberOfDaysForDetach;
        private System.Windows.Forms.Button buttonDetach;
        private System.Windows.Forms.Button buttonAddNewIbaStr;
        private System.Windows.Forms.CheckBox checkBoxAddNewIbaStr;
        private System.Windows.Forms.TextBox textBoxAddNewIbaStr;
        public System.Windows.Forms.TextBox textBoxLicenseInfo;
    }
}