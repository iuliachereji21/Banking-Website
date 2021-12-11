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
        {
            ViewData["currentUser"] = currentUser;
            List<TransactionModel> lista = new List<TransactionModel>();
            SecurityService securityService = new SecurityService();
            lista = securityService.selectTransactions();
            return View(lista);
        }

        [HttpPost]
        public IActionResult UserTransactions(UserModel currentUser)
        {
            ViewData["currentUser"] = currentUser;
            List<TransactionModel> lista = new List<TransactionModel>();
            SecurityService securityService = new SecurityService();
            lista = securityService.selectTransactionsWithId(currentUser.Id);
            return View(lista);
        }
        /*public IActionResult Index2(int sender_id)
        {
            //int sender_id = 1;
            List<TransactionModel> lista = new List<TransactionModel>();
            SecurityService securityService = new SecurityService();
            lista = securityService.selectTransactionsWithId(sender_id);
            return View("UserTransactions",lista);
        }*/
    }
}

