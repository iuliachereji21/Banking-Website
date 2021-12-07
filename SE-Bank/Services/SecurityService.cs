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
        public SecurityService()
        {
           
        }

        public UserModel IsValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
            
        }
    }
}
