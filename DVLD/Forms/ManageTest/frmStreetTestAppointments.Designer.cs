namespace DVLD
{
    partial class frmStreetTestAppointments
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStreetTestAppointments));
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.colAppointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctrStreetTestApplicationInfo1 = new DVLD.ctrVisionTestApplicationInfo();
            this.Lea = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btuClose = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToResizeColumns = false;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAppointmentID,
            this.colAppointmentDate,
            this.colPaidFees,
            this.colIsLocked});
            this.dgvAppointments.GridColor = System.Drawing.Color.White;
            this.dgvAppointments.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvAppointments.Location = new System.Drawing.Point(26, 579);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointments.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAppointments.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(891, 156);
            this.dgvAppointments.TabIndex = 114;
            this.dgvAppointments.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAppointments_CellMouseDown);
            // 
            // colAppointmentID
            // 
            this.colAppointmentID.DataPropertyName = "TestAppointmentID";
            this.colAppointmentID.HeaderText = "Appointment ID";
            this.colAppointmentID.Name = "colAppointmentID";
            this.colAppointmentID.ReadOnly = true;
            this.colAppointmentID.Width = 200;
            // 
            // colAppointmentDate
            // 
            this.colAppointmentDate.DataPropertyName = "AppointmentDate";
            this.colAppointmentDate.HeaderText = "Appointment Date";
            this.colAppointmentDate.Name = "colAppointmentDate";
            this.colAppointmentDate.ReadOnly = true;
            this.colAppointmentDate.Width = 200;
            // 
            // colPaidFees
            // 
            this.colPaidFees.DataPropertyName = "PaidFees";
            this.colPaidFees.HeaderText = "Paid Fees";
            this.colPaidFees.Name = "colPaidFees";
            this.colPaidFees.ReadOnly = true;
            this.colPaidFees.Width = 200;
            // 
            // colIsLocked
            // 
            this.colIsLocked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colIsLocked.DataPropertyName = "IsLocked";
            this.colIsLocked.HeaderText = "Is Locked";
            this.colIsLocked.Name = "colIsLocked";
            this.colIsLocked.ReadOnly = true;
            // 
            // ctrStreetTestApplicationInfo1
            // 
            this.ctrStreetTestApplicationInfo1.Location = new System.Drawing.Point(26, 201);
            this.ctrStreetTestApplicationInfo1.Name = "ctrStreetTestApplicationInfo1";
            this.ctrStreetTestApplicationInfo1.Size = new System.Drawing.Size(979, 340);
            this.ctrStreetTestApplicationInfo1.TabIndex = 113;
            this.ctrStreetTestApplicationInfo1.Load += new System.EventHandler(this.ctrStreetTestApplicationInfo1_Load);
            // 
            // Lea
            // 
            this.Lea.AutoSize = true;
            this.Lea.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lea.ForeColor = System.Drawing.Color.Brown;
            this.Lea.Location = new System.Drawing.Point(155, 138);
            this.Lea.Name = "Lea";
            this.Lea.Size = new System.Drawing.Size(684, 60);
            this.Lea.TabIndex = 111;
            this.Lea.Text = "Street test Appointments";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Brown;
            this.label19.Location = new System.Drawing.Point(22, 544);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 20);
            this.label19.TabIndex = 117;
            this.label19.Text = "Appointment";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showToolStripMenuItem.Image")));
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.showToolStripMenuItem.Text = "Edit Appointment";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("takeTestToolStripMenuItem.Image")));
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // btuClose
            // 
            this.btuClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btuClose.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btuClose.ForeColor = System.Drawing.Color.Brown;
            this.btuClose.Image = ((System.Drawing.Image)(resources.GetObject("btuClose.Image")));
            this.btuClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btuClose.Location = new System.Drawing.Point(801, 741);
            this.btuClose.Name = "btuClose";
            this.btuClose.Size = new System.Drawing.Size(116, 44);
            this.btuClose.TabIndex = 116;
            this.btuClose.Text = "Close";
            this.btuClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btuClose.UseVisualStyleBackColor = true;
            this.btuClose.Click += new System.EventHandler(this.btuClose_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(859, 532);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(58, 41);
            this.btnAddNew.TabIndex = 115;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(338, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 112;
            this.pictureBox1.TabStop = false;
            // 
            // frmStreetTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 809);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btuClose);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.ctrStreetTestApplicationInfo1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Lea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStreetTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Street Test Appointments";
            this.Load += new System.EventHandler(this.frmStreetTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btuClose;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidFees;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsLocked;
        private ctrVisionTestApplicationInfo ctrStreetTestApplicationInfo1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lea;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}