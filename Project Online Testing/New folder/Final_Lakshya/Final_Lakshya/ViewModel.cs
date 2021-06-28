using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Lakshya
{
    public class ViewModel
    {
        [Key]
        public int temp_id { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
        public IEnumerable<Mcq_Options> Mcq_Options { get; set; }

    }
}