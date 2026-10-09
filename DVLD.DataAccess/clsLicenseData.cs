using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsLicenseData
    {
        public static int AddNewLicense(
           int ApplicationID,
           int DriverID,
           int LicenseClass,
           DateTime IssueDate,
           DateTime ExpirationDate,
           string Notes,
           decimal PaidFees,
           bool IsActive,
           int IssueReason,
           int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
                INSERT INTO Licenses
                (
                    ApplicationID,
                    DriverID,
                    LicenseClass,
                    IssueDate,
                    ExpirationDate,
                    Notes,
                    PaidFees,
                    IsActive,
                    IssueReason,
                    CreatedByUserID
                )
                VALUES
                (
                    @ApplicationID,
                    @DriverID,
                    @LicenseClass,
                    @IssueDate,
                    @ExpirationDate,
                    @Notes,
                    @PaidFees,
                    @IsActive,
                    @IssueReason,
                    @CreatedByUserID
                );

                SELECT SCOPE_IDENTITY();";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue(
                "@DriverID", DriverID);

            command.Parameters.AddWithValue(
                "@LicenseClass", LicenseClass);

            command.Parameters.AddWithValue(
                "@IssueDate", IssueDate);

            command.Parameters.AddWithValue(
                "@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue(
                "@Notes",
                string.IsNullOrEmpty(Notes)
                    ? (object)DBNull.Value
                    : Notes);

            command.Parameters.AddWithValue(
                "@PaidFees", PaidFees);

            command.Parameters.AddWithValue(
                "@IsActive", IsActive);

            command.Parameters.AddWithValue(
                "@IssueReason", IssueReason);

            command.Parameters.AddWithValue(
                "@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                if (result != null)
                {
                    LicenseID =
                        Convert.ToInt32(result);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }


        public static bool GetLicenseInfo(
    int LicenseID,
    ref int DriverID,
    ref int PersonID,
    ref int LicenseClassID,
    ref string NationalNo,
    ref string Name,
    ref short Gendor,
    ref DateTime DateOfBirth,
    ref string LicenseClass,
    ref DateTime IssueDate,
    ref DateTime ExpirationDate,
    ref string IssueReason,
    ref string Notes,
    ref string IsActive,
    ref string IsDetained,
    ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            L.DriverID,
            P.PersonID,
            P.NationalNo,

            P.FirstName + ' ' +
            P.SecondName + ' ' +
            ISNULL(P.ThirdName + ' ', '') +
            P.LastName AS FullName,

            P.Gendor,
            P.DateOfBirth,

           L.LicenseClass AS LicenseClassID,
           LC.ClassName AS LicenseClass,

            L.IssueDate,
            L.ExpirationDate,

            CASE
                WHEN L.IssueReason = 1 THEN 'First Time'
                WHEN L.IssueReason = 2 THEN 'Renewal'
                WHEN L.IssueReason = 3 THEN 'Lost'
                WHEN L.IssueReason = 4 THEN 'Damaged'
                ELSE 'Unknown'
            END AS IssueReason,

            ISNULL(L.Notes, 'No notes') AS Notes,

            CASE
                WHEN L.IsActive = 1 THEN 'Yes'
                ELSE 'No'
            END AS IsActive,

            CASE
                WHEN DL.LicenseID IS NOT NULL
                     AND DL.IsReleased = 0
                THEN 'Yes'
                ELSE 'No'
            END AS IsDetained,

            P.ImagePath

        FROM Licenses L

        INNER JOIN Drivers D
            ON L.DriverID = D.DriverID

        INNER JOIN People P
            ON D.PersonID = P.PersonID

INNER JOIN LicenseClasses LC
    ON L.LicenseClass = LC.LicenseClassID

        LEFT JOIN DetainedLicenses DL
            ON L.LicenseID = DL.LicenseID
            AND DL.IsReleased = 0

        WHERE L.LicenseID = @LicenseID;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LicenseID",
                LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader =
                    command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    DriverID =
                        Convert.ToInt32(
                            reader["DriverID"]);

                    PersonID =
                        Convert.ToInt32(
                            reader["PersonID"]);

                    LicenseClassID =
    Convert.ToInt32(
        reader["LicenseClassID"]);

                    NationalNo =
                        reader["NationalNo"].ToString();

                    Name =
                        reader["FullName"].ToString();

                    Gendor =
                        Convert.ToInt16(
                            reader["Gendor"]);

                    DateOfBirth =
                        Convert.ToDateTime(
                            reader["DateOfBirth"]);

                    LicenseClass =
                        reader["LicenseClass"].ToString();

                    IssueDate =
                        Convert.ToDateTime(
                            reader["IssueDate"]);

                    ExpirationDate =
                        Convert.ToDateTime(
                            reader["ExpirationDate"]);

                    IssueReason =
                        reader["IssueReason"].ToString();

                    Notes =
                        reader["Notes"].ToString();

                    IsActive =
                        reader["IsActive"].ToString();

                    IsDetained =
                        reader["IsDetained"].ToString();

                    ImagePath =
                        reader["ImagePath"] == DBNull.Value
                            ? ""
                            : reader["ImagePath"].ToString();
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

        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT LicenseID
        FROM Licenses
        WHERE ApplicationID = @ApplicationID";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicationID",
                ApplicationID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                if (result != null)
                {
                    LicenseID =
                        Convert.ToInt32(result);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }


        public static DataTable GetAllLicensesByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            L.LicenseID,
            L.ApplicationID,
            LC.ClassName,
            L.IssueDate,
            L.ExpirationDate,
            L.IsActive
        FROM Licenses L

        INNER JOIN Drivers D
            ON L.DriverID = D.DriverID

        INNER JOIN LicenseClasses LC
            ON L.LicenseClass = LC.LicenseClassID

        WHERE D.PersonID = @PersonID

        ORDER BY L.IssueDate DESC;";

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
        public static bool DeactivateLicense(int LicenseID)
        {
            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        UPDATE Licenses
        SET IsActive = 0
        WHERE LicenseID = @LicenseID;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LicenseID",
                LicenseID);

            try
            {
                connection.Open();

                int rowsAffected =
                    command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
