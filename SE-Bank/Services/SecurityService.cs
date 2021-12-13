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

        public List<TransactionModel> getAllTransactions()
        {
            return transactionsDAO.selectTransactions();
        }
        public List<TransactionModel> selectTransactionsWithId(int id_user)
        {
            return transactionsDAO.selectTransactionsWithId(id_user);
        }

        public UserModel removeUser(UserModel user)
        {
            return usersDAO.removeUser(user);
        }

        public UserModel updateUserByPassword(UserModel user, string new_password)
        {
            return usersDAO.updateUserByPassword(user, new_password);
        }
        public UserModel updateUsername(UserModel user, string new_username)
        {
            return usersDAO.updateUsername(user, new_username);
        }
    }
}
