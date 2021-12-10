using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE_Bank.Models;

namespace SE_Bank.Services
{   
   
    public class SecurityService
    {
      
        UsersDAO usersDAO = new UsersDAO();
        TransactionsDAO transactionsDAO = new TransactionsDAO();
        public SecurityService()
        {
           
        }

        public UserModel IsValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }

        public UserModel IsValidRegister(UserModel user)
        {
            return usersDAO.addNewUser(user);
        }

        public UserModel IsValidUsername(UserModel user)
        {
            return usersDAO.FindUserByUsername(user);
        }

        public UserModel UpdateUser(UserModel user)
        {
            return usersDAO.updateUser(user);
        }

        public TransactionModel addTransaction(TransactionModel transaction)
        {
            return transactionsDAO.addTransaction(transaction);
        }
        public List<TransactionModel> selectTransactions()
        {
            return transactionsDAO.selectTransactions();
        }
    }
}
