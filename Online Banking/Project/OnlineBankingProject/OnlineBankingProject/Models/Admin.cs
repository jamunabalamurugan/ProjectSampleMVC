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
    using System.ComponentModel.DataAnnotations;

    public partial class Admin
    {
        [Required(ErrorMessage = "* Please Enter Admin Name")]
        [DisplayName("Admin Name")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = " * Please Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
