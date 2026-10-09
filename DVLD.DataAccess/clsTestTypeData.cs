using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsTestTypeData
    {
        public static bool GetTestTypeInfoByID(
   int TestTypeID,
   ref string TestTypeTitle,
   ref string TestTypeDescription,
   ref decimal TestTypeFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                     FROM TestTypes
                     WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeTitle =
                        (string)reader["TestTypeTitle"];
                    TestTypeDescription =
                        (string)reader["TestTypeDescription"];
                    TestTypeFees =
                        (decimal)reader["TestTypeFees"];
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
        public static bool UpdateTestType(
   int TestTypeID,
     string TestTypeTitle,
     string TestTypeDescription,
     decimal TestTypeFees)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestTypes
                     SET TestTypeTitle = @TestTypeTitle,
                         TestTypeDescription = @TestTypeDescription,
                         TestTypeFees = @TestTypeFees
                     WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@TestTypeID", TestTypeID);

            command.Parameters.AddWithValue(
                "@TestTypeTitle", TestTypeTitle);

            command.Parameters.AddWithValue(
                "@TestTypeDescription", TestTypeDescription);

            command.Parameters.AddWithValue(
               "@TestTypeFees", TestTypeFees);

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
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                     FROM TestTypes
                     ORDER BY TestTypeID";

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
    }
}
