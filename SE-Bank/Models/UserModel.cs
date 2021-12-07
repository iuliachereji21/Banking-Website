using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE_Bank.Models
{
    using System.ComponentModel.DataAnnotations;
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        public float Ballance { get; set; }
        public int IsAdmin { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
