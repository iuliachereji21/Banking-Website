using Microsoft.AspNetCore.Mvc;
using SE_Bank.Models;
using SE_Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Bank.Controllers
{
    public class AdminActionsController : Controller
    {
        public Models.UserModel User { get; set; }
        private string closeAccountResultMessage = "";
        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            User = user;
            if (user.IsAdmin == 0)
            {
                UserActionsController userActionsController = new UserActionsController();
                return userActionsController.Index(user);
            }
            ViewBag.CloseAccountResultMessage = closeAccountResultMessage;
            return View("AdminPage", User);
        }

        public IActionResult Index2(string name)
        {
            SecurityService securityService = new SecurityService();
            UserModel user = new UserModel();
            user.UserName = name;
            user = securityService.IsValidUsername(user);
            return Index(user);
            /*User = user;
            if (user.IsAdmin == 0)
            {
                UserActionsController userActionsController = new UserActionsController();
                return userActionsController.Index(user);
            }
            ViewBag.CloseAccountResultMessage = closeAccountResultMessage;
            return View("AdminPage", User);*/
        }

        public IActionResult GenerateTransactionsReport(UserModel currentUser)
        {
            User = currentUser;
            return Index(User);
        }

        [HttpPost]
        public IActionResult CloseAccount(string user, UserModel currentUser)
        {
            User = currentUser;
            SecurityService securityService = new SecurityService();
            UserModel myUser = new UserModel();
            myUser.UserName = user;
            myUser = securityService.IsValidUsername(myUser);
            if (myUser != null)
            {
                //ok
                try
                {
                    securityService.removeUser(myUser);
                    closeAccountResultMessage = "User account closed successfully!";
                    return Index(User);
                }
                catch
                {
                    //fail
                    closeAccountResultMessage = "Close account failed!";
                    return Index(User);
                }



            }
            else
            {
                //fail
                closeAccountResultMessage = "Username does not exist!";
                return Index(User);
            }
            //return View("TransferResult",new Models.TransactionModel());

        }
    }
}
