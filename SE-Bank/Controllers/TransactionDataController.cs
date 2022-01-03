using SE_Bank.Models;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SE_Bank.Models;
using SE_Bank.Services;namespace SE_Bank.Controllers
{
    public class TransactionDataController : Controller
    {
        [HttpPost]
        public IActionResult AllTransactions(UserModel currentUser)
        { //get to all transactions page from admin page
            ViewData["currentUser"] = currentUser;
            List<TransactionModel> lista = new List<TransactionModel>();
            SecurityService securityService = new SecurityService();
            lista = securityService.selectTransactions();
            return View(lista);
        }

        [HttpPost]
        public IActionResult UserTransactions(UserModel currentUser)
        { //get to user's specific transactions from user page
            ViewData["currentUser"] = currentUser;
            List<TransactionModel> lista = new List<TransactionModel>();
            SecurityService securityService = new SecurityService();
            lista = securityService.selectTransactionsWithId(currentUser.Id);
            return View(lista);
        }
    }
}

