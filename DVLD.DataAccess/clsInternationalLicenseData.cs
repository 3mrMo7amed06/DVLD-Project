using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsInternationalLicenseData
    {

        public static DataTable GetAllInternationalLicensesByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            IL.InternationalLicenseID,
            IL.ApplicationID,
            IL.IssuedUsingLocalLicenseID,
            IL.IssueDate,
            IL.ExpirationDate,
            IL.IsActive
        FROM InternationalLicenses IL

        INNER JOIN Drivers D
            ON IL.DriverID = D.DriverID

        WHERE D.PersonID = @PersonID

        ORDER BY IL.IssueDate DESC;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@PersonID",
                PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader =
                    command.ExecuteReader();

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

        public static int AddNewInternationalLicense(
    int ApplicationID,
    int DriverID,
    int IssuedUsingLocalLicenseID,
    DateTime IssueDate,
    DateTime ExpirationDate,
    bool IsActive,
    int CreatedByUserID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        INSERT INTO InternationalLicenses
        (
            ApplicationID,
            DriverID,
            IssuedUsingLocalLicenseID,
            IssueDate,
            ExpirationDate,
            IsActive,
            CreatedByUserID
        )
        VALUES
        (
            @ApplicationID,
            @DriverID,
            @IssuedUsingLocalLicenseID,
            @IssueDate,
            @ExpirationDate,
            @IsActive,
            @CreatedByUserID
        );

        SELECT SCOPE_IDENTITY();";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicationID",
                ApplicationID);

            command.Parameters.AddWithValue(
                "@DriverID",
                DriverID);

            command.Parameters.AddWithValue(
                "@IssuedUsingLocalLicenseID",
                IssuedUsingLocalLicenseID);

            command.Parameters.AddWithValue(
                "@IssueDate",
                IssueDate);

            command.Parameters.AddWithValue(
                "@ExpirationDate",
                ExpirationDate);

            command.Parameters.AddWithValue(
                "@IsActive",
                IsActive);

            command.Parameters.AddWithValue(
                "@CreatedByUserID",
                CreatedByUserID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                if (result != null)
                    InternationalLicenseID =
                        Convert.ToInt32(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return InternationalLicenseID;
        }

        public static bool IsInternationalLicenseExistByDriverID(int DriverID)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1 1
        FROM InternationalLicenses
        WHERE DriverID = @DriverID
          AND IsActive = 1;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

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
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            IL.ApplicationID,
            IL.DriverID,
            IL.IssuedUsingLocalLicenseID AS LicenseID,
            P.NationalNo,
            P.FirstName + ' ' +
            P.SecondName + ' ' +
            ISNULL(P.ThirdName + ' ', '') +
            P.LastName AS FullName,
            P.Gendor AS Gender,
            P.DateOfBirth,
P.ImagePath,
            IL.IssueDate,
            IL.ExpirationDate,
            IL.IsActive
        FROM InternationalLicenses IL

        INNER JOIN Drivers D
            ON IL.DriverID = D.DriverID

        INNER JOIN People P
            ON D.PersonID = P.PersonID

        WHERE IL.InternationalLicenseID = @InternationalLicenseID;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@InternationalLicenseID",
                InternationalLicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader =
                    command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID =
                        Convert.ToInt32(reader["ApplicationID"]);

                    DriverID =
                        Convert.ToInt32(reader["DriverID"]);

                    LicenseID =
                        Convert.ToInt32(reader["LicenseID"]);

                    NationalNo =
                        reader["NationalNo"].ToString();

                    FullName =
                        reader["FullName"].ToString();

                    Gender =
                        Convert.ToInt16(reader["Gender"]);

                    DateOfBirth =
                        Convert.ToDateTime(reader["DateOfBirth"]);

                    ImagePath =
    reader["ImagePath"].ToString();

                    IssueDate =
                        Convert.ToDateTime(reader["IssueDate"]);

                    ExpirationDate =
                        Convert.ToDateTime(reader["ExpirationDate"]);

                    IsActive =
                        Convert.ToBoolean(reader["IsActive"]);
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

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            InternationalLicenseID,
            ApplicationID,
            DriverID,
            IssuedUsingLocalLicenseID,
            IssueDate,
            ExpirationDate,
            IsActive
        FROM InternationalLicenses
        ORDER BY IssueDate DESC;";

            SqlCommand command =
                new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader =
                    command.ExecuteReader();

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


    }
}
