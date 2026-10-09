using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsInternationalLicense
    {

        public static DataTable GetAllInternationalLicensesByPersonID(int PersonID)
        {
            return clsInternationalLicenseData
                .GetAllInternationalLicensesByPersonID(PersonID);
        }

        public static int AddNewInternationalLicense(
    int ApplicationID,
    int DriverID,
    int IssuedUsingLocalLicenseID,
    DateTime IssueDate,
    DateTime ExpirationDate,
    bool IsActive,
    int CreatedByUserID)
        {
            return clsInternationalLicenseData.AddNewInternationalLicense(
                ApplicationID,
                DriverID,
                IssuedUsingLocalLicenseID,
                IssueDate,
                ExpirationDate,
                IsActive,
                CreatedByUserID);
        }

        public static bool IsInternationalLicenseExistByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExistByDriverID(
                DriverID);
        }

        public static bool GetInternationalLicenseInfo(
    int InternationalLicenseID,
    ref int ApplicationID,
    ref int DriverID,
    ref int LicenseID,
    ref string NationalNo,
    ref string FullName,
    ref short Gender,
    ref DateTime DateOfBirth,
    ref DateTime IssueDate,
    ref DateTime ExpirationDate,
    ref bool IsActive,
            ref string ImagePath)
        {
            return clsInternationalLicenseData.GetInternationalLicenseInfo(
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
                ref  ImagePath);
        }


        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }
    }


}
