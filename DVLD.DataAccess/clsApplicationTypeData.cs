using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsApplicationTypeData
    {
        public static bool GetApplicationTypeInfoByID(
    int ApplicationTypeID,
    ref string ApplicationTypeTitle,
    ref decimal ApplicationFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                     FROM ApplicationTypes
                     WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID",  ApplicationTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationTypeTitle =
                        (string)reader["ApplicationTypeTitle"];

                    ApplicationFees =
                        (decimal)reader["ApplicationFees"];
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

            return isFound;
        }
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                     FROM ApplicationTypes
                     ORDER BY ApplicationTypeID";

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
        public static bool UpdateApplicationType(
    int ApplicationTypeID,
    string ApplicationTypeTitle,
    decimal ApplicationFees)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE ApplicationTypes
                     SET ApplicationTypeTitle = @ApplicationTypeTitle,
                         ApplicationFees = @ApplicationFees
                     WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@ApplicationTypeID", ApplicationTypeID);

            command.Parameters.AddWithValue(
                "@ApplicationTypeTitle", ApplicationTypeTitle);

            command.Parameters.AddWithValue(
                "@ApplicationFees", ApplicationFees);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
}
