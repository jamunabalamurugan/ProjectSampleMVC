using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class ViewModel1
    {
        [Key]
        [Required(ErrorMessage = "Technology is required")]
        [DisplayName("Technology")]
        public string TECHNOLOGY_NAME { get; set; }        
        [DisplayName("State")]
        [Required(ErrorMessage = "State is required")]
        public string STATE { get; set; }
        [DisplayName("City")]
        [Required(ErrorMessage = "City is required")]
        public string CITY { get; set; }
        [DisplayName("Level")]
        [Required(ErrorMessage = "Level is required")]
        public Nullable<int> TEST_LEVEL { get; set; }
        [DisplayName("Marks")]
        [Required(ErrorMessage = "Score is required")]
        public Nullable<int> SCORE { get; set; }

    }
}