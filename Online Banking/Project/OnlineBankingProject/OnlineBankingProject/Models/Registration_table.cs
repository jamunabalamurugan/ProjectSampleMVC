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

    public partial class Registration_table
    {
        [DisplayName("User Name")]
        public string Ruser_Id { get; set; }

        [DisplayName("Account Number")]
        public Nullable<long> Account_Number { get; set; }

        [DisplayName("Email Id")]
        public string Email_Id { get; set; }

        [DisplayName("Login Password")]
        public string Login_Password { get; set; }

        [DisplayName("Transaction Password")]
        public string Transaction_Password { get; set; }

   
        public virtual Open_Savings_Account Open_Savings_Account { get; set; }
    }
}
