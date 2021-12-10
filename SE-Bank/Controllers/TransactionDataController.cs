﻿using SE_Bank.Models;
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
        public IActionResult Index()
        {
            List<TransactionModel> lista = new List<TransactionModel>();
            SecurityService securityService = new SecurityService();
            lista = securityService.selectTransactions();
            return View(lista);
        }
    }
}
