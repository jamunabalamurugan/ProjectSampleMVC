//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL_Lakshya
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Test()
        {
            this.tbl_TestReport = new HashSet<tbl_TestReport>();
        }
    
        public string Test_Id { get; set; }
        public string Sub_Id_Test { get; set; }
        public string Test_Name { get; set; }
        public Nullable<System.DateTime> Time_Alloted { get; set; }
        public Nullable<int> No_of_Ques { get; set; }
    
        public virtual tbl_Subjects tbl_Subjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_TestReport> tbl_TestReport { get; set; }
    }
}