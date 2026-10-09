namespace DVLD
{
    partial class ctrVisionTestApplicationInfo
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
            this.ctrApplicationBasicInfo1 = new DVLD.ctrApplicationBasicInfo();
            this.ctrDLAInfo1 = new DVLD.ctrDLAInfo();
            this.SuspendLayout();
            // 
            // ctrApplicationBasicInfo1
            // 
            this.ctrApplicationBasicInfo1.Location = new System.Drawing.Point(3, 124);
            this.ctrApplicationBasicInfo1.Name = "ctrApplicationBasicInfo1";
            this.ctrApplicationBasicInfo1.Size = new System.Drawing.Size(1052, 229);
            this.ctrApplicationBasicInfo1.TabIndex = 1;
            this.ctrApplicationBasicInfo1.Load += new System.EventHandler(this.ctrApplicationBasicInfo1_Load);
            // 
            // ctrDLAInfo1
            // 
            this.ctrDLAInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrDLAInfo1.Name = "ctrDLAInfo1";
            this.ctrDLAInfo1.Size = new System.Drawing.Size(987, 124);
            this.ctrDLAInfo1.TabIndex = 0;
            this.ctrDLAInfo1.Load += new System.EventHandler(this.ctrDLAInfo1_Load);
            // 
            // ctrVisionTestApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrApplicationBasicInfo1);
            this.Controls.Add(this.ctrDLAInfo1);
            this.Name = "ctrVisionTestApplicationInfo";
            this.Size = new System.Drawing.Size(1072, 342);
            this.Load += new System.EventHandler(this.ctrVisionTestApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrDLAInfo ctrDLAInfo1;
        private ctrApplicationBasicInfo ctrApplicationBasicInfo1;
    }
}
