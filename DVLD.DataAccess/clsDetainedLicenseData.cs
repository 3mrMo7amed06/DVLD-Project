using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsDetainedLicenseData
    {
        public static int AddNewDetainedLicense(
           int LicenseID,
           DateTime DetainDate,
           decimal FineFees,
           int CreatedByUserID)
        {
            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
                INSERT INTO DetainedLicenses
                (
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased
                )
                VALUES
                (
                    @LicenseID,
                    @DetainDate,
                    @FineFees,
                    @CreatedByUserID,
                    0
                );

                SELECT SCOPE_IDENTITY();";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LicenseID",
                LicenseID);

            command.Parameters.AddWithValue(
                "@DetainDate",
                DetainDate);

            command.Parameters.AddWithValue(
                "@FineFees",
                FineFees);

            command.Parameters.AddWithValue(
                "@CreatedByUserID",
                CreatedByUserID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                if (result != null)
                    return Convert.ToInt32(result);

                return -1;
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

        public static bool IsLicenseDetained(int LicenseID)
        {
            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1 1
        FROM DetainedLicenses
        WHERE LicenseID = @LicenseID
          AND IsReleased = 0;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LicenseID",
                LicenseID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                return result != null;
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

        public static bool GetDetainedLicenseInfoByLicenseID(
    int LicenseID,
    ref int DetainID,
    ref DateTime DetainDate,
    ref decimal FineFees,
    ref int CreatedByUserID,
    ref bool IsReleased)
        {
            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP 1
            DetainID,
            DetainDate,
            FineFees,
            CreatedByUserID,
            IsReleased
        FROM DetainedLicenses
        WHERE LicenseID = @LicenseID
        ORDER BY DetainID DESC;";

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
                    DetainID =
                        (int)reader["DetainID"];

                    DetainDate =
                        (DateTime)reader["DetainDate"];

                    FineFees =
                        (decimal)reader["FineFees"];

                    CreatedByUserID =
                        (int)reader["CreatedByUserID"];

                    IsReleased =
                        (bool)reader["IsReleased"];

                    return true;
                }

                return false;
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

        public static bool ReleaseDetainedLicense(
    int DetainID,
    DateTime ReleaseDate,
    int ReleasedByUserID,
    int ReleaseApplicationID)
        {
            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        UPDATE DetainedLicenses
        SET
            IsReleased = 1,
            ReleaseDate = @ReleaseDate,
            ReleasedByUserID = @ReleasedByUserID,
            ReleaseApplicationID = @ReleaseApplicationID
        WHERE DetainID = @DetainID
          AND IsReleased = 0;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@DetainID",
                DetainID);

            command.Parameters.AddWithValue(
                "@ReleaseDate",
                ReleaseDate);

            command.Parameters.AddWithValue(
                "@ReleasedByUserID",
                ReleasedByUserID);

            command.Parameters.AddWithValue(
                "@ReleaseApplicationID",
                ReleaseApplicationID);

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


        public static DataTable GetAllDetainedLicenses()
        {
            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            DetainedLicenses.DetainID AS D_ID,
            DetainedLicenses.LicenseID AS L_ID,
            DetainedLicenses.DetainDate AS D_DATE,
            DetainedLicenses.IsReleased AS IsReleased,
            DetainedLicenses.FineFees AS FineFees,
            DetainedLicenses.ReleaseDate AS ReleaseDate,
            People.PersonID AS PersonID,
            People.NationalNo AS N_NO,
            People.FirstName + ' ' +
            People.SecondName + ' ' +
            ISNULL(People.ThirdName + ' ', '') +
            People.LastName AS FullName,
            DetainedLicenses.ReleaseApplicationID AS ReleaseAppID
        FROM DetainedLicenses
        INNER JOIN Licenses
            ON DetainedLicenses.LicenseID = Licenses.LicenseID
        INNER JOIN Drivers
            ON Licenses.DriverID = Drivers.DriverID
        INNER JOIN People
            ON Drivers.PersonID = People.PersonID
        ORDER BY DetainedLicenses.DetainID DESC;";

            SqlCommand command =
                new SqlCommand(query, connection);

            DataTable dataTable =
                new DataTable();

            try
            {
                connection.Open();

                SqlDataReader reader =
                    command.ExecuteReader();

                if (reader.HasRows)
                    dataTable.Load(reader);

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

            return dataTable;
        }


    }
}
