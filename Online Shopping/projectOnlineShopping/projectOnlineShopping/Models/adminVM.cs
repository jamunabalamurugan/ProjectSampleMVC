using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace projectOnlineShopping.Models
{
    public class adminVM
    {
        [Key]
        [Required(ErrorMessage ="Admin Id Required")]
        [DisplayName("Enter ID")]
        public int adminId { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Enter Password")]
        [DataType(DataType.Password)]
        public int adminPassword { get; set; }
    }
}