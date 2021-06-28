using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace OnlineBankingProject.Models
{
    public class ForgotPassword
    {
        [Key]
        [Remote("IsEmail_IdExistt", "LOR", ErrorMessage = "This Email does not exist")]
        [Required(ErrorMessage = "* Please Enter Your Email Id")]
        [DataType(DataType.EmailAddress)]
        public string Email_Id { get; set; }

        [Remote("IsAccount_NumberExist", "LOR", ErrorMessage = "This Account Number does not exist")]
        [Required(ErrorMessage = "* Please Enter Your Account Number")]
        public long Account_Number { get; set; }
    }


}