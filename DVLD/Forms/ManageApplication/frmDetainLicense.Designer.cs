namespace DVLD.Forms.ManageApplication
{
    partial class frmDetainLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetainLicense));
            this.ctrSearchLocalLicense1 = new DVLD.UserControls.Licenses.ctrSearchLocalLicense();
            this.Lea = new System.Windows.Forms.Label();
            this.linkLabelShowHistory = new System.Windows.Forms.LinkLabel();
            this.linkLabelShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.btuClose = new System.Windows.Forms.Button();
            this.ctrDetainLicenseInfo1 = new DVLD.UserControls.Applications.ctrDetainLicenseInfo();
            this.SuspendLayout();
            // 
            // ctrSearchLocalLicense1
            // 
            this.ctrSearchLocalLicense1.Location = new System.Drawing.Point(3, 72);
            this.ctrSearchLocalLicense1.Name = "ctrSearchLocalLicense1";
            this.ctrSearchLocalLicense1.Size = new System.Drawing.Size(983, 426);
            this.ctrSearchLocalLicense1.TabIndex = 16;
            // 
            // Lea
            // 
            this.Lea.AutoSize = true;
            this.Lea.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lea.ForeColor = System.Drawing.Color.Brown;
            this.Lea.Location = new System.Drawing.Point(306, 9);
            this.Lea.Name = "Lea";
            this.Lea.Size = new System.Drawing.Size(398, 60);
            this.Lea.TabIndex = 15;
            this.Lea.Text = "Detain License ";
            this.Lea.Click += new System.EventHandler(this.Lea_Click);
            // 
            // linkLabelShowHistory
            // 
            this.linkLabelShowHistory.AutoSize = true;
            this.linkLabelShowHistory.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.linkLabelShowHistory.ForeColor = System.Drawing.Color.Brown;
            this.linkLabelShowHistory.LinkColor = System.Drawing.Color.Brown;
            this.linkLabelShowHistory.Location = new System.Drawing.Point(13, 662);
            this.linkLabelShowHistory.Name = "linkLabelShowHistory";
            this.linkLabelShowHistory.Size = new System.Drawing.Size(202, 20);
            this.linkLabelShowHistory.TabIndex = 134;
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
            this.linkLabelShowLicenseInfo.Location = new System.Drawing.Point(235, 662);
            this.linkLabelShowLicenseInfo.Name = "linkLabelShowLicenseInfo";
            this.linkLabelShowLicenseInfo.Size = new System.Drawing.Size(165, 20);
            this.linkLabelShowLicenseInfo.TabIndex = 133;
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
            this.button1.Location = new System.Drawing.Point(867, 659);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 44);
            this.button1.TabIndex = 132;
            this.button1.Text = "Detain";
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
            this.btuClose.Location = new System.Drawing.Point(736, 659);
            this.btuClose.Name = "btuClose";
            this.btuClose.Size = new System.Drawing.Size(113, 44);
            this.btuClose.TabIndex = 131;
            this.btuClose.Text = "Close";
            this.btuClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btuClose.UseVisualStyleBackColor = true;
            this.btuClose.Click += new System.EventHandler(this.btuClose_Click);
            // 
            // ctrDetainLicenseInfo1
            // 
            this.ctrDetainLicenseInfo1.Location = new System.Drawing.Point(3, 491);
            this.ctrDetainLicenseInfo1.Name = "ctrDetainLicenseInfo1";
            this.ctrDetainLicenseInfo1.Size = new System.Drawing.Size(762, 168);
            this.ctrDetainLicenseInfo1.TabIndex = 135;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 708);
            this.Controls.Add(this.ctrDetainLicenseInfo1);
            this.Controls.Add(this.linkLabelShowHistory);
            this.Controls.Add(this.linkLabelShowLicenseInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btuClose);
            this.Controls.Add(this.ctrSearchLocalLicense1);
            this.Controls.Add(this.Lea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detain License";
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserControls.Licenses.ctrSearchLocalLicense ctrSearchLocalLicense1;
        private System.Windows.Forms.Label Lea;
        private System.Windows.Forms.LinkLabel linkLabelShowHistory;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btuClose;
        private UserControls.Applications.ctrDetainLicenseInfo ctrDetainLicenseInfo1;
    }
}