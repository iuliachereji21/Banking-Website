﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Bank.Controllers
{
    public class UserActionsController : Controller
    {
        public Models.UserModel User { get; set; }
        public IActionResult Index()
        {
            return View("UserPage", User);
        }

        public int TransferMoney()
        {
            return 0;
        }
    }
}
