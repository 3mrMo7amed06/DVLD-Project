namespace DVLD
{
    partial class frmShowUserDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowUserDetail));
            this.lnkEdit = new System.Windows.Forms.LinkLabel();
            this.btuClose = new System.Windows.Forms.Button();
            this.ctrUserCard1 = new DVLD.ctrUserCard();
            this.ctrPersonCard1 = new DVLD.ctrPersonCard();
            this.SuspendLayout();
            // 
            // lnkEdit
            // 
            this.lnkEdit.AutoSize = true;
            this.lnkEdit.Font = new System.Drawing.Font("Showcard Gothic", 14.25F);
            this.lnkEdit.LinkColor = System.Drawing.Color.Brown;
            this.lnkEdit.Location = new System.Drawing.Point(772, 139);
            this.lnkEdit.Name = "lnkEdit";
            this.lnkEdit.Size = new System.Drawing.Size(179, 23);
            this.lnkEdit.TabIndex = 95;
            this.lnkEdit.TabStop = true;
            this.lnkEdit.Text = "Edit Person Info";
            this.lnkEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEdit_LinkClicked);
            // 
            // btuClose
            // 
            this.btuClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btuClose.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btuClose.ForeColor = System.Drawing.Color.Brown;
            this.btuClose.Image = ((System.Drawing.Image)(resources.GetObject("btuClose.Image")));
            this.btuClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btuClose.Location = new System.Drawing.Point(860, 491);
            this.btuClose.Name = "btuClose";
            this.btuClose.Size = new System.Drawing.Size(103, 44);
            this.btuClose.TabIndex = 94;
            this.btuClose.Text = "Close";
            this.btuClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btuClose.UseVisualStyleBackColor = true;
            this.btuClose.Click += new System.EventHandler(this.btuClose_Click);
            // 
            // ctrUserCard1
            // 
            this.ctrUserCard1.Location = new System.Drawing.Point(2, 397);
            this.ctrUserCard1.Name = "ctrUserCard1";
            this.ctrUserCard1.Size = new System.Drawing.Size(861, 85);
            this.ctrUserCard1.TabIndex = 1;
            this.ctrUserCard1.Load += new System.EventHandler(this.ctrUserCard1_Load);
            // 
            // ctrPersonCard1
            // 
            this.ctrPersonCard1.Location = new System.Drawing.Point(2, -3);
            this.ctrPersonCard1.Name = "ctrPersonCard1";
            this.ctrPersonCard1.Size = new System.Drawing.Size(994, 431);
            this.ctrPersonCard1.TabIndex = 0;
            // 
            // frmShowUserDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 547);
            this.Controls.Add(this.lnkEdit);
            this.Controls.Add(this.btuClose);
            this.Controls.Add(this.ctrUserCard1);
            this.Controls.Add(this.ctrPersonCard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowUserDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShowUserDetail";
            this.Load += new System.EventHandler(this.frmShowUserDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrPersonCard ctrPersonCard1;
        private ctrUserCard ctrUserCard1;
        private System.Windows.Forms.Button btuClose;
        private System.Windows.Forms.LinkLabel lnkEdit;
    }
}