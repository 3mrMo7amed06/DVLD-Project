using DVLD.Business;
using DVLD.Forms.ManageApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        private DataTable _dtLocalDrivingLicenseApplications;
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void _UpdateRecordsCount()
        {
            lblRecords.Text = _dtLocalDrivingLicenseApplications.DefaultView.Count.ToString();
        }

        private void _RefreshLocalDrivingLicenseApplicationsList()
        {
            _dtLocalDrivingLicenseApplications =
                clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            dataGridView1.DataSource = _dtLocalDrivingLicenseApplications;

            _UpdateRecordsCount();
        }


        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();

            txtFilterValue.Visible = (cbFilterBy.SelectedIndex != 0);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string value = txtFilterValue.Text.Trim();
            if (cbFilterBy.SelectedIndex == 0 || value == "")
            {
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                _UpdateRecordsCount();
                return;
            }
            switch (cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    if (int.TryParse(value, out int AppID))
                        _dtLocalDrivingLicenseApplications.DefaultView.RowFilter =
                            $"LocalDrivingLicenseApplicationID = {AppID}";
                    else
                        _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                    break;

                case "National No.":
                    _dtLocalDrivingLicenseApplications.DefaultView.RowFilter =
                        $"NationalNo LIKE '%{value}%'";
                    break;

                case "FullName":
                    _dtLocalDrivingLicenseApplications.DefaultView.RowFilter =
                        $"FullName LIKE '%{value}%'";
                    break;
                case "Status":
                    _dtLocalDrivingLicenseApplications.DefaultView.RowFilter =
                        $"ApplicationStatus LIKE '%{value}%'";
                    break;

            }
            _UpdateRecordsCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "L.D.L.AppID")

            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication();

            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();

                dataGridView1.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(
                    dataGridView1,
                    dataGridView1.PointToClient(Cursor.Position));
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = Convert.ToInt32(
    dataGridView1.CurrentRow.Cells["colApplicationID"].Value);
            if (MessageBox.Show(
           "Are you sure you want to cancel this application?",
           "Confirm Cancel",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning)
            == DialogResult.Yes)
            {
                if (clsLocalDrivingLicenseApplication.CancelApplication(ApplicationID))
                {
                    MessageBox.Show(
                        "Application cancelled successfully.",
                        "Cancelled",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _RefreshLocalDrivingLicenseApplicationsList();
                }
                else
                {
                    MessageBox.Show(
                        "Application was not cancelled.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void scheduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void seheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID =
        Convert.ToInt32(
            dataGridView1.CurrentRow.Cells["colLocalDrivingLicenseApplicationID"].Value);

            frmVisionTestAppointments frm =
                new frmVisionTestAppointments(LocalDrivingLicenseApplicationID);

            frm.ShowDialog();

            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID =
        Convert.ToInt32(
            dataGridView1.CurrentRow
                .Cells["colLocalDrivingLicenseApplicationID"]
                .Value);

            string ApplicationStatus =
                dataGridView1.CurrentRow
                    .Cells["colApplicationStatus"]
                    .Value.ToString();

            bool IsCompleted =
                ApplicationStatus == "Completed";

            bool IsCancelled =
                ApplicationStatus == "Cancelled";

            bool VisionPassed =
                clsTest.IsTestPassed(
                    LocalDrivingLicenseApplicationID,
                    1);

            bool WrittenPassed =
                clsTest.IsTestPassed(
                    LocalDrivingLicenseApplicationID,
                    2);

            bool StreetPassed =
                clsTest.IsTestPassed(
                    LocalDrivingLicenseApplicationID,
                    3);

             
            seheduleVisionTestToolStripMenuItem.Enabled =
                !IsCompleted &&
                !IsCancelled &&
                !VisionPassed;

            seheduleWrittenTestToolStripMenuItem.Enabled =
                !IsCompleted &&
                !IsCancelled &&
                VisionPassed &&
                !WrittenPassed;

            seheduleStreetTestToolStripMenuItem.Enabled =
                !IsCompleted &&
                !IsCancelled &&
                VisionPassed &&
                WrittenPassed &&
                !StreetPassed;

            scheduleTestToolStripMenuItem.Enabled =
                !IsCompleted &&
                !IsCancelled &&
                !(VisionPassed &&
                  WrittenPassed &&
                  StreetPassed);

         
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled =
                !IsCompleted &&
                !IsCancelled &&
                VisionPassed &&
                WrittenPassed &&
                StreetPassed;

       
            showLicenseToolStripMenuItem.Enabled =
                IsCompleted;

            showPersonLicenseHistoryToolStripMenuItem.Enabled =
                IsCompleted;

           
            editToolStripMenuItem.Enabled =
                !IsCompleted &&
                !IsCancelled;

            cancelToolStripMenuItem.Enabled =
                !IsCompleted &&
                !IsCancelled;

            deleteToolStripMenuItem.Enabled =
                !IsCompleted &&
                !IsCancelled;
        }

        private void seheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID =
        Convert.ToInt32(
            dataGridView1.CurrentRow.Cells["colLocalDrivingLicenseApplicationID"].Value);

            frmWrittenTestAppointments frm =
                new frmWrittenTestAppointments(LocalDrivingLicenseApplicationID);

            frm.ShowDialog();

            _RefreshLocalDrivingLicenseApplicationsList();

        }

        private void seheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID =
          Convert.ToInt32(
              dataGridView1.CurrentRow
                  .Cells["colLocalDrivingLicenseApplicationID"]
                  .Value);

            frmStreetTestAppointments frm =
                new frmStreetTestAppointments(
                    LocalDrivingLicenseApplicationID);

            frm.ShowDialog();

            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        { 
                 int LocalDrivingLicenseApplicationID =
          Convert.ToInt32(
              dataGridView1.CurrentRow
                  .Cells["colLocalDrivingLicenseApplicationID"]
                  .Value);

            frmIssueDrivingLicense frm =
                new frmIssueDrivingLicense(
                    LocalDrivingLicenseApplicationID);

            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID =
        Convert.ToInt32(
            dataGridView1.CurrentRow
                .Cells["colApplicationID"]
                .Value);

            int LicenseID =
                clsLicense.GetLicenseIDByApplicationID(
                    ApplicationID);

            if (LicenseID == -1)
            {
                MessageBox.Show(
                    "License was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            frmShowLicense frm =
                new frmShowLicense(LicenseID);

            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID =
        Convert.ToInt32(
            dataGridView1.CurrentRow
                .Cells["colApplicationID"]
                .Value);

            clsApplication Application =
                clsApplication.Find(ApplicationID);

            if (Application == null)
            {
                MessageBox.Show(
                    "Application was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            frmPersonLicenseHistory frm =
                new frmPersonLicenseHistory(
                    Application.ApplicantPersonID);

            frm.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}