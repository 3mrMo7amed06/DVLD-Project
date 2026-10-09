namespace DVLD
{
    partial class frmAddInternationalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddInternationalDrivingLicenseApplication));
            this.Lea = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btuClose = new System.Windows.Forms.Button();
            this.linkLabelShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.ctrInternationalLicenseApplicationInfo1 = new DVLD.UserControls.Licenses.ctrInternationalLicenseApplicationInfo();
            this.ctrSearchLocalLicense1 = new DVLD.UserControls.Licenses.ctrSearchLocalLicense();
            this.linkLabelShowInternationalLicense = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Lea
            // 
            this.Lea.AutoSize = true;
            this.Lea.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lea.ForeColor = System.Drawing.Color.Brown;
            this.Lea.Location = new System.Drawing.Point(90, 9);
            this.Lea.Name = "Lea";
            this.Lea.Size = new System.Drawing.Size(904, 60);
            this.Lea.TabIndex = 12;
            this.Lea.Text = "International License Application";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Brown;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(891, 707);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 44);
            this.button1.TabIndex = 124;
            this.button1.Text = "Issue";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btuClose
            // 
            this.btuClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btuClose.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btuClose.ForeColor = System.Drawing.Color.Brown;
            this.btuClose.Image = ((System.Drawing.Image)(resources.GetObject("btuClose.Image")));
            this.btuClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btuClose.Location = new System.Drawing.Point(782, 707);
            this.btuClose.Name = "btuClose";
            this.btuClose.Size = new System.Drawing.Size(103, 44);
            this.btuClose.TabIndex = 123;
            this.btuClose.Text = "Close";
            this.btuClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btuClose.UseVisualStyleBackColor = true;
            this.btuClose.Click += new System.EventHandler(this.btuClose_Click);
            // 
            // linkLabelShowLicenseInfo
            // 
            this.linkLabelShowLicenseInfo.AutoSize = true;
            this.linkLabelShowLicenseInfo.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.linkLabelShowLicenseInfo.ForeColor = System.Drawing.Color.Brown;
            this.linkLabelShowLicenseInfo.LinkColor = System.Drawing.Color.Brown;
            this.linkLabelShowLicenseInfo.Location = new System.Drawing.Point(216, 694);
            this.linkLabelShowLicenseInfo.Name = "linkLabelShowLicenseInfo";
            this.linkLabelShowLicenseInfo.Size = new System.Drawing.Size(165, 20);
            this.linkLabelShowLicenseInfo.TabIndex = 125;
            this.linkLabelShowLicenseInfo.TabStop = true;
            this.linkLabelShowLicenseInfo.Text = "Show License Info";
            this.linkLabelShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseInfo_LinkClicked);
            // 
            // ctrInternationalLicenseApplicationInfo1
            // 
            this.ctrInternationalLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 489);
            this.ctrInternationalLicenseApplicationInfo1.Name = "ctrInternationalLicenseApplicationInfo1";
            this.ctrInternationalLicenseApplicationInfo1.Size = new System.Drawing.Size(982, 202);
            this.ctrInternationalLicenseApplicationInfo1.TabIndex = 37;
            // 
            // ctrSearchLocalLicense1
            // 
            this.ctrSearchLocalLicense1.Location = new System.Drawing.Point(12, 72);
            this.ctrSearchLocalLicense1.Name = "ctrSearchLocalLicense1";
            this.ctrSearchLocalLicense1.Size = new System.Drawing.Size(1046, 426);
            this.ctrSearchLocalLicense1.TabIndex = 36;
            this.ctrSearchLocalLicense1.Load += new System.EventHandler(this.ctrSearchLocalLicense1_Load);
            // 
            // linkLabelShowInternationalLicense
            // 
            this.linkLabelShowInternationalLicense.AutoSize = true;
            this.linkLabelShowInternationalLicense.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.linkLabelShowInternationalLicense.ForeColor = System.Drawing.Color.Brown;
            this.linkLabelShowInternationalLicense.LinkColor = System.Drawing.Color.Brown;
            this.linkLabelShowInternationalLicense.Location = new System.Drawing.Point(8, 694);
            this.linkLabelShowInternationalLicense.Name = "linkLabelShowInternationalLicense";
            this.linkLabelShowInternationalLicense.Size = new System.Drawing.Size(202, 20);
            this.linkLabelShowInternationalLicense.TabIndex = 126;
            this.linkLabelShowInternationalLicense.TabStop = true;
            this.linkLabelShowInternationalLicense.Text = "Show History License ";
            this.linkLabelShowInternationalLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowInternationalLicense_LinkClicked);
            // 
            // frmAddInternationalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 763);
            this.Controls.Add(this.linkLabelShowInternationalLicense);
            this.Controls.Add(this.linkLabelShowLicenseInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btuClose);
            this.Controls.Add(this.ctrInternationalLicenseApplicationInfo1);
            this.Controls.Add(this.ctrSearchLocalLicense1);
            this.Controls.Add(this.Lea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddInternationalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New International Driving License Application";
            this.Load += new System.EventHandler(this.frmAddInternationalDrivingLicenseApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lea;
        private UserControls.Licenses.ctrSearchLocalLicense ctrSearchLocalLicense1;
        private UserControls.Licenses.ctrInternationalLicenseApplicationInfo ctrInternationalLicenseApplicationInfo1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btuClose;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLabelShowInternationalLicense;
    }
}