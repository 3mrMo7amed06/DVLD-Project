using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsTestAppointmentData
    {
        public static DataTable GetTestAppointments(
      int LocalDrivingLicenseApplicationID,
      int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT 
            TestAppointmentID,
            AppointmentDate,
            PaidFees,
            IsLocked
        FROM TestAppointments
        WHERE LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
          AND TestTypeID = @TestTypeID;";

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

                SqlDataReader reader =
                    command.ExecuteReader();

                dt.Load(reader);

                reader.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return dt;
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
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID AS DLAID,

            LicenseClasses.ClassName,

            CONCAT_WS(' ',
                People.FirstName,
                People.SecondName,
                People.ThirdName,
                People.LastName
            ) AS Applicant,

       (
    SELECT COUNT(*)
    FROM TestAppointments TA
    WHERE TA.LocalDrivingLicenseApplicationID =
          LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
      AND TA.TestTypeID = 1
      AND (
          @TestAppointmentID = -1
          OR TA.TestAppointmentID < @TestAppointmentID
      )
) AS Trial,

            TestTypes.TestTypeFees AS TestFees

        FROM LocalDrivingLicenseApplications

        INNER JOIN LicenseClasses
            ON LocalDrivingLicenseApplications.LicenseClassID =
               LicenseClasses.LicenseClassID

        INNER JOIN Applications
            ON LocalDrivingLicenseApplications.ApplicationID =
               Applications.ApplicationID

        INNER JOIN People
            ON Applications.ApplicantPersonID =
               People.PersonID

        INNER JOIN TestTypes
            ON TestTypes.TestTypeID = 1

        WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue(
    "@TestAppointmentID",
    TestAppointmentID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    DLAID =
                        Convert.ToInt32(reader["DLAID"]);

                    ClassName =
                        reader["ClassName"].ToString();

                    Applicant =
                        reader["Applicant"].ToString();

                    Trial =
                        Convert.ToInt32(reader["Trial"]);

                    TestFees =
                        Convert.ToDecimal(reader["TestFees"]);
                }

                reader.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static bool GetTestAppointmentInfo(
    int TestAppointmentID,
    ref int TestTypeID,
    ref int LocalDrivingLicenseApplicationID,
    ref DateTime AppointmentDate,
    ref decimal PaidFees,
    ref int CreatedByUserID,
    ref bool IsLocked)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            TestTypeID,
            LocalDrivingLicenseApplicationID,
            AppointmentDate,
            PaidFees,
            CreatedByUserID,
            IsLocked
        FROM TestAppointments
        WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@TestAppointmentID",
                TestAppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    TestTypeID =
                        Convert.ToInt32(reader["TestTypeID"]);

                    LocalDrivingLicenseApplicationID =
                        Convert.ToInt32(
                            reader["LocalDrivingLicenseApplicationID"]);

                    AppointmentDate =
                        Convert.ToDateTime(reader["AppointmentDate"]);

                    PaidFees =
                        Convert.ToDecimal(reader["PaidFees"]);

                    CreatedByUserID =
                        Convert.ToInt32(reader["CreatedByUserID"]);

                    IsLocked =
                        Convert.ToBoolean(reader["IsLocked"]);
                }

                reader.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
        public static int AddNewTestAppointment(
    int TestTypeID,
    int LocalDrivingLicenseApplicationID,
    DateTime AppointmentDate,
    decimal PaidFees,
    int CreatedByUserID)
        {
            int TestAppointmentID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        INSERT INTO TestAppointments
        (
            TestTypeID,
            LocalDrivingLicenseApplicationID,
            AppointmentDate,
            PaidFees,
            CreatedByUserID,
            IsLocked
        )
        VALUES
        (
            @TestTypeID,
            @LocalDrivingLicenseApplicationID,
            @AppointmentDate,
            @PaidFees,
            @CreatedByUserID,
            0
        );

        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue(
                "@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue(
                "@CreatedByUserID",
                CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    TestAppointmentID = Convert.ToInt32(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return TestAppointmentID;
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
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID AS DLAID,
            LicenseClasses.ClassName,
            CONCAT_WS(' ',
                People.FirstName,
                People.SecondName,
                People.ThirdName,
                People.LastName
            ) AS Applicant,

            (
                SELECT COUNT(*)
                FROM TestAppointments TA
                WHERE TA.LocalDrivingLicenseApplicationID =
                      LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                  AND TA.TestTypeID = @TestTypeID
                  AND (
                      @TestAppointmentID = -1
                      OR TA.TestAppointmentID < @TestAppointmentID
                  )
            ) AS Trial,

            TestTypes.TestTypeFees AS TestFees

        FROM LocalDrivingLicenseApplications

        INNER JOIN LicenseClasses
            ON LocalDrivingLicenseApplications.LicenseClassID =
               LicenseClasses.LicenseClassID

        INNER JOIN Applications
            ON LocalDrivingLicenseApplications.ApplicationID =
               Applications.ApplicationID

        INNER JOIN People
            ON Applications.ApplicantPersonID =
               People.PersonID

        INNER JOIN TestTypes
            ON TestTypes.TestTypeID = @TestTypeID

        WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue(
                "@TestTypeID",
                TestTypeID);

            command.Parameters.AddWithValue(
                "@TestAppointmentID",
                TestAppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader =
                    command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    DLAID =
                        Convert.ToInt32(reader["DLAID"]);

                    ClassName =
                        reader["ClassName"].ToString();

                    Applicant =
                        reader["Applicant"].ToString();

                    Trial =
                        Convert.ToInt32(reader["Trial"]);

                    TestFees =
                        Convert.ToDecimal(reader["TestFees"]);
                }

                reader.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }



        public static bool IsThereActiveAppointment(
    int LocalDrivingLicenseApplicationID,
    int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1 TestAppointmentID
        FROM TestAppointments
        WHERE LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
          AND TestTypeID = @TestTypeID
          AND IsLocked = 0;";

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
                    IsFound = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool UpdateTestAppointment(
    int TestAppointmentID,
    DateTime AppointmentDate)
        {
            int RowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        UPDATE TestAppointments
        SET AppointmentDate = @AppointmentDate
        WHERE TestAppointmentID = @TestAppointmentID
          AND IsLocked = 0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@TestAppointmentID",
                TestAppointmentID);

            command.Parameters.AddWithValue(
                "@AppointmentDate",
                AppointmentDate);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }
        public static bool LockTestAppointment(int TestAppointmentID)
        {
            int RowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        UPDATE TestAppointments
        SET IsLocked = 1
        WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@TestAppointmentID",
                TestAppointmentID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }


    }
}
