using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBankingProject.Models
{
    public class RegisterConfirm
    {
        [DisplayName("Login Password")]
        [Required(ErrorMessage = "* Please Enter Your Login Password")]
        public string Login_Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "* Please Confirm Your Login Password")]
        [Compare("Login_Password", ErrorMessage = "Passwords do not match")]
        [NotMapped]
        public string Confirm_Password { get; set; }

        [DisplayName(" Transaction Password")]
        [Required(ErrorMessage = "* Please Enter Your Transaction Password")]
        public string Transaction_Password { get; set; }

        [DisplayName("Confirm Transaction Password")]
        [Required(ErrorMessage = "* Please Confirm Your Transaction Password")]
        [Compare("Transaction_Password", ErrorMessage = "Passwords do not match")]
        [NotMapped]
        public string Confirm_Transaction_Password { get; set; }

        [DisplayName("OTP")]
        [Required(ErrorMessage = "* Please Enter OTP")]
        [NotMapped]
        public string OTP { get; set; }
    }
}