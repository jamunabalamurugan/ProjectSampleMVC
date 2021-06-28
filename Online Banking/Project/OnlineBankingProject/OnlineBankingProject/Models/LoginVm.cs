using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBankingProject.Models
{
    public class LoginVm
    {
        [Key]

        [Required(ErrorMessage = " * Please Enter Your User Name")]
        [DisplayName("User Name")]
        public string Ruser_Id { get; set; }

       // [StringLength(15,MinimumLength=5, ErrorMessage="* Min 5 charachters and max 15 character")]
        [Required(ErrorMessage = " * Please Enter Your Password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Login_Password { get; set; }
    }
}