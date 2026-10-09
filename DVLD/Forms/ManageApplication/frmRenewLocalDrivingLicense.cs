using DVLD.Business;
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
    public partial class frmRenewLocalDrivingLicense : Form
    {
        private int _OldLicenseID = -1;
        private int _DriverID = -1;
        private int _PersonID = -1;
        private int _ApplicationID = -1;
        private int _RenewedLicenseID = -1;
        private decimal _ApplicationFees = 0;
        private decimal _LicenseFees = 0;
        private int _ValidityLength = 0;
        private DateTime _ApplicationDate;
        private DateTime _IssueDate;
        private DateTime _ExpirationDate;
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
            linkLabelShowLicenseInfo.Enabled = false;
            linkLabelShowHistory.Enabled = false;

            ctrSearchLocalLicense1.OnLicenseSelected +=
                ctrSearchLocalLicense1_OnLicenseSelected;

            ctrSearchLocalLicense1.OnLicenseSelectionCleared +=
                ctrSearchLocalLicense1_OnLicenseSelectionCleared;
        }

        private void ctrSearchLocalLicense1_OnLicenseSelectionCleared()
        {
            _OldLicenseID = -1;
            _DriverID = -1;
            _PersonID = -1;
        }

        private void ctrSearchLocalLicense1_OnLicenseSelected(
      int LicenseID,
      int DriverID,
      int PersonID)
        {
            _OldLicenseID = LicenseID;
            _DriverID = DriverID;
            _PersonID = PersonID;

            clsApplicationType ApplicationType =
    clsApplicationType.Find(2);

            if (ApplicationType != null)
            {
                _ApplicationFees = ApplicationType.ApplicationFees;
            }

            clsLicenseClass.GetLicenseClassInfo(
                ctrSearchLocalLicense1.LicenseClassID,
                ref _ValidityLength,
                ref _LicenseFees);
        }

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {

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

            clsApplicationType ApplicationType =
                clsApplicationType.Find(2);

            if (ApplicationType == null)
            {
                MessageBox.Show(
                    "Application type was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            _ApplicationDate = DateTime.Now;

            _ApplicationID =
                clsApplication.AddNewApplication(
                    _PersonID,
                    _ApplicationDate,
                    2,
                    _ApplicationFees + _LicenseFees,
                    clsGlobal.CurrentUser.UserID);

            if (_ApplicationID == -1)
            {
                MessageBox.Show(
                    "Failed to create renewal application.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
           

            _IssueDate = DateTime.Now;

            _ExpirationDate =
                _IssueDate.AddYears(_ValidityLength);

            _RenewedLicenseID =
      clsLicense.AddNewLicense(
          _ApplicationID,
          _DriverID,
          ctrSearchLocalLicense1.LicenseClassID,
          _IssueDate,
          _ExpirationDate,
          ctrRenewLicenseApplicationInfo1.NotesText,
          _LicenseFees,
          true,
          2,
          clsGlobal.CurrentUser.UserID);

            if (_RenewedLicenseID == -1)
            {
                MessageBox.Show(
                    "Failed to create renewed license.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            if(!clsLicense.DeactivateLicense(_OldLicenseID))
{
                MessageBox.Show(
                    "Renewed license was created, but the old license could not be deactivated.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            ctrRenewLicenseApplicationInfo1.LoadApplicationInfo(
        _ApplicationID,
        _ApplicationDate,
        _IssueDate,
        _ApplicationFees,
        _LicenseFees,
        _RenewedLicenseID,
        _OldLicenseID,
        _ExpirationDate,
        clsGlobal.CurrentUser.UserName);
            linkLabelShowLicenseInfo.Enabled = true;
            linkLabelShowHistory.Enabled = true;

            MessageBox.Show(
                "License renewed successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


            button1.Enabled = false;
        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm =
       new frmShowLicense(_RenewedLicenseID);

            frm.ShowDialog();
        }

        private void linkLabelShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frm =
     new frmPersonLicenseHistory(_PersonID);

            frm.ShowDialog();
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
