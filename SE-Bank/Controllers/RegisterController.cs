using Microsoft.AspNetCore.Mvc;
using SE_Bank.Models;
using SE_Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Bank.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessRegister(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();
            UserModel myUser = securityService.IsValidRegister(userModel);
            if (myUser != null)
            {
                UserActionsController userActionsController = new UserActionsController();
                userActionsController.User = myUser;
                return userActionsController.Index();
                //return View("UserPage", myUser);
            }
            else
            {
                return View("RegisterFailure", userModel);
            }
        }
    }
}
