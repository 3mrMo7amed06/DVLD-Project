namespace DVLD.Forms.ManageApplication
{
    partial class frmReleaseLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleaseLicense));
            this.Lea = new System.Windows.Forms.Label();
            this.linkLabelShowHistory = new System.Windows.Forms.LinkLabel();
            this.linkLabelShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.btuClose = new System.Windows.Forms.Button();
            this.ctrReleaseLicenseInfo1 = new DVLD.UserControls.Applications.ctrReleaseLicenseInfo();
            this.ctrSearchLocalLicense1 = new DVLD.UserControls.Licenses.ctrSearchLocalLicense();
            this.SuspendLayout();
            // 
            // Lea
            // 
            this.Lea.AutoSize = true;
            this.Lea.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lea.ForeColor = System.Drawing.Color.Brown;
            this.Lea.Location = new System.Drawing.Point(176, 0);
            this.Lea.Name = "Lea";
            this.Lea.Size = new System.Drawing.Size(663, 60);
            this.Lea.TabIndex = 17;
            this.Lea.Text = "Release Detained License ";
            this.Lea.Click += new System.EventHandler(this.Lea_Click);
            // 
            // linkLabelShowHistory
            // 
            this.linkLabelShowHistory.AutoSize = true;
            this.linkLabelShowHistory.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.linkLabelShowHistory.ForeColor = System.Drawing.Color.Brown;
            this.linkLabelShowHistory.LinkColor = System.Drawing.Color.Brown;
            this.linkLabelShowHistory.Location = new System.Drawing.Point(3, 717);
            this.linkLabelShowHistory.Name = "linkLabelShowHistory";
            this.linkLabelShowHistory.Size = new System.Drawing.Size(202, 20);
            this.linkLabelShowHistory.TabIndex = 138;
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
            this.linkLabelShowLicenseInfo.Location = new System.Drawing.Point(225, 717);
            this.linkLabelShowLicenseInfo.Name = "linkLabelShowLicenseInfo";
            this.linkLabelShowLicenseInfo.Size = new System.Drawing.Size(165, 20);
            this.linkLabelShowLicenseInfo.TabIndex = 137;
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
            this.button1.Location = new System.Drawing.Point(845, 714);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 44);
            this.button1.TabIndex = 136;
            this.button1.Text = "Release";
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
            this.btuClose.Location = new System.Drawing.Point(726, 714);
            this.btuClose.Name = "btuClose";
            this.btuClose.Size = new System.Drawing.Size(113, 44);
            this.btuClose.TabIndex = 135;
            this.btuClose.Text = "Close";
            this.btuClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btuClose.UseVisualStyleBackColor = true;
            this.btuClose.Click += new System.EventHandler(this.btuClose_Click);
            // 
            // ctrReleaseLicenseInfo1
            // 
            this.ctrReleaseLicenseInfo1.Location = new System.Drawing.Point(1, 495);
            this.ctrReleaseLicenseInfo1.Name = "ctrReleaseLicenseInfo1";
            this.ctrReleaseLicenseInfo1.Size = new System.Drawing.Size(801, 199);
            this.ctrReleaseLicenseInfo1.TabIndex = 19;
            // 
            // ctrSearchLocalLicense1
            // 
            this.ctrSearchLocalLicense1.Location = new System.Drawing.Point(1, 63);
            this.ctrSearchLocalLicense1.Name = "ctrSearchLocalLicense1";
            this.ctrSearchLocalLicense1.RequireClass3 = true;
            this.ctrSearchLocalLicense1.Size = new System.Drawing.Size(983, 426);
            this.ctrSearchLocalLicense1.TabIndex = 18;
            this.ctrSearchLocalLicense1.Load += new System.EventHandler(this.ctrSearchLocalLicense1_Load);
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 769);
            this.Controls.Add(this.linkLabelShowHistory);
            this.Controls.Add(this.linkLabelShowLicenseInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btuClose);
            this.Controls.Add(this.ctrReleaseLicenseInfo1);
            this.Controls.Add(this.ctrSearchLocalLicense1);
            this.Controls.Add(this.Lea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReleaseLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Release License";
            this.Load += new System.EventHandler(this.frmReleaseLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Licenses.ctrSearchLocalLicense ctrSearchLocalLicense1;
        private System.Windows.Forms.Label Lea;
        private UserControls.Applications.ctrReleaseLicenseInfo ctrReleaseLicenseInfo1;
        private System.Windows.Forms.LinkLabel linkLabelShowHistory;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btuClose;
    }
}