//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectOnlineShopping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class adminTable
    {
        [Key]
        [Required(ErrorMessage = "Admin Id Required")]
        [DisplayName("Enter ID")]
        public int adminId { get; set; }




        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Enter Password")]
        [DataType(DataType.Password)]
        public int adminPassword { get; set; }
    }
}
