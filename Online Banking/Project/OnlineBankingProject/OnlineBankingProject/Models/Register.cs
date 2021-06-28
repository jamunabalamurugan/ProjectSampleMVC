using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineBankingProject.Models
{
    public class Register
    {
        [Key]
        [DisplayName("User Name")]
        [Required(ErrorMessage = "* Please Enter Your UserName")]
        //check if the name is unique or its existing in db
        [Remote("IsRuser_IdExist", "LOR", ErrorMessage = "User name already exist")]
        public string Ruser_Id { get; set; }

        [DisplayName("Account Number")]
        [Required(ErrorMessage = "* Please Enter Your Account Number")]
        [Remote("IsAccount_NumberExist", "LOR", ErrorMessage = "Account number does not exist")]
        public long Account_Number { get; set; }

        [NotMapped]
        [DisplayName("AadharCard Number")]
        [Required(ErrorMessage = "* Please Enter Your AadharCard Number")]
        [Remote("IssAadharCard_NumberExist", "LOR", ErrorMessage = "AadharCard number does not exist")]
        public string AadharCard_Number { get; set; }

 
    }
}