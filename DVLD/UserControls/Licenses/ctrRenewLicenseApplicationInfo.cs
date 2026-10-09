using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UserControls.Licenses
{
    public partial class ctrRenewLicenseApplicationInfo : UserControl
    {

        public string NotesText
        {
            get { return txtNotes.Text; }
        }
        public ctrRenewLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        public void LoadApplicationInfo(
       int RLApplicationID,
       DateTime ApplicationDate,
       DateTime IssueDate,
       decimal ApplicationFees,
       decimal LicenseFees,
       int RenewedLicenseID,
       int OldLicenseID,
       DateTime ExpirationDate,
       string CreatedBy)
        {
            lblRLAppID.Text = RLApplicationID.ToString();
            lblApplicationDate.Text = ApplicationDate.ToShortDateString();
            lblIssueDate.Text = IssueDate.ToShortDateString();

            lblApplicationFees.Text =
                ApplicationFees.ToString("0.00");

            lblLicenseFees.Text =
                LicenseFees.ToString("0.00");

            lblRenewedLicenseID.Text =
                RenewedLicenseID.ToString();

            lblOldLicenseID.Text =
                OldLicenseID.ToString();

            lblExpirationDate.Text =
                ExpirationDate.ToShortDateString();

            lblCreatedBy.Text = CreatedBy;

            lblTotalFees.Text =
                (ApplicationFees + LicenseFees).ToString("0.00");
        }
        private void ctrRenewLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
