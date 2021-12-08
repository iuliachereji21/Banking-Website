using SE_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SE_Bank.Services
{
    public class TransactionsDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=D:\FACULTATE\AN3SEM1\SE\SE-BANK\SE-BANK\DATABASE\BANK_DATABASE.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public TransactionModel addTransaction(TransactionModel transaction)
        {
            string sqlStatement = "insert into dbo.Transactions (SenderId, ReceiverId, Amount) values (@senderid, @receiverid, @amount)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = transaction.Id;
                //command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = 1;
                command.Parameters.Add("@senderid", System.Data.SqlDbType.Int).Value = transaction.SenderId;
                command.Parameters.Add("@receiverid", System.Data.SqlDbType.Int).Value = transaction.ReceiverId;
                command.Parameters.Add("@amount", System.Data.SqlDbType.Float).Value = transaction.Amount;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    return transaction;


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