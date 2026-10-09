namespace DVLD.Forms.ManageApplication
{
    partial class frmReplaceLostOrDamagedLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplaceLostOrDamagedLicense));
            this.lblReplacementReason = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.rdbDamaged = new System.Windows.Forms.RadioButton();
            this.rdbLost = new System.Windows.Forms.RadioButton();
            this.linkLabelShowHistory = new System.Windows.Forms.LinkLabel();
            this.linkLabelShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.btuClose = new System.Windows.Forms.Button();
            this.ctrReplaceLostOrDamagedLicenseApplicationInfo1 = new DVLD.UserControls.Licenses.ctrReplaceLostOrDamagedLicenseApplicationInfo();
            this.ctrSearchLocalLicense1 = new DVLD.UserControls.Licenses.ctrSearchLocalLicense();
            this.SuspendLayout();
            // 
            // lblReplacementReason
            // 
            this.lblReplacementReason.AutoSize = true;
            this.lblReplacementReason.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacementReason.ForeColor = System.Drawing.Color.Brown;
            this.lblReplacementReason.Location = new System.Drawing.Point(54, -3);
            this.lblReplacementReason.Name = "lblReplacementReason";
            this.lblReplacementReason.Size = new System.Drawing.Size(890, 60);
            this.lblReplacementReason.TabIndex = 13;
            this.lblReplacementReason.Text = "Replacement For Damaged license";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Brown;
            this.label19.Location = new System.Drawing.Point(675, 72);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(157, 20);
            this.label19.TabIndex = 38;
            this.label19.Text = "Replacement For";
            // 
            // rdbDamaged
            // 
            this.rdbDamaged.AutoSize = true;
            this.rdbDamaged.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.rdbDamaged.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rdbDamaged.Location = new System.Drawing.Point(693, 95);
            this.rdbDamaged.Name = "rdbDamaged";
            this.rdbDamaged.Size = new System.Drawing.Size(171, 24);
            this.rdbDamaged.TabIndex = 39;
            this.rdbDamaged.TabStop = true;
            this.rdbDamaged.Text = "Damaged License";
            this.rdbDamaged.UseVisualStyleBackColor = true;
            this.rdbDamaged.CheckedChanged += new System.EventHandler(this.rdbDamaged_CheckedChanged);
            // 
            // rdbLost
            // 
            this.rdbLost.AutoSize = true;
            this.rdbLost.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.rdbLost.ForeColor = System.Drawing.SystemColors.Highlight;
            this.rdbLost.Location = new System.Drawing.Point(693, 125);
            this.rdbLost.Name = "rdbLost";
            this.rdbLost.Size = new System.Drawing.Size(131, 24);
            this.rdbLost.TabIndex = 40;
            this.rdbLost.TabStop = true;
            this.rdbLost.Text = "Lost License";
            this.rdbLost.UseVisualStyleBackColor = true;
            this.rdbLost.CheckedChanged += new System.EventHandler(this.rdbLost_CheckedChanged);
            // 
            // linkLabelShowHistory
            // 
            this.linkLabelShowHistory.AutoSize = true;
            this.linkLabelShowHistory.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            this.linkLabelShowHistory.ForeColor = System.Drawing.Color.Brown;
            this.linkLabelShowHistory.LinkColor = System.Drawing.Color.Brown;
            this.linkLabelShowHistory.Location = new System.Drawing.Point(12, 673);
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
            this.linkLabelShowLicenseInfo.Location = new System.Drawing.Point(234, 673);
            this.linkLabelShowLicenseInfo.Name = "linkLabelShowLicenseInfo";
            this.linkLabelShowLicenseInfo.Size = new System.Drawing.Size(165, 20);
            this.linkLabelShowLicenseInfo.TabIndex = 133;
            this.linkLabelShowLicenseInfo.TabStop = true;
            this.linkLabelShowLicenseInfo.Text = "Show License Info";
            this.linkLabelShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseInfo_LinkClicked_1);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Brown;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(760, 673);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 44);
            this.button1.TabIndex = 132;
            this.button1.Text = "Issue Replacement";
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
            this.btuClose.Location = new System.Drawing.Point(626, 673);
            this.btuClose.Name = "btuClose";
            this.btuClose.Size = new System.Drawing.Size(113, 44);
            this.btuClose.TabIndex = 131;
            this.btuClose.Text = "Close";
            this.btuClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btuClose.UseVisualStyleBackColor = true;
            this.btuClose.Click += new System.EventHandler(this.btuClose_Click);
            // 
            // ctrReplaceLostOrDamagedLicenseApplicationInfo1
            // 
            this.ctrReplaceLostOrDamagedLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 504);
            this.ctrReplaceLostOrDamagedLicenseApplicationInfo1.Name = "ctrReplaceLostOrDamagedLicenseApplicationInfo1";
            this.ctrReplaceLostOrDamagedLicenseApplicationInfo1.Size = new System.Drawing.Size(875, 166);
            this.ctrReplaceLostOrDamagedLicenseApplicationInfo1.TabIndex = 135;
            // 
            // ctrSearchLocalLicense1
            // 
            this.ctrSearchLocalLicense1.Location = new System.Drawing.Point(0, 72);
            this.ctrSearchLocalLicense1.Name = "ctrSearchLocalLicense1";
            this.ctrSearchLocalLicense1.Size = new System.Drawing.Size(1046, 426);
            this.ctrSearchLocalLicense1.TabIndex = 37;
            this.ctrSearchLocalLicense1.Load += new System.EventHandler(this.ctrSearchLocalLicense1_Load);
            // 
            // frmReplaceLostOrDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 732);
            this.Controls.Add(this.ctrReplaceLostOrDamagedLicenseApplicationInfo1);
            this.Controls.Add(this.linkLabelShowHistory);
            this.Controls.Add(this.linkLabelShowLicenseInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btuClose);
            this.Controls.Add(this.rdbLost);
            this.Controls.Add(this.rdbDamaged);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.ctrSearchLocalLicense1);
            this.Controls.Add(this.lblReplacementReason);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplaceLostOrDamagedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace Lost Or Damaged License";
            this.Load += new System.EventHandler(this.frmReplaceLostOrDamagedLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReplacementReason;
        private UserControls.Licenses.ctrSearchLocalLicense ctrSearchLocalLicense1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton rdbDamaged;
        private System.Windows.Forms.RadioButton rdbLost;
        private System.Windows.Forms.LinkLabel linkLabelShowHistory;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btuClose;
        private UserControls.Licenses.ctrReplaceLostOrDamagedLicenseApplicationInfo ctrReplaceLostOrDamagedLicenseApplicationInfo1;
    }
}