using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsApplication
    {

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public string ApplicationStatus { get; set; }
        public decimal PaidFees { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public string ApplicationType { get; set; }
        public string Applicant { get; set; }
        public string CreatedBy { get; set; }

        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationStatus = "";
            PaidFees = 0;
            ApplicationDate = DateTime.Now;
            LastStatusDate = DateTime.Now;
            ApplicationType = "";
            Applicant = "";
            CreatedBy = "";
        }

        public static clsApplication Find(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            string ApplicationStatus = "";
            decimal PaidFees = 0;
            DateTime ApplicationDate = DateTime.Now;
            DateTime LastStatusDate = DateTime.Now;
            string ApplicationType = "";
            string Applicant = "";
            string CreatedBy = "";

            if (clsApplicationData.GetApplicationBasicInfo(
                    ApplicationID,
                    ref ApplicantPersonID ,
                    ref ApplicationStatus,
                    ref PaidFees,
                    ref ApplicationDate,
                    ref LastStatusDate,
                    ref ApplicationType,
                    ref Applicant,
                    ref CreatedBy))
            {
                clsApplication Application = new clsApplication();

                Application.ApplicationID = ApplicationID;
                Application.ApplicantPersonID = ApplicantPersonID;
                Application.ApplicationStatus = ApplicationStatus;
                Application.PaidFees = PaidFees;
                Application.ApplicationDate = ApplicationDate;
                Application.LastStatusDate = LastStatusDate;
                Application.ApplicationType = ApplicationType;
                Application.Applicant = Applicant;
                Application.CreatedBy = CreatedBy;

                return Application;
            }

            return null;
        }
        public static int AddNewApplication(
    int ApplicantPersonID,
    DateTime ApplicationDate,
    int ApplicationTypeID,
    decimal PaidFees,
    int CreatedByUserID)
        {
            return clsApplicationData.AddNewApplication(
                ApplicantPersonID,
                ApplicationDate,
                ApplicationTypeID,
                PaidFees,
                CreatedByUserID);
        }
        public static int CreateRetakeApplication(
      int LocalDrivingLicenseApplicationID,
      int CreatedByUserID)
        {
            int ApplicantPersonID = -1;
            int LicenseClassID = -1;

            if (!clsLocalDrivingLicenseApplication.GetPersonAndLicenseClass(
                    LocalDrivingLicenseApplicationID,
                    ref ApplicantPersonID,
                    ref LicenseClassID))
            {
                return -1;
            }

            
            int ExistingRetakeApplicationID =
                GetRetakeApplicationID(ApplicantPersonID);

            if (ExistingRetakeApplicationID != -1)
            {
                return ExistingRetakeApplicationID;
            }

           
            return AddNewApplication(
                ApplicantPersonID,
                DateTime.Now,
                8,
                5.00m,
                CreatedByUserID);
        }
        public static bool IsRetakeApplicationExist(
    int ApplicantPersonID)
        {
            return clsApplicationData.IsRetakeApplicationExist(
                ApplicantPersonID);
        }

        public static int GetRetakeApplicationID(int ApplicantPersonID)
        {
            return clsApplicationData.GetRetakeApplicationID(
                ApplicantPersonID);
        }
        public static bool CompleteApplication(int ApplicationID)
        {
            return clsApplicationData.CompleteApplication(
                ApplicationID);
        }
        
    }
}
