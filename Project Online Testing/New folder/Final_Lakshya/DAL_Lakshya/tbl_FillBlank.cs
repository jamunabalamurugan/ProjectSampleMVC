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
    
    public partial class tbl_FillBlank
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_FillBlank()
        {
            this.tbl_Transaction = new HashSet<tbl_Transaction>();
        }
    
        public string FB_Id { get; set; }
        public string FB_Ques { get; set; }
        public string FB_Ans_Key { get; set; }
        public string Sub_Id_FB { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Transaction> tbl_Transaction { get; set; }
        public virtual tbl_Subjects tbl_Subjects { get; set; }
    }
}