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
    
    public partial class tbl_TrueOrFalse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_TrueOrFalse()
        {
            this.tbl_Transaction = new HashSet<tbl_Transaction>();
        }
    
        public string TF_Id { get; set; }
        public string TF_Ques { get; set; }
        public string TF_Ans_Key { get; set; }
        public string Sub_Id_TF { get; set; }
    
        public virtual tbl_Subjects tbl_Subjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Transaction> tbl_Transaction { get; set; }
    }
}
