namespace ExamApp
{
    partial class FormLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLicense));
            this.labelAID = new System.Windows.Forms.Label();
            this.labelKeyID = new System.Windows.Forms.Label();
            this.labelLicense = new System.Windows.Forms.Label();
            this.textBoxAID = new System.Windows.Forms.TextBox();
            this.textBoxKeyID = new System.Windows.Forms.TextBox();
            this.linkLabelSaveV2C = new System.Windows.Forms.LinkLabel();
            this.labelUpdateStatus = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelContainerForLinkLabel = new System.Windows.Forms.Panel();
            this.panelContainer.SuspendLayout();
            this.panelContainerForLinkLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAID
            // 
            this.labelAID.AutoSize = true;
            this.labelAID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAID.Location = new System.Drawing.Point(6, 32);
            this.labelAID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAID.Name = "labelAID";
            this.labelAID.Size = new System.Drawing.Size(32, 13);
            this.labelAID.TabIndex = 0;
            this.labelAID.Text = "AID:";
            // 
            // labelKeyID
            // 
            this.labelKeyID.AutoSize = true;
            this.labelKeyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKeyID.Location = new System.Drawing.Point(6, 62);
            this.labelKeyID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelKeyID.Name = "labelKeyID";
            this.labelKeyID.Size = new System.Drawing.Size(45, 13);
            this.labelKeyID.TabIndex = 1;
            this.labelKeyID.Text = "KeyID:";
            // 
            // labelLicense
            // 
            this.labelLicense.AutoSize = true;
            this.labelLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLicense.Location = new System.Drawing.Point(6, 88);
            this.labelLicense.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(155, 13);
            this.labelLicense.TabIndex = 2;
            this.labelLicense.Text = "You can save the license:";
            // 
            // textBoxAID
            // 
            this.textBoxAID.Location = new System.Drawing.Point(42, 29);
            this.textBoxAID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxAID.Name = "textBoxAID";
            this.textBoxAID.ReadOnly = true;
            this.textBoxAID.Size = new System.Drawing.Size(266, 20);
            this.textBoxAID.TabIndex = 3;
            // 
            // textBoxKeyID
            // 
            this.textBoxKeyID.Location = new System.Drawing.Point(54, 59);
            this.textBoxKeyID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxKeyID.Name = "textBoxKeyID";
            this.textBoxKeyID.ReadOnly = true;
            this.textBoxKeyID.Size = new System.Drawing.Size(253, 20);
            this.textBoxKeyID.TabIndex = 4;
            // 
            // linkLabelSaveV2C
            // 
            this.linkLabelSaveV2C.AutoSize = true;
            this.linkLabelSaveV2C.Location = new System.Drawing.Point(23, 0);
            this.linkLabelSaveV2C.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelSaveV2C.Name = "linkLabelSaveV2C";
            this.linkLabelSaveV2C.Size = new System.Drawing.Size(55, 13);
            this.linkLabelSaveV2C.TabIndex = 5;
            this.linkLabelSaveV2C.TabStop = true;
            this.linkLabelSaveV2C.Text = "Save V2C";
            this.linkLabelSaveV2C.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSaveV2C_LinkClicked);
            // 
            // labelUpdateStatus
            // 
            this.labelUpdateStatus.AutoSize = true;
            this.labelUpdateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUpdateStatus.Location = new System.Drawing.Point(4, 4);
            this.labelUpdateStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUpdateStatus.Name = "labelUpdateStatus";
            this.labelUpdateStatus.Size = new System.Drawing.Size(100, 13);
            this.labelUpdateStatus.TabIndex = 6;
            this.labelUpdateStatus.Text = "Update Status...";
            this.labelUpdateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.labelUpdateStatus);
            this.panelContainer.Location = new System.Drawing.Point(6, 5);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(300, 20);
            this.panelContainer.TabIndex = 7;
            // 
            // panelContainerForLinkLabel
            // 
            this.panelContainerForLinkLabel.Controls.Add(this.linkLabelSaveV2C);
            this.panelContainerForLinkLabel.Location = new System.Drawing.Point(230, 88);
            this.panelContainerForLinkLabel.Margin = new System.Windows.Forms.Padding(2);
            this.panelContainerForLinkLabel.Name = "panelContainerForLinkLabel";
            this.panelContainerForLinkLabel.Size = new System.Drawing.Size(76, 19);
            this.panelContainerForLinkLabel.TabIndex = 8;
            // 
            // FormLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 113);
            this.Controls.Add(this.panelContainerForLinkLabel);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.textBoxKeyID);
            this.Controls.Add(this.textBoxAID);
            this.Controls.Add(this.labelLicense);
            this.Controls.Add(this.labelKeyID);
            this.Controls.Add(this.labelAID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximumSize = new System.Drawing.Size(333, 152);
            this.MinimumSize = new System.Drawing.Size(333, 152);
            this.Name = "FormLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License";
            this.Load += new System.EventHandler(this.FormLicense_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelContainerForLinkLabel.ResumeLayout(false);
            this.panelContainerForLinkLabel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAID;
        private System.Windows.Forms.Label labelKeyID;
        private System.Windows.Forms.Label labelLicense;
        private System.Windows.Forms.TextBox textBoxAID;
        private System.Windows.Forms.TextBox textBoxKeyID;
        private System.Windows.Forms.LinkLabel linkLabelSaveV2C;
        private System.Windows.Forms.Label labelUpdateStatus;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelContainerForLinkLabel;
    }
}