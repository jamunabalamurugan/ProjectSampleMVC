//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExamSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class REPORT
    {
        public int REPORT_ID { get; set; }
        [DisplayName("User ID")]
        public Nullable<int> USERID { get; set; }
        [DisplayName("Full Name")]
        public string FULL_NAME { get; set; }
        [DisplayName("Test Level")]
        public Nullable<int> TEST_LEVEL { get; set; }
        [DisplayName("Technology ID")]
        public Nullable<int> TECHNOLOGY_ID { get; set; }
        [DisplayName("Exam Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DATE_OF_EXAM { get; set; }
        [DisplayName("Score")]
        public Nullable<int> SCORE { get; set; }
        [DisplayName("Email")]
        public string EMAIL { get; set; }
    
        public virtual TECHNOLOGY TECHNOLOGY { get; set; }
        public virtual USER_DETAIL USER_DETAIL { get; set; }
    }
}
