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
                return View("LoginSuccess", myUser);
            }
            else
            {
                return View("RegisterFailure", userModel);
            }
        }
    }
}
