using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsDetainedLicense
    {

        public static int AddNewDetainedLicense(
           int LicenseID,
           DateTime DetainDate,
           decimal FineFees,
           int CreatedByUserID)
        {
            return clsDetainedLicenseData.AddNewDetainedLicense(
                LicenseID,
                DetainDate,
                FineFees,
                CreatedByUserID);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(
                LicenseID);
        }
        public static bool GetDetainedLicenseInfoByLicenseID(
    int LicenseID,
    ref int DetainID,
    ref DateTime DetainDate,
    ref decimal FineFees,
    ref int CreatedByUserID,
    ref bool IsReleased)
        {
            return clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(
                LicenseID,
                ref DetainID,
                ref DetainDate,
                ref FineFees,
                ref CreatedByUserID,
                ref IsReleased);
        }

        public static bool ReleaseDetainedLicense(
    int DetainID,
    DateTime ReleaseDate,
    int ReleasedByUserID,
    int ReleaseApplicationID)
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(
                DetainID,
                ReleaseDate,
                ReleasedByUserID,
                ReleaseApplicationID);
        }


        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }
    }
}
