using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectOnlineShopping.Models
{
    public class LoginVM
    {
        [Key]
        [Required(ErrorMessage = "Please enter your phone number")]
        [DisplayName("Phone Number")]
        public string phoneNo { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}