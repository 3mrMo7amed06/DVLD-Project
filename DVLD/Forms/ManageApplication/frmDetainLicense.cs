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
    public partial class frmDetainLicense : Form
    {
        private int _DetainID = -1;
        private DateTime _DetainDate;
        private decimal _FineFees = 0;
        private int _LicenseID = -1;
        private int _DriverID = -1;
        private int _PersonID = -1;
        public frmDetainLicense()
        {
            InitializeComponent();
            linkLabelShowHistory.Enabled = false;
            linkLabelShowLicenseInfo.Enabled = false;
            ctrSearchLocalLicense1.RequireClass3 = false;

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
            _LicenseID = LicenseID;
            _DriverID = DriverID;
            _PersonID = PersonID;
        }

        private void ctrSearchLocalLicense1_OnLicenseSelectionCleared()
        {
            _LicenseID = -1;
            _DriverID = -1;
            _PersonID = -1;
        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
  frmShowLicense frm =
     new frmShowLicense(_LicenseID);

            frm.ShowDialog();
        }

        private void linkLabelShowHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frm =
     new frmPersonLicenseHistory(_PersonID);

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
            if (clsDetainedLicense.IsLicenseDetained(_LicenseID))
            {
                MessageBox.Show(
                    "This license is already detained.",
                    "License Already Detained",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _FineFees = ctrDetainLicenseInfo1.FineFees;

            if (_FineFees <= 0)
            {
                MessageBox.Show(
                    "Fine fees must be greater than zero.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            _DetainDate = DateTime.Now;
            _DetainID =
    clsDetainedLicense.AddNewDetainedLicense(
        _LicenseID,
        _DetainDate,
        _FineFees,
        clsGlobal.CurrentUser.UserID);

            if (_DetainID == -1)
            {
                MessageBox.Show(
                    "Failed to detain the license.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            ctrDetainLicenseInfo1.LoadDetainInfo(
                _DetainID,
                _DetainDate,
                _FineFees,
                _LicenseID,
                clsGlobal.CurrentUser.UserName);

            button1.Enabled = false;
            ctrSearchLocalLicense1.Enabled = false;
            linkLabelShowHistory.Enabled = true;
            linkLabelShowLicenseInfo.Enabled = true;




            MessageBox.Show(
                "License detained successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lea_Click(object sender, EventArgs e)
        {

        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {

        }
    }
}
