using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsTestAppointment
    {

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        public static DataTable GetTestAppointments(
       int LocalDrivingLicenseApplicationID,
       int TestTypeID)
        {
            return clsTestAppointmentData.GetTestAppointments(
                LocalDrivingLicenseApplicationID,
                TestTypeID);
        }

        public static bool GetVisionTestAppointmentInfo(
     int LocalDrivingLicenseApplicationID,
     int TestAppointmentID,
     ref int DLAID,
     ref string ClassName,
     ref string Applicant,
     ref int Trial,
     ref decimal TestFees)
        {
            return clsTestAppointmentData.GetVisionTestAppointmentInfo(
                LocalDrivingLicenseApplicationID,
                TestAppointmentID,
                ref DLAID,
                ref ClassName,
                ref Applicant,
                ref Trial,
                ref TestFees);
        }
        public static int AddNewTestAppointment(
    int TestTypeID,
    int LocalDrivingLicenseApplicationID,
    DateTime AppointmentDate,
    decimal PaidFees,
    int CreatedByUserID)
        {
            return clsTestAppointmentData.AddNewTestAppointment(
                TestTypeID,
                LocalDrivingLicenseApplicationID,
                AppointmentDate,
                PaidFees,
                CreatedByUserID);
        }
        public static bool IsThereActiveAppointment(
     int LocalDrivingLicenseApplicationID,
     int TestTypeID)
        {
            return clsTestAppointmentData.IsThereActiveAppointment(
                LocalDrivingLicenseApplicationID,
                TestTypeID);
        }

        public static bool GetTestAppointmentInfo(
    int LocalDrivingLicenseApplicationID,
    int TestTypeID,
    int TestAppointmentID,
    ref int DLAID,
    ref string ClassName,
    ref string Applicant,
    ref int Trial,
    ref decimal TestFees)
        {
            return clsTestAppointmentData.GetTestAppointmentInfo(
                LocalDrivingLicenseApplicationID,
                TestTypeID,
                TestAppointmentID,
                ref DLAID,
                ref ClassName,
                ref Applicant,
                ref Trial,
                ref TestFees);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;

            if (clsTestAppointmentData.GetTestAppointmentInfo(
                    TestAppointmentID,
                    ref TestTypeID,
                    ref LocalDrivingLicenseApplicationID,
                    ref AppointmentDate,
                    ref PaidFees,
                    ref CreatedByUserID,
                    ref IsLocked))
            {
                clsTestAppointment Appointment =
                    new clsTestAppointment();

                Appointment.TestAppointmentID = TestAppointmentID;
                Appointment.TestTypeID = TestTypeID;
                Appointment.LocalDrivingLicenseApplicationID =
                    LocalDrivingLicenseApplicationID;
                Appointment.AppointmentDate = AppointmentDate;
                Appointment.PaidFees = PaidFees;
                Appointment.CreatedByUserID = CreatedByUserID;
                Appointment.IsLocked = IsLocked;

                return Appointment;
            }

            return null;
        }

        public bool Update()
        {
            return clsTestAppointmentData.UpdateTestAppointment(
                TestAppointmentID,
                AppointmentDate);
        }
        public static bool LockTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentData.LockTestAppointment(
                TestAppointmentID);
        }

    }

}
