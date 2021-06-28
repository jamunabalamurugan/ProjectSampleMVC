using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBankingProject.Models
{
    public class TransactionLogin
    {

        [Key]
    

        [Required(ErrorMessage = " * Please Enter Your User Name")]
        [DisplayName("User Name")]
        public string Ruser_Id { get; set; }

        [Required(ErrorMessage = " * Please Enter Your Password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Transaction_Password { get; set; }

        [Required(ErrorMessage = " * Please Enter Your Password")]
        [Compare("Transaction_Password", ErrorMessage ="Please Enter Correct Password")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
      
        public string Confirm_Transaction_Password { get; set; }
    }
}