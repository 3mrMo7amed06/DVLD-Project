using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsDriverData
    {
        public static int AddNewDriver(
            int PersonID,
            int CreatedByUserID)
        {
            int DriverID = -1;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
                INSERT INTO Drivers
                (
                    PersonID,
                    CreatedByUserID,
                    CreatedDate
                )
                VALUES
                (
                    @PersonID,
                    @CreatedByUserID,
                    GETDATE()
                );

                SELECT SCOPE_IDENTITY();";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@PersonID",
                PersonID);

            command.Parameters.AddWithValue(
                "@CreatedByUserID",
                CreatedByUserID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                if (result != null)
                {
                    DriverID =
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

            return DriverID;
        }


        public static int GetDriverIDByPersonID(int PersonID)
        {
            int DriverID = -1;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT DriverID
        FROM Drivers
        WHERE PersonID = @PersonID";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@PersonID",
                PersonID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                if (result != null)
                {
                    DriverID =
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

            return DriverID;
        }

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            D.DriverID,
            D.PersonID,
            P.NationalNo,
            P.FirstName + ' ' +
            P.SecondName + ' ' +
            ISNULL(P.ThirdName + ' ', '') +
            P.LastName AS FullName,
            D.CreatedDate,
            CASE
                WHEN EXISTS
                (
                    SELECT 1
                    FROM Licenses L
                    WHERE L.DriverID = D.DriverID
                      AND L.IsActive = 1
                )
                THEN 1
                ELSE 0
            END AS ActiveLicense

        FROM Drivers D

        INNER JOIN People P
            ON D.PersonID = P.PersonID

        ORDER BY D.DriverID;";

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

        public static int GetPersonIDByDriverID(int DriverID)
        {
            int PersonID = -1;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT PersonID
        FROM Drivers
        WHERE DriverID = @DriverID;";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@DriverID",
                DriverID);

            try
            {
                connection.Open();

                object result =
                    command.ExecuteScalar();

                if (result != null)
                    PersonID = Convert.ToInt32(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

    }
}
