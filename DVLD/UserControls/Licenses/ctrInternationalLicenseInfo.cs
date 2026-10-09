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

namespace DVLD.UserControls.Licenses
{
    public partial class ctrInternationalLicenseInfo : UserControl
    {
        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; private set; }
        public int DriverID { get; private set; }
        public int LicenseID { get; private set; }
        public string NationalNo { get; private set; }
        public string FullName { get; private set; }
        public short Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsActive { get; private set; }
        public string ImagePath { get; private set; }
        public ctrInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        public bool LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseID = -1;

            string NationalNo = "";
            string FullName = "";

            short Gender = 0;
            string ImagePath = "";

            DateTime DateOfBirth = DateTime.Now;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;

            bool IsActive = false;

            if (!clsInternationalLicense.GetInternationalLicenseInfo(
                InternationalLicenseID,
                ref ApplicationID,
                ref DriverID,
                ref LicenseID,
                ref NationalNo,
                ref FullName,
                ref Gender,
                ref DateOfBirth,
                ref IssueDate,
                ref ExpirationDate,
                ref IsActive,
                ref ImagePath))
            {
                return false;
            }

            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseID = LicenseID;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.ImagePath = ImagePath;

            lblName.Text = FullName;
            lblInternationalLicenseID.Text = InternationalLicenseID.ToString();
            lblLicenseID.Text = LicenseID.ToString();
            lblNationalNo.Text = NationalNo;
            lblGender.Text = Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = IssueDate.ToShortDateString();
            lblApplicationID.Text = ApplicationID.ToString();
            lblIsActive.Text = IsActive ? "Yes" : "No";
            if (!string.IsNullOrEmpty(ImagePath))
            {
                pbPersonImage.ImageLocation =
                    ImagePath;
            }
            else
            {
                if (Gender == 0)
                    pbPersonImage.Image =
                        Properties.Resources.man;
                else
                    pbPersonImage.Image =
                        Properties.Resources.girl;
            }
            lblDateOfBirth.Text = DateOfBirth.ToShortDateString();
            lblDriverID.Text = DriverID.ToString();
            lblExpirationDate.Text = ExpirationDate.ToShortDateString();
             

            return true;
        }
        private void ctrInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
