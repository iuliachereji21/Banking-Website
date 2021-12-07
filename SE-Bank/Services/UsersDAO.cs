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
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bank_DataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
    }

    
}
