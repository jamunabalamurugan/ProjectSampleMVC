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
    
    public partial class WeekendActivityTrack
    {
        public int iWAT_number { get; set; }
        public string vEmpID { get; set; }
        public Nullable<int> iWActivityID { get; set; }
        public Nullable<bool> bWActivityStatus { get; set; }
    
        public virtual EmployeePersonalDetail EmployeePersonalDetail { get; set; }
        public virtual WeekendActivity WeekendActivity { get; set; }
    }
}
