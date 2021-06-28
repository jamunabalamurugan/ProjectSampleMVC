using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineBankingProject.Models
{
    public class Beneficiary
    {
        [Key]
        public int Beneficiary_Id { get; set; }
        [Required(ErrorMessage = "* Please Enter Your Beneficiary Name")]
        [DisplayName("Beneficiary Name")]
        public string Beneficiary_Name { get; set; }

        [Remote("IsBeneficiary_Account_NumberExist", "DashBoard", ErrorMessage = "Account Number already exist")]
        [Required(ErrorMessage = "* Please Enter Your Beneficiary_Account_Number")]
        [DisplayName("Beneficiary Account Number")]
        public long Beneficiary_Account_Number { get; set; }

        [Required(ErrorMessage = "* Please Enter Your Nick Name")]
        [DisplayName("Nick Name")]
        public string Nick_Name { get; set; }
    }
}