using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SE_Bank.Models;

namespace SE_Bank.Services
{
    public class UsersDAO
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\FACULTATE\AN3SEM1\SE\SE-Bank\SE-Bank\DataBase\Bank_DataBase.mdf;Integrated Security=True;Connect Timeout=30";
        public UserModel FindUserByNameAndPassword(UserModel user)
        {
            //bool success = false;
            string sqlStatement = "SELECT * FROM dbo.Users WHERE UserName=@username AND Password=@password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //success = true;
                        UserModel userToReturn = new UserModel();
                        while (reader.Read())
                        {
                            userToReturn.Id = Convert.ToInt32(reader["Id"]);
                            userToReturn.UserName = user.UserName;
                            userToReturn.Password = user.Password;
                            userToReturn.Ballance = (float)Convert.ToDouble(reader["Ballance"]);
                            userToReturn.IsAdmin = Convert.ToInt32(reader["IsAdmin"]);
                        }
                        return userToReturn;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            //return success;
            return null;
        }

        private UserModel FindUserByUsername(UserModel user)
        {
            //bool success = false;
            string sqlStatement = "SELECT * FROM dbo.Users WHERE UserName=@username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //success = true;
                        UserModel userToReturn = new UserModel();
                        while (reader.Read())
                        {
                            userToReturn.Id = Convert.ToInt32(reader["Id"]);
                            userToReturn.UserName = user.UserName;
                            userToReturn.Password = user.Password;
                            userToReturn.Ballance = (float)Convert.ToDouble(reader["Ballance"]);
                            userToReturn.IsAdmin = Convert.ToInt32(reader["IsAdmin"]);
                        }
                        return userToReturn;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            //return success;
            return null;
        }

        public UserModel addNewUser(UserModel user)
        {
            UserModel myUser = FindUserByUsername(user);
            if (myUser != null)
            { //already exists
                return null;
            }
            string sqlStatement = "insert into dbo.Users (UserName, Password, Ballance, IsAdmin) values (@username, @password, 0, 0)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return FindUserByNameAndPassword(user);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            //return success;
            return null;
        }
    }
}
