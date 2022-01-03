using Microsoft.AspNetCore.Mvc;
using SE_Bank.Models;
using SE_Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Bank.Controllers
{
    public class LogInController : Controller
    {
        private string logInResult = "";
        public IActionResult Index()
        {
            ViewBag.LogInResult = logInResult;
            return View("LogInPage");
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();
            UserModel myUser = securityService.IsValid(userModel);
            if (myUser!=null)
            {
                if (myUser.IsAdmin == 0)
                {
                    UserActionsController userActionsController = new UserActionsController();
                    return userActionsController.Index(myUser);
                }
                else {
                    AdminActionsController adminActionsController = new AdminActionsController();
                    return adminActionsController.Index(myUser);
                }
            }
            else
            {
                logInResult = "Failed to log in";
                return Index();
            }
        }
    }
}
