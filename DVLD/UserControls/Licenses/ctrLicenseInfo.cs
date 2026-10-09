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
    public partial class ctrLicenseInfo : UserControl
    {
        public ctrLicenseInfo()
        {
            InitializeComponent();
        }
        public int DriverID { get; private set; }
        public int PersonID { get; private set; }
        public int LicenseID { get; private set; }
        public string LicenseClass { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsActive { get; private set; }
        public int LicenseClassID { get; private set; }
        public bool LoadLicenseInfo(int LicenseID)

        {
            int DriverID = -1;
            int PersonID = -1;
            int LicenseClassID = -1;
            string NationalNo = "";
            string Name = "";
            short Gendor = 0;
            DateTime DateOfBirth = DateTime.Now;
            string LicenseClass = "";
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string IssueReason = "";
            string Notes = "";
            string IsActive = "";
            string IsDetained = "";
            string ImagePath = "";

            if (!clsLicense.GetLicenseInfo(
                    LicenseID,
                    ref DriverID,
                    ref PersonID,
                     ref LicenseClassID,
                    ref NationalNo,
                    ref Name,
                    ref Gendor,
                    ref DateOfBirth,
                    ref LicenseClass,
                    ref IssueDate,
                    ref ExpirationDate,
                    ref IssueReason,
                    ref Notes,
                    ref IsActive,
                    ref IsDetained,
                    ref ImagePath))
            {
                MessageBox.Show(
                    "License was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            lblLicenseID.Text =
                LicenseID.ToString();

            lblDriverID.Text =
                DriverID.ToString();

            lblName.Text =
                Name;

            lblNationalNo.Text =
                NationalNo;

            lblGender.Text =
                Gendor == 0
                    ? "Male"
                    : "Female";

            lblDateOfBirth.Text =
                DateOfBirth.ToShortDateString();
            lblLicenseClass.Text =
                LicenseClass;

            lblIssueDate.Text =
                IssueDate.ToShortDateString();

            lblExpirationDate.Text =
                ExpirationDate.ToShortDateString();

            lblIssueReason.Text =
                IssueReason;

            lblNotes.Text =
                Notes;

            lblIsActive.Text =
                IsActive;

            lblIsDetained.Text =
                IsDetained;

             
            if (!string.IsNullOrEmpty(ImagePath))
            {
                pbPersonImage.ImageLocation =
                    ImagePath;
            }
            else
            {
                if (Gendor == 0)
                    pbPersonImage.Image =
                        Properties.Resources.man;
                else
                    pbPersonImage.Image =
                        Properties.Resources.girl;
            }


            this.LicenseID = LicenseID;
            this.LicenseClass = LicenseClass;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive == "Yes";
            this.LicenseClassID = LicenseClassID;
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            return true;
        }
        private void ctrLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
