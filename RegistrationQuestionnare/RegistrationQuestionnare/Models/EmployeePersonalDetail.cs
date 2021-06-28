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
    
    public partial class EmployeePersonalDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeePersonalDetail()
        {
            this.DailyLoginTimes = new HashSet<DailyLoginTime>();
            this.DailyActivityTracks = new HashSet<DailyActivityTrack>();
            this.DailyEmployeeInterests = new HashSet<DailyEmployeeInterest>();
            this.WeekendActivityTracks = new HashSet<WeekendActivityTrack>();
            this.WeekendEmployeeInterests = new HashSet<WeekendEmployeeInterest>();
        }
    
        public string vEmpID { get; set; }
        public string vEmpName { get; set; }
        public string vWorkDomain { get; set; }
        public Nullable<int> iWorkingHours { get; set; }
        public string vWorkingLocation { get; set; }
        public Nullable<int> iEmpAge { get; set; }
        public string vEmpMobile { get; set; }
        public string vEmpMail { get; set; }
        public string vEmpGender { get; set; }
        public Nullable<System.DateTime> dBirthDate { get; set; }
        public Nullable<bool> bMaritialStatus { get; set; }
        public Nullable<int> iCreditPoints { get; set; }
        public string vPassword { get; set; }
        public Nullable<bool> bAdmin { get; set; }
        public string ProfilePhoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyLoginTime> DailyLoginTimes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyActivityTrack> DailyActivityTracks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyEmployeeInterest> DailyEmployeeInterests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeekendActivityTrack> WeekendActivityTracks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeekendEmployeeInterest> WeekendEmployeeInterests { get; set; }
    }
}
