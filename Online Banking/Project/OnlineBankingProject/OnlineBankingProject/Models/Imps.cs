using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBankingProject.Models
{
    public class Imps
    {
        [Key]
        public int Reference_Id { get; set; }
        public long Account_Number { get; set; }
        [DisplayName("To Account")]
        public long Beneficiary_Account_Number { get; set; }
        public DateTime Transaction_Date { get; set; }

        [DisplayName("Amount")]
        [Range(1, 200000, ErrorMessage = "Should contain minimum Rs.1 and Maximum Rs.200000")]
        [Required(ErrorMessage = "* Please Enter Your Transaction Amount")]
        public int Transaction_Amount { get; set; }
        public string Transaction_Mode { get; set; }

        //[DisplayName("To Account")]
        //[Required(ErrorMessage = "* Please Enter Your Account Number")]
        //[Remote("IsBeneficiary_Account_NumberExist", "DashBoard", ErrorMessage = "Account number does not exist")]
        //public string Beneficiary_Account_Number { get; set; }

        //[DisplayName("Amount")]
        //[Range( 1,200000,ErrorMessage ="Should contain minimum Rs.1 and Maximum Rs.200000")]
        //[Required(ErrorMessage = "* Please Enter Your Transaction Amount")]
        //public string Transaction_Amount { get; set; }


        //public string Transaction_date { get; set; }

    }
}