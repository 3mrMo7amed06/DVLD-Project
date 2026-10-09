using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsLocalDrivingLicenseApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public int ApplicantPersonID { get; set; }
        public int ApplicationTypeID { get; set; }
        public short ApplicationStatus { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }


        public string ClassName { get; set; }
        public int PassedTests { get; set; }
        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            ClassName = "";
            PassedTests = 0;
            ApplicantPersonID = -1;
            ApplicationTypeID = -1;
            ApplicationStatus = 1;
            ApplicationDate = DateTime.Now;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

       
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID =
                clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(
                    this.ApplicantPersonID,
                    this.ApplicationTypeID,
                    this.ApplicationStatus,
                    this.LastStatusDate,
                    this.PaidFees,
                    this.CreatedByUserID,
                    this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        public static clsLocalDrivingLicenseApplication GetDLAInfo(
    int LocalDrivingLicenseApplicationID)
        {
            int DLAID = -1;
            string ClassName = "";
            int PassedTests = 0;

            if (clsLocalDrivingLicenseApplicationData.GetDLAInfo(
                    LocalDrivingLicenseApplicationID,
                    ref DLAID,
                    ref ClassName,
                    ref PassedTests))
            {
                clsLocalDrivingLicenseApplication DLA =
                    new clsLocalDrivingLicenseApplication();

                DLA.LocalDrivingLicenseApplicationID = DLAID;
                DLA.ClassName = ClassName;
                DLA.PassedTests = PassedTests;

                return DLA;
            }

            return null;
        }

        public static int GetApplicationID(
    int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.GetApplicationID(
                LocalDrivingLicenseApplicationID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }
        }

        public static bool GetPersonAndLicenseClass(
    int LocalDrivingLicenseApplicationID,
    ref int ApplicantPersonID,
    ref int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.GetPersonAndLicenseClass(
                LocalDrivingLicenseApplicationID,
                ref ApplicantPersonID,
                ref LicenseClassID);
        }

        public static bool IsApplicationExist(
    int ApplicantPersonID,
    int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData
                .IsApplicationExist(
                    ApplicantPersonID,
                    LicenseClassID);
        }


        public static bool CancelApplication(int ApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.CancelApplication(
                ApplicationID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();

        }
    }
}
