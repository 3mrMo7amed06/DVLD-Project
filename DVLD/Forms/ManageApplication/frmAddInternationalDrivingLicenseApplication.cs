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
    public partial class frmAddInternationalDrivingLicenseApplication : Form
    {

        private int _LocalLicenseID = -1;
        private int _DriverID = -1;
        private int _PersonID = -1;
        private int _ApplicationID = -1;
        private int _InternationalLicenseID = -1;

        private DateTime _IssueDate;
        private DateTime _ExpirationDate;

        public frmAddInternationalDrivingLicenseApplication()
        {
            InitializeComponent();
            linkLabelShowLicenseInfo.Visible = false;
            ctrSearchLocalLicense1.OnLicenseSelected +=
                ctrSearchLocalLicense1_OnLicenseSelected;

            ctrSearchLocalLicense1.OnLicenseSelectionCleared +=
    ctrSearchLocalLicense1_OnLicenseSelectionCleared;
        }

        private void ctrSearchLocalLicense1_OnLicenseSelectionCleared()
        {
            _LocalLicenseID = -1;
            _DriverID = -1;
            _PersonID = -1;
        }

        private void ctrSearchLocalLicense1_OnLicenseSelected(
            int LicenseID,
            int DriverID,
            int PersonID)
        {
            _LocalLicenseID = LicenseID;
            _DriverID = DriverID;
            _PersonID = PersonID;
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _CreateInternationalLicense()
        {
            if (_LocalLicenseID == -1 ||
                _DriverID == -1 ||
                _PersonID == -1)
            {
                MessageBox.Show(
                    "Please search for a valid local license first.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (clsInternationalLicense.IsInternationalLicenseExistByDriverID(_DriverID))
            {
                MessageBox.Show(
                    "This driver already has an active international driving license.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            clsApplicationType ApplicationType =
                clsApplicationType.Find(6);

            if (ApplicationType == null)
            {
                MessageBox.Show(
                    "Application type was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            _ApplicationID =
                clsApplication.AddNewApplication(
                    _PersonID,
                    DateTime.Now,
                    6,
                    ApplicationType.ApplicationFees,
                    clsGlobal.CurrentUser.UserID);

            if (_ApplicationID == -1)
            {
                MessageBox.Show(
                    "Failed to create application.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            _IssueDate = DateTime.Now;
            _ExpirationDate = _IssueDate.AddYears(1);

            _InternationalLicenseID =
                clsInternationalLicense.AddNewInternationalLicense(
                    _ApplicationID,
                    _DriverID,
                    _LocalLicenseID,
                    _IssueDate,
                    _ExpirationDate,
                    true,
                    clsGlobal.CurrentUser.UserID);

            if (_InternationalLicenseID == -1)
            {
                MessageBox.Show(
                    "Failed to create international license.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void frmAddInternationalDrivingLicenseApplication_Load(
            object sender,
            EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_CreateInternationalLicense())
                return;
            
             
                MessageBox.Show(
                    "International Driving License created successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            
            clsApplication Application =
           clsApplication.Find(_ApplicationID);

            if (Application != null)
            {
                ctrInternationalLicenseApplicationInfo1.LoadApplicationInfo(
                    _ApplicationID,
                    Application.ApplicationDate,
                    _IssueDate,
                    Application.PaidFees,
                    _InternationalLicenseID,
                    _LocalLicenseID,
                    _ExpirationDate,
                   clsGlobal.CurrentUser.UserName);
                linkLabelShowLicenseInfo.Visible = true;
            }
        }

        private void ctrSearchLocalLicense1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm =
       new frmShowInternationalLicenseInfo(
           _InternationalLicenseID);

            frm.ShowDialog();
        }

        private void linkLabelShowInternationalLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmPersonLicenseHistory frm =
       new frmPersonLicenseHistory(
           _PersonID);

            frm.ShowDialog();

        }
    }
    }

