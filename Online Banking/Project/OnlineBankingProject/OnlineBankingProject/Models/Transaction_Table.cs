//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineBankingProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Transaction_Table
    {
        [DisplayName("Reference Id")]
        public int Reference_Id { get; set; }

        [DisplayName("Account Number")]
        public Nullable<long> Account_Number { get; set; }

        [DisplayName("Beneficiary Account Number")]
        public Nullable<long> Beneficiary_Account_Number { get; set; }

        [DisplayName("Transaction Date")]
        public Nullable<System.DateTime> Transaction_Date { get; set; }

        [DisplayName("Transaction Amount")]
        public Nullable<int> Transaction_Amount { get; set; }

        [DisplayName("Transaction Mode")]
        public string Transaction_Mode { get; set; }
        public virtual Open_Savings_Account Open_Savings_Account { get; set; }
    }
}
