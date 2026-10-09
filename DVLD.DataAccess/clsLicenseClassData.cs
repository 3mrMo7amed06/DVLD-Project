using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsLicenseClassData
    {


        public static DataTable GetAllLicenseClasses()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT
                        LicenseClassID,
                        ClassName
                     FROM LicenseClasses
                     ORDER BY LicenseClassID;";

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

        public static bool GetLicenseClassInfo(
    int LicenseClassID,
    ref int DefaultValidityLength,
    ref decimal ClassFees)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(
                    clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT
            DefaultValidityLength,
            ClassFees
        FROM LicenseClasses
        WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command =
                new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@LicenseClassID",
                LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader =
                    command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    DefaultValidityLength =
                        Convert.ToInt32(
                            reader["DefaultValidityLength"]);

                    ClassFees =
                        Convert.ToDecimal(
                            reader["ClassFees"]);
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
