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
    public partial class ctrInternationalLicenseApplicationInfo : UserControl
    {
        public int InternationalLicenseApplicationID { get; private set; }
        public DateTime ApplicationDate { get; private set; }
        public DateTime IssueDate { get; private set; }
        public decimal Fees { get; private set; }
        public int InternationalLicenseID { get; private set; }
        public int LocalLicenseID { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string CreatedByUserName { get; private set; }

        public ctrInternationalLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadApplicationInfo(
    int InternationalLicenseApplicationID,
    DateTime ApplicationDate,
    DateTime IssueDate,
    decimal Fees,
    int InternationalLicenseID,
    int LocalLicenseID,
    DateTime ExpirationDate,
    string CreatedByUserName)
        {
            this.InternationalLicenseApplicationID = InternationalLicenseApplicationID;
            this.ApplicationDate = ApplicationDate;
            this.IssueDate = IssueDate;
            this.Fees = Fees;
            this.InternationalLicenseID = InternationalLicenseID;
            this.LocalLicenseID = LocalLicenseID;
            this.ExpirationDate = ExpirationDate;
            this.CreatedByUserName = CreatedByUserName;

            lblILAppID.Text = InternationalLicenseApplicationID.ToString();
            lblApplicationDate.Text = ApplicationDate.ToShortDateString();
            lblIssueDate.Text = IssueDate.ToShortDateString();
            lblFees.Text = Fees.ToString("0.00");
            lblILLicenseID.Text = InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = LocalLicenseID.ToString();
            lblExpirationDate.Text = ExpirationDate.ToShortDateString();
            lblCreatedBy.Text =
                 CreatedByUserName;
        }
        private void ctrInternationalLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
