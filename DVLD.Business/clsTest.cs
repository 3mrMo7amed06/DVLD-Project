using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsTest
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public static int AddNewTest(
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {
            return clsTestData.AddNewTest(
                TestAppointmentID,
                TestResult,
                Notes,
                CreatedByUserID);
        }
        public static bool IsTestFailed(
     int LocalDrivingLicenseApplicationID,
     int TestTypeID)
        {
            return clsTestData.IsTestFailed(
                LocalDrivingLicenseApplicationID,
                TestTypeID);
        }

        public static bool IsTestExist(int TestAppointmentID)
        {
            return clsTestData.IsTestExist(TestAppointmentID);
        }




        public static bool IsTestPassed(
    int LocalDrivingLicenseApplicationID,
    int TestTypeID)
        {
            return clsTestData.IsTestPassed(
                LocalDrivingLicenseApplicationID,
                TestTypeID);
        }
    }



}
