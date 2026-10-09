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
    public partial class frmIssueDrivingLicense : Form
    {
        private int _ApplicationID = -1;
        private int _PersonID = -1;
        private int _DriverID = -1;
        private int _LicenseClassID = -1;

        private int _LocalDrivingLicenseApplicationID;
        public frmIssueDrivingLicense(
       int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID =
                LocalDrivingLicenseApplicationID;
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrDrivingLicenseApplicationInfo.LoadApplicationInfo(
        _LocalDrivingLicenseApplicationID);
            _ApplicationID =
      clsLocalDrivingLicenseApplication.GetApplicationID(
          _LocalDrivingLicenseApplicationID);

            clsApplication Application =
        clsApplication.Find(_ApplicationID);

            if (Application != null)
            {
                _PersonID =
                    Application.ApplicantPersonID;
            }

            clsLocalDrivingLicenseApplication.GetPersonAndLicenseClass(
    _LocalDrivingLicenseApplicationID,
    ref _PersonID,
    ref _LicenseClassID);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrApplicationBasicInfo1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _DriverID =
    clsDriver.GetDriverIDByPersonID(
        _PersonID);

            if (_DriverID == -1)
            {
                _DriverID =
                    clsDriver.AddNewDriver(
                        _PersonID,
                        clsGlobal.CurrentUser.UserID);

                if (_DriverID == -1)
                {
                    MessageBox.Show(
                        "Failed to create driver.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }

            int ValidityLength = 0;
            decimal ClassFees = 0;

            if (!clsLicenseClass.GetLicenseClassInfo(
                    _LicenseClassID,
                    ref ValidityLength,
                    ref ClassFees))
            {
                MessageBox.Show(
                    "License class information was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DateTime IssueDate = DateTime.Now;

            DateTime ExpirationDate =
                IssueDate.AddYears(ValidityLength);
            int LicenseID =
    clsLicense.AddNewLicense(
        _ApplicationID,
        _DriverID,
        _LicenseClassID,
        IssueDate,
        ExpirationDate,
        txtNotes.Text,
        ClassFees,
        true,
        1,
        clsGlobal.CurrentUser.UserID);
            if (LicenseID == -1)
            {
                MessageBox.Show(
                    "Failed to issue driving license.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (!clsApplication.CompleteApplication(_ApplicationID))
            {
                MessageBox.Show(
                    "License was issued, but the application status could not be updated.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Driving license issued successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }
    }
}
