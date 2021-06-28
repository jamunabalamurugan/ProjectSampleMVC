using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectOnlineShopping.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class quantityvm
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Quantity required")]
        [DisplayName("Enter Quantity")]
        public int quantity { get; set; }
    }
}