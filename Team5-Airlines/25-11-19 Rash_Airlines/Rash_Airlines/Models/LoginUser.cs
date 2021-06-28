using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rash_Airlines.Models
{
    public class LoginUser
    {
        [Key]
        [Display(Name = "Email")]
        [Required(ErrorMessage ="Please fill this field")]
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please fill this field")]
        public string pwd { get; set; }


    }
}