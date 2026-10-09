namespace DVLD
{
    partial class ctrPersonSelect
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrPersonSelect));
            this.lnkEdit = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ctrFilter1 = new DVLD.ctrFilter();
            this.ctrPersonCard1 = new DVLD.ctrPersonCard();
            this.SuspendLayout();
            // 
            // lnkEdit
            // 
            this.lnkEdit.AutoSize = true;
            this.lnkEdit.Font = new System.Drawing.Font("Showcard Gothic", 14.25F);
            this.lnkEdit.LinkColor = System.Drawing.Color.Brown;
            this.lnkEdit.Location = new System.Drawing.Point(789, 205);
            this.lnkEdit.Name = "lnkEdit";
            this.lnkEdit.Size = new System.Drawing.Size(179, 23);
            this.lnkEdit.TabIndex = 34;
            this.lnkEdit.TabStop = true;
            this.lnkEdit.Text = "Edit Person Info";
            this.lnkEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEdit_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(636, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 34);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctrFilter1
            // 
            this.ctrFilter1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ctrFilter1.Location = new System.Drawing.Point(8, 3);
            this.ctrFilter1.Name = "ctrFilter1";
            this.ctrFilter1.Size = new System.Drawing.Size(624, 82);
            this.ctrFilter1.TabIndex = 33;
            this.ctrFilter1.Load += new System.EventHandler(this.ctrFilter1_Load);
            // 
            // ctrPersonCard1
            // 
            this.ctrPersonCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrPersonCard1.Location = new System.Drawing.Point(15, 73);
            this.ctrPersonCard1.Name = "ctrPersonCard1";
            this.ctrPersonCard1.Size = new System.Drawing.Size(967, 408);
            this.ctrPersonCard1.TabIndex = 32;
            this.ctrPersonCard1.Load += new System.EventHandler(this.ctrPersonCard1_Load);
            // 
            // ctrPersonSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lnkEdit);
            this.Controls.Add(this.ctrFilter1);
            this.Controls.Add(this.ctrPersonCard1);
            this.Name = "ctrPersonSelect";
            this.Size = new System.Drawing.Size(998, 481);
            this.Load += new System.EventHandler(this.ctrPersonSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.LinkLabel lnkEdit;
        private ctrFilter ctrFilter1;
        private ctrPersonCard ctrPersonCard1;
    }
}
