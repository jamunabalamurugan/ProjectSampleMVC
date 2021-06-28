using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace OnlineBankingProject.Models
{
    public class Neft
    {
  
        [Key]
        public int Reference_Id { get; set; }
        public long Account_Number { get; set; }
        [DisplayName("To Account")]
        public long Beneficiary_Account_Number { get; set; }
        public DateTime Transaction_Date { get; set; }

        [DisplayName("Amount")]
        [Range(1, 1000000000000, ErrorMessage = "Amount should be of Minimum Rs.1")]
        [Required(ErrorMessage = "* Please Enter Your Transaction Amount")]
        public int Transaction_Amount { get; set; }
        public string Transaction_Mode { get; set; }
        

    }
}