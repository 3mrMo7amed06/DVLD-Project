using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsApplicationData
    {


        public static bool GetApplicationBasicInfo(
            int ApplicationID,
            ref int ApplicantPersonID,
            ref string ApplicationStatus,
            ref decimal PaidFees,
            ref DateTime ApplicationDate,
            ref DateTime LastStatusDate,
            ref string ApplicationType,
            ref string Applicant,
            ref string CreatedBy)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"
                SELECT
                    Applications.ApplicationID,
                   Applications.ApplicantPersonID,


                    CASE Applications.ApplicationStatus
                        WHEN 1 THEN 'New'
                        WHEN 2 THEN 'Cancelled'
                        WHEN 3 THEN 'Completed'
                        ELSE 'Unknown'
                    END AS ApplicationStatus,

                    Applications.PaidFees,
                    Applications.ApplicationDate,
                    Applications.LastStatusDate,

                    ApplicationTypes.ApplicationTypeTitle AS ApplicationType,

                    CONCAT_WS(' ',
                        People.FirstName,
                        People.SecondName,
                        People.ThirdName,
                        People.LastName
                    ) AS Applicant,

                    Users.UserName AS CreatedBy

                FROM Applications

                INNER JOIN ApplicationTypes
                    ON Applications.ApplicationTypeID =
                       ApplicationTypes.ApplicationTypeID

                INNER JOIN People
                    ON Applications.ApplicantPersonID =
                       People.PersonID

                INNER JOIN Users
                    ON Applications.CreatedByUserID =
                       Users.UserID

                WHERE Applications.ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    ApplicantPersonID =
                           Convert.ToInt32(reader["ApplicantPersonID"]);
                    ApplicationStatus =
                        reader["ApplicationStatus"].ToString();

                    PaidFees =
                        Convert.ToDecimal(reader["PaidFees"]);

                    ApplicationDate =
                        Convert.ToDateTime(reader["ApplicationDate"]);

                    LastStatusDate =
                        Convert.ToDateTime(reader["LastStatusDate"]);

                    ApplicationType =
                        reader["ApplicationType"].ToString();

                    Applicant =
                        reader["Applicant"].ToString();

                    CreatedBy =
                        reader["CreatedBy"].ToString();
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

        public static int AddNewApplication(
    int ApplicantPersonID,
    DateTime ApplicationDate,
    int ApplicationTypeID,
    decimal PaidFees,
    int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

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
            1,
            @LastStatusDate,
            @PaidFees,
            @CreatedByUserID
        );

        SELECT SCOPE_IDENTITY();";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicantPersonID",
                ApplicantPersonID);

            command.Parameters.AddWithValue(
                "@ApplicationDate",
                ApplicationDate);

            command.Parameters.AddWithValue(
                "@ApplicationTypeID",
                ApplicationTypeID);

            command.Parameters.AddWithValue(
                "@LastStatusDate",
                ApplicationDate);

            command.Parameters.AddWithValue(
                "@PaidFees",
                PaidFees);

            command.Parameters.AddWithValue(
                "@CreatedByUserID",
                CreatedByUserID);

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


        public static bool IsRetakeApplicationExist(
   int ApplicantPersonID)
        {
            bool IsExist = false;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1 ApplicationID
        FROM Applications
        WHERE ApplicantPersonID = @ApplicantPersonID
          AND ApplicationTypeID = 8
          AND ApplicationStatus = 1;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicantPersonID",
                ApplicantPersonID);

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
        public static int GetRetakeApplicationID(int ApplicantPersonID)
        {
            int ApplicationID = -1;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1 ApplicationID
        FROM Applications
        WHERE ApplicantPersonID = @ApplicantPersonID
          AND ApplicationTypeID = 8
          AND ApplicationStatus = 1
        ORDER BY ApplicationID DESC;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicantPersonID",
                ApplicantPersonID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

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
        public static bool CompleteApplication(int ApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        UPDATE Applications
        SET
            ApplicationStatus = 3,
            LastStatusDate = GETDATE()
        WHERE ApplicationID = @ApplicationID;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicationID",
                ApplicationID);

            try
            {
                connection.Open();

                RowsAffected =
                    command.ExecuteNonQuery();
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
