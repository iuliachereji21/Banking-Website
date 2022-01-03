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
        { //used for log in
            return usersDAO.FindUserByNameAndPassword(user);
        }

        public UserModel IsValidRegister(UserModel user)
        { //used for register
            return usersDAO.addNewUser(user);
        }

        public UserModel IsValidUsername(UserModel user)
        { //used when a user wants to update it's username
          //used when a user wants to transfer money, to check if the inserted username exists
            return usersDAO.FindUserByUsername(user);
        }

        public UserModel UpdateUser(UserModel user)
        { //used to update the user after the transfer is successful
            return usersDAO.updateUser(user);
        }

        public TransactionModel addTransaction(TransactionModel transaction)
        { //adds a new transaction to the database
            return transactionsDAO.addTransaction(transaction);
        }
        public List<TransactionModel> selectTransactions()
        { //gets all transactions from the database
            return transactionsDAO.selectTransactions();
        }

        public List<TransactionModel> selectTransactionsWithId(int id_user)
        { //gets all transactions for a user
            return transactionsDAO.selectTransactionsWithId(id_user);
        }

        public UserModel removeUser(UserModel user)
        { //when an admin delets an user
            return usersDAO.removeUser(user);
        }

        public UserModel updateUserByPassword(UserModel user, string new_password)
        { //update user's password
            return usersDAO.updateUserByPassword(user, new_password);
        }
        public UserModel updateUsername(UserModel user, string new_username)
        {//update user's username
            return usersDAO.updateUsername(user, new_username);
        }
    }
}
