namespace DVLD.Forms.ManageApplication
{
    partial class frmRenewLocalDrivingLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRenewLocalDrivingLicense));
            this.Lea = new System.Windows.Forms.Label();
            this.ctrSearchLocalLicense1 = new DVLD.UserControls.Licenses.ctrSearchLocalLicense();
            this.ctrRenewLicenseApplicationInfo1 = new DVLD.UserControls.Licenses.ctrRenewLicenseApplicationInfo();
            this.linkLabelShowHistory = new System.Windows.Forms.LinkLabel();
            this.linkLabelShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.btuClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lea
            // 
            this.Lea.AutoSize = true;
            this.Lea.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lea.ForeColor = System.Drawing.Color.Brown;
            this.Lea.Location = new System.Drawing.Point(167, 9);
            this.Lea.Name = "Lea";
            this.Lea.Size = new System.Drawing.Size(703, 60);
            this.Lea.TabIndex = 12;
            this.Lea.Text = "Renew License Application";
            // 
            // ctrSearchLocalLicense1
            // 
            this.ctrSearchLocalLicense1.Location = new System.Drawing.Point(9, 63);
            this.ctrSearchLocalLicense1.Name = "ctrSearchLocalLicense1";
            this.ctrSearchLocalLicense1.Size = new System.Drawing.Size(981, 426);
            this.ctrSearchLocalLicense1.TabIndex = 13;
            // 
            // ctrRenewLicenseApplicationInfo1
            // 
            this.ctrRenewLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 495);
            this.ctrRenewLicenseApplicationInfo1.Name = "ctrRenewLicenseApplicationInfo1";
            this.ctrRenewLicenseApplicationInfo1.Size = new System.Drawing.Size(925, 367);
            this.ctrRenewLicenseApplicationInfo1.TabIndex = 14;
            // 
            // linkLabelShowHistory
            // 
            this.linkLabelShowHistory.AutoSize = true;
            this.linkLabelShowHistory.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.linkLabelShowHistory.ForeColor = System.Drawing.Color.Brown;
            this.linkLabelShowHistory.LinkColor = System.Drawing.Color.Brown;
            this.linkLabelShowHistory.Location = new System.Drawing.Point(8, 887);
            this.linkLabelShowHistory.Name = "linkLabelShowHistory";
            this.linkLabelShowHistory.Size = new System.Drawing.Size(202, 20);
            this.linkLabelShowHistory.TabIndex = 130;
            this.linkLabelShowHistory.TabStop = true;
            this.linkLabelShowHistory.Text = "Show History License ";
            this.linkLabelShowHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowHistory_LinkClicked);
            // 
            // linkLabelShowLicenseInfo
            // 
            this.linkLabelShowLicenseInfo.AutoSize = true;
            this.linkLabelShowLicenseInfo.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.linkLabelShowLicenseInfo.ForeColor = System.Drawing.Color.Brown;
            this.linkLabelShowLicenseInfo.LinkColor = System.Drawing.Color.Brown;
            this.linkLabelShowLicenseInfo.Location = new System.Drawing.Point(230, 887);
            this.linkLabelShowLicenseInfo.Name = "linkLabelShowLicenseInfo";
            this.linkLabelShowLicenseInfo.Size = new System.Drawing.Size(165, 20);
            this.linkLabelShowLicenseInfo.TabIndex = 129;
            this.linkLabelShowLicenseInfo.TabStop = true;
            this.linkLabelShowLicenseInfo.Text = "Show License Info";
            this.linkLabelShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseInfo_LinkClicked);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Brown;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(872, 887);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 44);
            this.button1.TabIndex = 128;
            this.button1.Text = "Renew";
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
            this.btuClose.Location = new System.Drawing.Point(741, 887);
            this.btuClose.Name = "btuClose";
            this.btuClose.Size = new System.Drawing.Size(113, 44);
            this.btuClose.TabIndex = 127;
            this.btuClose.Text = "Close";
            this.btuClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btuClose.UseVisualStyleBackColor = true;
            this.btuClose.Click += new System.EventHandler(this.btuClose_Click);
            // 
            // frmRenewLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 960);
            this.Controls.Add(this.linkLabelShowHistory);
            this.Controls.Add(this.linkLabelShowLicenseInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btuClose);
            this.Controls.Add(this.ctrRenewLicenseApplicationInfo1);
            this.Controls.Add(this.ctrSearchLocalLicense1);
            this.Controls.Add(this.Lea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRenewLocalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Renew Local Driving License";
            this.Load += new System.EventHandler(this.frmRenewLocalDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lea;
        private UserControls.Licenses.ctrSearchLocalLicense ctrSearchLocalLicense1;
        private UserControls.Licenses.ctrRenewLicenseApplicationInfo ctrRenewLicenseApplicationInfo1;
        private System.Windows.Forms.LinkLabel linkLabelShowHistory;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btuClose;
    }
}