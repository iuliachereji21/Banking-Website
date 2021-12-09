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
        private bool tableVisible = false;
        public IActionResult Index()
        {
            ViewBag.TableVisibleAdmin = tableVisible;
            //ViewData["TableVisibleAdmin"] = true;
            return View("AdminPage", User);
        }
        [HttpPost]
        public IActionResult GenerateTransactionsReport(UserModel currentUser)
        {
            User = currentUser;
            tableVisible = true;
            return Index();
        }
    }
}
