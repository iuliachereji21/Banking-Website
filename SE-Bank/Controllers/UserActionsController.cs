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
        public IActionResult TransferMoney(string usernameTransfer, string amountTransfer)
        {
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
                        User.Ballance = User.Ballance - sum;
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
