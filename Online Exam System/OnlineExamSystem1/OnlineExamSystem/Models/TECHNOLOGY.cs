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

    public partial class TECHNOLOGY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TECHNOLOGY()
        {
            this.QUESTIONs = new HashSet<QUESTION>();
            this.REPORTs = new HashSet<REPORT>();
        }
    
        [DisplayName("Technology ID")]
        public int TECHNOLOGY_ID { get; set; }
        [DisplayName("Technology Name")]
        public string TECHNOLOGY_NAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPORT> REPORTs { get; set; }
    }
}
