using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsTestData
    {

        public static int AddNewTest(
    int TestAppointmentID,
    bool TestResult,
    string Notes,
    int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        INSERT INTO Tests
        (
            TestAppointmentID,
            TestResult,
            Notes,
            CreatedByUserID
        )
        VALUES
        (
            @TestAppointmentID,
            @TestResult,
            @Notes,
            @CreatedByUserID
        );

        SELECT SCOPE_IDENTITY();";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@TestAppointmentID",
                TestAppointmentID);

            command.Parameters.AddWithValue(
                "@TestResult",
                TestResult);

            command.Parameters.AddWithValue(
                "@Notes",
                string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes);

            command.Parameters.AddWithValue(
                "@CreatedByUserID",
                CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    TestID = Convert.ToInt32(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return TestID;
        }
        public static bool IsTestFailed(
     int LocalDrivingLicenseApplicationID,
     int TestTypeID)
        { 
            bool IsFailed = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1 Tests.TestResult
        FROM Tests
        INNER JOIN TestAppointments
            ON Tests.TestAppointmentID =
               TestAppointments.TestAppointmentID
        WHERE TestAppointments.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
          AND TestAppointments.TestTypeID = @TestTypeID
        ORDER BY Tests.TestID DESC;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue(
    "@TestTypeID",
    TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    IsFailed = !Convert.ToBoolean(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFailed;
        }

        public static bool IsTestExist(int TestAppointmentID)
        {
            bool IsExist = false;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1 TestID
        FROM Tests
        WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@TestAppointmentID",
                TestAppointmentID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                if (result != null)
                    IsExist = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsExist;
        }

        public static bool IsTestPassed(
    int LocalDrivingLicenseApplicationID,
    int TestTypeID)
        {
            bool IsPassed = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1 Tests.TestResult
        FROM Tests
        INNER JOIN TestAppointments
            ON Tests.TestAppointmentID =
               TestAppointments.TestAppointmentID
        WHERE TestAppointments.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
          AND TestAppointments.TestTypeID =
              @TestTypeID
        ORDER BY Tests.TestID DESC;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue(
                "@TestTypeID",
                TestTypeID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                if (result != null)
                    IsPassed = Convert.ToBoolean(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsPassed;
        }
    }
}
