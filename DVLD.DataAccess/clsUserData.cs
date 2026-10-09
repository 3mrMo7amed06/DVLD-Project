using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class clsUserData
    {

        public static bool GetUserInfoByUserNameAndPassword(string UserName,
                                                            string Password,
                                                             ref int UserID,
                                                            ref int PersonID,
                                                               ref bool IsActive)

        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password AND IsActive = 1 ";
     
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
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
        public static bool GetUserInfoByUserID(
    int UserID,
    ref int PersonID,
    ref string UserName,
    ref string Password,
    ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
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

        public static int AddNewUser(int PersonID,
    string UserName,
    string Password,
    bool IsActive)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Users
                    (PersonID, UserName, Password, IsActive)
                      VALUES
                    (@PersonID, @UserName, @Password, @IsActive);

                  SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
          

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }
            }

            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                throw;
            }

            finally
            {
                connection.Close();
            }


            return UserID;
        }
        public static bool UpdateUser(int UserID, int PersonID, string UserName
    , string Password, bool IsActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Users
         SET PersonID = @PersonID,
             UserName = @UserName,
             Password = @Password,
             IsActive = @IsActive
         WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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

            return (rowsAffected > 0);
        }
        public static bool IsPersonLinkedToUser(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT UserID
                     FROM Users
                     WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                isFound = (result != null);
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
        public static bool DeleteUser(int UserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE Users
                     WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                // Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }
        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //string query = "SELECT * FROM People ORDER BY FirstName";
            string query = @"SELECT
                    Users.UserID,
                    Users.PersonID,
                    CONCAT_WS(' ',
                        People.FirstName,
                        People.SecondName,
                        People.ThirdName,
                        People.LastName
                    ) AS FullName,
                    Users.UserName,
                    Users.IsActive
                 FROM Users
                 INNER JOIN People
                    ON Users.PersonID = People.PersonID
                 ORDER BY Users.UserID";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
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

            return dt;

        }
        public static bool IsUserNameExist(string UserName, int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);

            string query = @"SELECT UserID 
                     FROM Users 
                     WHERE UserName = @UserName
                     AND UserID <> @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                isFound = (result != null);
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

    }
}
