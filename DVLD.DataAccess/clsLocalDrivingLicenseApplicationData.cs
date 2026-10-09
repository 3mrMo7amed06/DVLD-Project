using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {

        public static bool IsApplicationExist(
    int ApplicantPersonID,
    int LicenseClassID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1 1
        FROM Applications
        INNER JOIN LocalDrivingLicenseApplications
            ON Applications.ApplicationID =
               LocalDrivingLicenseApplications.ApplicationID
        WHERE Applications.ApplicantPersonID = @ApplicantPersonID
          AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
          AND Applications.ApplicationStatus IN (1, 3);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicantPersonID", ApplicantPersonID);

            command.Parameters.AddWithValue(
                "@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

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
        public static int AddNewLocalDrivingLicenseApplication(
    int ApplicantPersonID,
    int ApplicationTypeID,
    short ApplicationStatus,
    DateTime LastStatusDate,
    decimal PaidFees,
    int CreatedByUserID,
    int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"
        INSERT INTO Applications
        (
            ApplicantPersonID,
            ApplicationDate,
            ApplicationTypeID,
            ApplicationStatus,
            LastStatusDate,
            PaidFees,
            CreatedByUserID
        )
        VALUES
        (
            @ApplicantPersonID,
            @ApplicationDate,
            @ApplicationTypeID,
            @ApplicationStatus,
            @LastStatusDate,
            @PaidFees,
            @CreatedByUserID
        );

        DECLARE @ApplicationID INT;
        SET @ApplicationID = SCOPE_IDENTITY();

        INSERT INTO LocalDrivingLicenseApplications
        (
            ApplicationID,
            LicenseClassID
        )
        VALUES
        (
            @ApplicationID,
            @LicenseClassID
        );

        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    LocalDrivingLicenseApplicationID = Convert.ToInt32(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return LocalDrivingLicenseApplicationID;
        }
        public static bool CancelApplication(int ApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"
        UPDATE Applications
        SET
            ApplicationStatus = 2,
            LastStatusDate = @LastStatusDate
        WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue(
                "@LastStatusDate", DateTime.Now);

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

            return (RowsAffected > 0);
        }

        public static bool GetDLAInfo(
    int LocalDrivingLicenseApplicationID,
    ref int DLAID,
    ref string ClassName,
    ref int PassedTests)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID AS DLAID,
            LicenseClasses.ClassName,

            (
                SELECT COUNT(*)
                FROM TestAppointments
                INNER JOIN Tests
                    ON TestAppointments.TestAppointmentID =
                       Tests.TestAppointmentID
                WHERE TestAppointments.LocalDrivingLicenseApplicationID =
                      LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                  AND Tests.TestResult = 1
            ) AS PassedTests

        FROM LocalDrivingLicenseApplications

        INNER JOIN LicenseClasses
            ON LocalDrivingLicenseApplications.LicenseClassID =
               LicenseClasses.LicenseClassID

        WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);

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

                    PassedTests =
                        Convert.ToInt32(reader["PassedTests"]);
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
        public static int GetApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT ApplicationID
        FROM LocalDrivingLicenseApplications
        WHERE LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    ApplicationID = Convert.ToInt32(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return ApplicationID;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT
         LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
        Applications.ApplicationID,
        LicenseClasses.ClassName,
        People.NationalNo,

        CONCAT_WS(' ',
            People.FirstName,
            People.SecondName,
            People.ThirdName,
            People.LastName
        ) AS FullName,

        Applications.ApplicationDate,

        (
            SELECT COUNT(*)
            FROM TestAppointments
            INNER JOIN Tests
                ON TestAppointments.TestAppointmentID =
                   Tests.TestAppointmentID
            WHERE TestAppointments.LocalDrivingLicenseApplicationID =
                  LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
              AND Tests.TestResult = 1
        ) AS PassedTests,

        CASE Applications.ApplicationStatus
            WHEN 1 THEN 'New'
            WHEN 2 THEN 'Cancelled'
            WHEN 3 THEN 'Completed'
            ELSE 'Unknown'
        END AS ApplicationStatus

    FROM LocalDrivingLicenseApplications

    INNER JOIN Applications
        ON LocalDrivingLicenseApplications.ApplicationID =
           Applications.ApplicationID

    INNER JOIN LicenseClasses
        ON LocalDrivingLicenseApplications.LicenseClassID =
           LicenseClasses.LicenseClassID

    INNER JOIN People
        ON Applications.ApplicantPersonID =
           People.PersonID

    ORDER BY
        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
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

       public static bool GetPersonAndLicenseClass(
    int LocalDrivingLicenseApplicationID,
    ref int ApplicantPersonID,
    ref int LicenseClassID)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            Applications.ApplicantPersonID,
            LocalDrivingLicenseApplications.LicenseClassID
        FROM LocalDrivingLicenseApplications

        INNER JOIN Applications
            ON LocalDrivingLicenseApplications.ApplicationID =
               Applications.ApplicationID

        WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader =
                    command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicantPersonID =
                        Convert.ToInt32(reader["ApplicantPersonID"]);

                    LicenseClassID =
                        Convert.ToInt32(reader["LicenseClassID"]);
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
    }
}
