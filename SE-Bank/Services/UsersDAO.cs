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
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=D:\FACULTATE\AN3SEM1\SE\SE-BANK\SE-BANK\DATABASE\BANK_DATABASE.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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

        public UserModel FindUserByUsername(UserModel user)
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
                            userToReturn.Password = Convert.ToString(reader["Password"]); ;
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
        public UserModel updateUser(UserModel user)
        {
            UserModel myUser = FindUserByUsername(user);
            if (myUser == null)
            { //didn't find
                return null;
            }
            string sqlStatement = "update dbo.Users set UserName = @username, Password = @password, Ballance = @ballance, IsAdmin = @isadmin where Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;
                command.Parameters.Add("@ballance", System.Data.SqlDbType.Float).Value = user.Ballance;
                command.Parameters.Add("@isadmin", System.Data.SqlDbType.Int).Value = user.IsAdmin;
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = user.Id;
                string comm = command.CommandText;

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
            
            return null;
        }
        public UserModel removeUser(UserModel user)
        {
            UserModel myUser = FindUserByUsername(user);
            if (myUser == null)
            { //didn't find
                return null;
            }
            string sqlStatement = "DELETE FROM dbo.Users WHERE UserName = @username ";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);



                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                string comm = command.CommandText;



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



            return null;
        }
    }
}
