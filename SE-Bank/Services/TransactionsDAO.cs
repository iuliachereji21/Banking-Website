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
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=D:\FACULTATE\AN3SEM1\SE\SE-BANK\SE-BANK\DATABASE\BANK_DATABASE.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public TransactionModel addTransaction(TransactionModel transaction)
        { //adds a new transaction to the database
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
        public List<TransactionModel> selectTransactions()
        {//gets all transactions from the database
            List<TransactionModel> lista_tranzactii = new List<TransactionModel>();
            string sqlStatement = "SELECT * FROM dbo.Transactions";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();



                    if (reader.HasRows)
                    {
                        //success = true;
                        
                        while (reader.Read())
                        {
                            TransactionModel transactionToReturn = new TransactionModel();
                            transactionToReturn.Id = Convert.ToInt32(reader["Id"]);
                            transactionToReturn.SenderId = Convert.ToInt32(reader["SenderId"]);
                            transactionToReturn.ReceiverId = Convert.ToInt32(reader["ReceiverId"]);
                            transactionToReturn.Amount = Convert.ToInt32(reader["Amount"]);
                            lista_tranzactii.Add(transactionToReturn);

                        }
                        return lista_tranzactii;
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

        public List<TransactionModel> selectTransactionsWithId(int id_sender)
        { //gets all transactions for a user
            List<TransactionModel> lista_tranzactii = new List<TransactionModel>();
            string sqlStatement = "SELECT * FROM dbo.Transactions where SenderId=@id";





            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);





                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id_sender;




                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();





                    if (reader.HasRows)
                    {
                        //success = true;
                        while (reader.Read())
                        {
                            TransactionModel transactionToReturn = new TransactionModel();
                            transactionToReturn.Id = Convert.ToInt32(reader["Id"]);
                            transactionToReturn.SenderId = Convert.ToInt32(reader["SenderId"]);
                            transactionToReturn.ReceiverId = Convert.ToInt32(reader["ReceiverId"]);
                            transactionToReturn.Amount = Convert.ToInt32(reader["Amount"]);
                            lista_tranzactii.Add(transactionToReturn);





                        }
                        return lista_tranzactii;
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