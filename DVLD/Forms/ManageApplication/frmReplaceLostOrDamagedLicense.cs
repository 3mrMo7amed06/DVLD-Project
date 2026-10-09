using DVLD.Business;
using DVLD.UserControls.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Forms.ManageApplication
{
    public partial class frmReplaceLostOrDamagedLicense : Form
    {
        private int _OldLicenseID = -1;
        private int _DriverID = -1;
        private int _PersonID = -1;
        private DateTime _ApplicationDate;
        private int _ApplicationTypeID = -1;
        private int _ApplicationID = -1;
        private int _ReplacedLicenseID = -1;

        private decimal _ApplicationFees = 0;
        public frmReplaceLostOrDamagedLicense()
        {
            InitializeComponent();
            rdbDamaged.Checked = true;
            linkLabelShowLicenseInfo.Enabled = false;
            linkLabelShowHistory.Enabled = false;
            ctrSearchLocalLicense1.OnLicenseSelected +=
    ctrSearchLocalLicense1_OnLicenseSelected;

            ctrSearchLocalLicense1.OnLicenseSelectionCleared +=
                ctrSearchLocalLicense1_OnLicenseSelectionCleared;
            
        }

        private void ctrSearchLocalLicense1_OnLicenseSelected(
     int LicenseID,
     int DriverID,
     int PersonID)
        {
            _OldLicenseID = LicenseID;
            _DriverID = DriverID;
            _PersonID = PersonID;
         
        }

        private void ctrSearchLocalLicense1_OnLicenseSelectionCleared()
        {
            _OldLicenseID = -1;
            _DriverID = -1;
            _PersonID = -1;
        }

        private void frmReplaceLostOrDamagedLicense_Load(object sender, EventArgs e)
        {

        }

        private void ctrSearchLocalLicense1_Load(object sender, EventArgs e)
        {

        }

        private void rdbLost_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLost.Checked)
                _ApplicationTypeID = 3;
            clsApplicationType ApplicationType =
            clsApplicationType.Find(_ApplicationTypeID);

            if (ApplicationType != null)
            {
                _ApplicationFees = ApplicationType.ApplicationFees;

                ctrReplaceLostOrDamagedLicenseApplicationInfo1.ApplicationFees =
                    _ApplicationFees;
            }

            lblReplacementReason.Text = "Replacement For Lost license";
        }

        private void rdbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDamaged.Checked)
                _ApplicationTypeID = 4;
            clsApplicationType ApplicationType =
           clsApplicationType.Find(_ApplicationTypeID);

            if (ApplicationType != null)
            {
                _ApplicationFees = ApplicationType.ApplicationFees;

                ctrReplaceLostOrDamagedLicenseApplicationInfo1.ApplicationFees =
                    _ApplicationFees;
            }
            lblReplacementReason.Text = "Replacement For Damaged license";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (_OldLicenseID == -1 ||
                _DriverID == -1 ||
                _PersonID == -1)
            {
                MessageBox.Show(
                    "Please search for a valid license first.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (_ApplicationTypeID == -1)
            {
                MessageBox.Show(
                    "Please select replacement reason.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            clsApplicationType ApplicationType =
                clsApplicationType.Find(_ApplicationTypeID);

            if (ApplicationType == null)
            {
                MessageBox.Show(
                    "Application type was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _ApplicationFees =
                ApplicationType.ApplicationFees;

            _ApplicationDate = DateTime.Now;

            _ApplicationID =
                clsApplication.AddNewApplication(
                    _PersonID,
                    _ApplicationDate,
                    _ApplicationTypeID,
                    _ApplicationFees,
                    clsGlobal.CurrentUser.UserID);

            if (_ApplicationID == -1)
            {
                MessageBox.Show(
                    "Failed to create replacement application.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            _ReplacedLicenseID =
    clsLicense.AddNewLicense(
        _ApplicationID,
        _DriverID,
        ctrSearchLocalLicense1.LicenseClassID,
        DateTime.Now,
        ctrSearchLocalLicense1.ExpirationDate,
        "",
        0,
        true,
        _ApplicationTypeID,
        clsGlobal.CurrentUser.UserID);

            if (_ReplacedLicenseID == -1)
            {
                MessageBox.Show(
                    "Failed to create replacement license.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            if (!clsLicense.DeactivateLicense(_OldLicenseID))
            {
                MessageBox.Show(
                    "Replacement license was created, but the old license could not be deactivated.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            ctrReplaceLostOrDamagedLicenseApplicationInfo1.LoadApplicationInfo(
    _ApplicationID,
    _ApplicationDate,
    _ApplicationFees,
    _ReplacedLicenseID,
    _OldLicenseID,
    clsGlobal.CurrentUser.UserName);

            linkLabelShowLicenseInfo.Enabled = true;
            linkLabelShowHistory.Enabled = true;
            ctrSearchLocalLicense1.Enabled = false;
            button1.Enabled = false;
            MessageBox.Show(
                "License replaced successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void linkLabelShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frm =
     new frmPersonLicenseHistory(_PersonID);

            frm.ShowDialog();
        }

        private void linkLabelShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm =
     new frmShowLicense(_ReplacedLicenseID);

            frm.ShowDialog();
        }
    }
}
