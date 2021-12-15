using Microsoft.AspNetCore.Mvc;
using SE_Bank.Models;
using SE_Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Bank.Controllers
{
    public class UserActionsController : Controller
    {
        public Models.UserModel User { get; set; }
        private string transferResultMessage = "";
        private string changeUsernameResultMessage = "";
        private string changePasswordResultMessage = "";
        [HttpGet]
        public IActionResult Index(UserModel user)
        {
            User = user;
            ViewBag.TransferResultMessage = transferResultMessage;
            ViewBag.ChangeUsernameResultMessage = changeUsernameResultMessage;
            ViewBag.ChangePasswordResultMessage = changePasswordResultMessage;
            return View("UserPage", User);
        }

        [HttpPost]
        public IActionResult TransferMoney(string usernameTransfer, string amountTransfer, string usernameCurrentUser,UserModel currentUser)
        {
            User = currentUser;
            SecurityService securityService = new SecurityService();
            UserModel myUser = new UserModel();
            myUser.UserName = usernameTransfer;
            myUser = securityService.IsValidUsername(myUser);
            if (myUser != null)
            {
                //ok
                try
                {
                    float sum = (float)Convert.ToDouble(amountTransfer);
                    if (sum <= 0)
                    {
                        transferResultMessage = "Please specify a valid amount!";
                        return Index(User);
                    }
                    if (sum<= User.Ballance)
                    {
                        //ok
                        TransactionModel transaction = new TransactionModel();
                        transaction.SenderId = User.Id;
                        transaction.ReceiverId = myUser.Id;
                        transaction.Amount = sum;
                        securityService.addTransaction(transaction);
                        User.Ballance = User.Ballance - sum;
                        securityService.UpdateUser(User);
                        myUser.Ballance = myUser.Ballance + sum;
                        securityService.UpdateUser(myUser);
                        transferResultMessage = "Transfer completed successfully!";
                        return Index(User);

                    }
                    else
                    {
                        //fail
                        transferResultMessage = "Insufficient funds!";
                        return Index(User);
                    }
                }
                catch
                {
                    //fail
                    transferResultMessage = "Amount is not a valid number!";
                    return Index(User);
                }
                
            }
            else
            {
                //fail
                transferResultMessage = "Username does not exist!";
                return Index(User);
            }
            //return View("TransferResult",new Models.TransactionModel());
        }


        [HttpPost]
        public IActionResult UpdateUserByPassword(string new_password, string old_password, UserModel currentUser)
        {
            User = currentUser;
            SecurityService securityService = new SecurityService();
            if(old_password==null || old_password == "")
            {
                changePasswordResultMessage = "Old password required";
                return Index(User);
            }
            if (new_password == null || new_password == "")
            {
                changePasswordResultMessage = "New password required";
                return Index(User);
            }
            if (String.Equals(old_password, User.Password))
            {
                User= securityService.updateUserByPassword(User, new_password);
                changePasswordResultMessage = "Password updated successfully";
                return Index(User);
            }
            else changePasswordResultMessage = "Incorrect old password";
            return Index(User);
        }

        [HttpPost]
        public IActionResult UpdateUsername(string new_username, UserModel currentUser)
        {
            User = currentUser;
            SecurityService securityService = new SecurityService();
            if(new_username == null || new_username == "")
            {
                changeUsernameResultMessage = "Required";
                return Index(User);
            }
            UserModel existingUser = new UserModel();
            existingUser.UserName = new_username;
            existingUser = securityService.IsValidUsername(existingUser);
            if (existingUser != null)
            {
                changeUsernameResultMessage = "Username already exists";
                return Index(User);
            }
            
            User=securityService.updateUsername(User, new_username);
            if (User == null)
            {
                changeUsernameResultMessage = "Error";
                return Index(User);
            }
            changeUsernameResultMessage = "Username updates successfully";
            return Index(User);
        }
    }
}
