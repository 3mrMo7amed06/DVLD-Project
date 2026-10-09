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
    public partial class frmReleaseLicense : Form
    {
        private int _LicenseID = -1;
        private int _DriverID = -1;
        private int _PersonID = -1;
        private int _DetainID = -1;
        private DateTime _DetainDate;
        private decimal _FineFees = 0;
        private int _CreatedByUserID = -1;
        private decimal _ApplicationFees = 0;
        private decimal _TotalFees = 0;
        private int _ApplicationID = -1;
        private DateTime _ApplicationDate;

        public frmReleaseLicense()
        {
            InitializeComponent();

            _InitializeForm();
        }

        public frmReleaseLicense(int LicenseID)
        {
            InitializeComponent();

            _InitializeForm();

            ctrSearchLocalLicense1.LoadLicenseInfo(LicenseID);
            ctrSearchLocalLicense1.Enabled = false;

        }

        private void _InitializeForm()
        {
            linkLabelShowHistory.Enabled = false;
            linkLabelShowLicenseInfo.Enabled = false;

            ctrSearchLocalLicense1.RequireClass3 = false;

            ctrSearchLocalLicense1.OnLicenseSelected +=
                ctrSearchLocalLicense1_OnLicenseSelected;

            ctrSearchLocalLicense1.OnLicenseSelectionCleared +=
                ctrSearchLocalLicense1_OnLicenseSelectionCleared;
        }

        private void ctrSearchLocalLicense1_OnLicenseSelectionCleared()
        {
            _LicenseID = -1;
            _DriverID = -1;
            _PersonID = -1;

            _DetainID = -1;
            _DetainDate = DateTime.MinValue;
            _FineFees = 0;
            _CreatedByUserID = -1;
            _ApplicationFees = 0;
            _TotalFees = 0;
            _ApplicationID = -1;
            _ApplicationDate = DateTime.MinValue;
        }

        private void ctrSearchLocalLicense1_OnLicenseSelected(
            int LicenseID,
            int DriverID,
            int PersonID)
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.MinValue;
            decimal FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;

            if (!clsDetainedLicense.GetDetainedLicenseInfoByLicenseID(
                LicenseID,
                ref DetainID,
                ref DetainDate,
                ref FineFees,
                ref CreatedByUserID,
                ref IsReleased))
            {
                MessageBox.Show(
                    "This license is not detained.",
                    "Not Detained",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (IsReleased)
            {
                MessageBox.Show(
                    "This license has already been released.",
                    "Already Released",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _LicenseID = LicenseID;
            _DriverID = DriverID;
            _PersonID = PersonID;

            _DetainID = DetainID;
            _DetainDate = DetainDate;
            _FineFees = FineFees;
            _CreatedByUserID = CreatedByUserID;

            clsApplicationType ApplicationType =
                clsApplicationType.Find(5);

            if (ApplicationType == null)
            {
                MessageBox.Show(
                    "Release application type was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _ApplicationFees =
                ApplicationType.ApplicationFees;

            _TotalFees =
                _FineFees + _ApplicationFees;

            ctrReleaseLicenseInfo1.LoadReleaseInfo(
                _DetainID,
                _DetainDate,
                _FineFees,
                _ApplicationFees,
                _TotalFees,
                _LicenseID,
                clsGlobal.CurrentUser.UserName,
                -1);
        }



        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelShowHistory_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frm =
                new frmPersonLicenseHistory(_PersonID);

            frm.ShowDialog();
        }

        private void linkLabelShowLicenseInfo_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm =
                new frmShowLicense(_LicenseID);

            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_LicenseID == -1)
            {
                MessageBox.Show(
                    "Please search for a valid license first.",
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
                    5,
                    _TotalFees,
                    clsGlobal.CurrentUser.UserID);

            if (_ApplicationID == -1)
            {
                MessageBox.Show(
                    "Failed to create release application.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DateTime ReleaseDate = DateTime.Now;

            if (!clsDetainedLicense.ReleaseDetainedLicense(
                _DetainID,
                ReleaseDate,
                clsGlobal.CurrentUser.UserID,
                _ApplicationID))
            {
                MessageBox.Show(
                    "Failed to release the license.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            ctrReleaseLicenseInfo1.LoadReleaseInfo(
                _DetainID,
                _DetainDate,
                _FineFees,
                _ApplicationFees,
                _TotalFees,
                _LicenseID,
                clsGlobal.CurrentUser.UserName,
                _ApplicationID);

            button1.Enabled = false;
            ctrSearchLocalLicense1.Enabled = false;

            linkLabelShowHistory.Enabled = true;
            linkLabelShowLicenseInfo.Enabled = true;

            MessageBox.Show(
                "License released successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ctrSearchLocalLicense1_Load(object sender, EventArgs e)
        {

        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {

        }

        private void Lea_Click(object sender, EventArgs e)
        {

        }
    }
}
