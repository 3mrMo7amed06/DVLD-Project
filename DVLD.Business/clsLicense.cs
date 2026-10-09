using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsLicense
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = true;
            IssueReason = 1;
            CreatedByUserID = -1;
        }

        public static int AddNewLicense(
            int ApplicationID,
            int DriverID,
            int LicenseClass,
            DateTime IssueDate,
            DateTime ExpirationDate,
            string Notes,
            decimal PaidFees,
            bool IsActive,
            int IssueReason,
            int CreatedByUserID)
        {
            return clsLicenseData.AddNewLicense(
                ApplicationID,
                DriverID,
                LicenseClass,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                IssueReason,
                CreatedByUserID);
        }

        public static bool GetLicenseInfo(
    int LicenseID,
    ref int DriverID,
    ref int PersonID,
    ref int LicenseClassID,
    ref string NationalNo,
    ref string Name,
    ref short Gendor,
    ref DateTime DateOfBirth,
    ref string LicenseClass ,
    ref DateTime IssueDate,
    ref DateTime ExpirationDate,
    ref string IssueReason,
    ref string Notes,
    ref string IsActive,
    ref string IsDetained,
    ref string ImagePath)
        {
            return clsLicenseData.GetLicenseInfo(
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
                ref ImagePath);
        }
        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            return clsLicenseData.GetLicenseIDByApplicationID(
                ApplicationID);
        }

        public static DataTable GetAllLicensesByPersonID(int PersonID)
        {
            return clsLicenseData.GetAllLicensesByPersonID(PersonID);
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            return clsLicenseData.DeactivateLicense(LicenseID);
        }
    }
}
