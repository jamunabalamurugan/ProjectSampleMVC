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
    
    public partial class DailyLoginTime
    {
        public int DLT_number { get; set; }
        public string vEmpID { get; set; }
        public Nullable<System.DateTime> dLoginTime { get; set; }
        public Nullable<System.DateTime> dLogoutTime { get; set; }
        public Nullable<int> iMood { get; set; }
        public Nullable<double> dbStressValue { get; set; }
    
        public virtual EmployeePersonalDetail EmployeePersonalDetail { get; set; }
    }
}
