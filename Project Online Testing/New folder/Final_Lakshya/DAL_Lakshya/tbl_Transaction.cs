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
    
    public partial class tbl_Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Transaction()
        {
            this.tbl_TestReport = new HashSet<tbl_TestReport>();
            this.tbl_Transaction1 = new HashSet<tbl_Transaction>();
        }
    
        public string Tran_Id { get; set; }
        public string MCQ_Id { get; set; }
        public string FB_Id { get; set; }
        public string TF_Id { get; set; }
        public string Test_Id_Tran { get; set; }
        public string Ques_Type { get; set; }
    
        public virtual tbl_FillBlank tbl_FillBlank { get; set; }
        public virtual tbl_MCQ tbl_MCQ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_TestReport> tbl_TestReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Transaction> tbl_Transaction1 { get; set; }
        public virtual tbl_Transaction tbl_Transaction2 { get; set; }
        public virtual tbl_TrueOrFalse tbl_TrueOrFalse { get; set; }
    }
}
