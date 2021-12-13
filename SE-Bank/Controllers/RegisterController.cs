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
        private string registerResult = "";
        public IActionResult Index()
        {
            ViewBag.RegisterResult = registerResult;
            return View("RegisterPage");
        }
        public IActionResult ProcessRegister(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();
            UserModel myUser = securityService.IsValidRegister(userModel);
            if (myUser != null)
            {
                UserActionsController userActionsController = new UserActionsController();
                return userActionsController.Index(myUser);
                //return View("UserPage", myUser);
            }
            else
            {
                registerResult = "Username already exists";
                return Index();
            }
        }
    }
}
