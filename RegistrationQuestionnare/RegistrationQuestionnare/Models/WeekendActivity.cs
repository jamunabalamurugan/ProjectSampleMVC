//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationQuestionnare.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WeekendActivity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WeekendActivity()
        {
            this.Places = new HashSet<Place>();
            this.WeekendActivityTracks = new HashSet<WeekendActivityTrack>();
            this.WeekendEmployeeInterests = new HashSet<WeekendEmployeeInterest>();
        }
    
        public int iWActivityID { get; set; }
        public string vWActivityName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Place> Places { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeekendActivityTrack> WeekendActivityTracks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeekendEmployeeInterest> WeekendEmployeeInterests { get; set; }
    }
}
