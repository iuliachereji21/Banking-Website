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
        public IActionResult Index()
        {
            return View();
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
                    userActionsController.User = myUser;
                    return userActionsController.Index();
                    //return View("UserPage", myUser);
                }
                else {
                    AdminActionsController adminActionsController = new AdminActionsController();
                    adminActionsController.User = myUser;
                    return adminActionsController.Index();
                    //return View("AdminPage", myUser);
                }
            }
            else
            {
                return View("LoginFailure", userModel);
            }
        }
    }
}
