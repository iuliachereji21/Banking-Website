using Microsoft.AspNetCore.Mvc;
using SE_Bank.Models;
using SE_Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Bank.Controllers
{
    public class UserActionsController : Controller
    {
        public Models.UserModel User { get; set; }
        [HttpGet]
        public IActionResult Index()
        {
            return View("UserPage", User);
        }

        [HttpPost]
        public IActionResult TransferMoney(string usernameTransfer, string amountTransfer, string usernameCurrentUser,UserModel currentUser)
        {
            User = currentUser;
            SecurityService securityService = new SecurityService();
            UserModel myUser = new UserModel();
            myUser.UserName = usernameTransfer;
            myUser = securityService.IsValidUsername(myUser);
            if (myUser != null)
            {
                //ok
                try
                {
                    float sum = (float)Convert.ToDouble(amountTransfer);
                    if (sum<= User.Ballance)
                    {
                        //ok
                        TransactionModel transaction = new TransactionModel();
                        transaction.SenderId = User.Id;
                        transaction.ReceiverId = myUser.Id;
                        transaction.Amount = sum;
                        securityService.addTransaction(transaction);
                        User.Ballance = User.Ballance - sum;
                        securityService.UpdateUser(User);
                        myUser.Ballance = myUser.Ballance + sum;
                        securityService.UpdateUser(myUser);

                        return Index();

                    }
                    else
                    {
                        //fail
                    }
                }
                catch
                {
                    //fail
                }
                
            }
            else
            {
                //fail
            }
            return View("TransferResult",new Models.TransactionModel());
        }
    }
}
