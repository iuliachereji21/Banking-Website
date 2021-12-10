using Microsoft.AspNetCore.Mvc;
using SE_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Bank.Controllers
{
    public class AdminActionsController : Controller
    {
        public Models.UserModel User { get; set; }
        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            User = user;
            return View("AdminPage", User);
        }
        
        public IActionResult GenerateTransactionsReport(UserModel currentUser)
        {
            User = currentUser;
            return Index(User);
        }
    }
}
