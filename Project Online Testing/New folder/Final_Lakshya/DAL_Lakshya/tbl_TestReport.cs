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
    
    public partial class tbl_TestReport
    {
        public string Report_Id { get; set; }
        public string Test_Id_TestRep { get; set; }
        public string Tran_Id_Tran { get; set; }
        public string User_Id_User { get; set; }
        public Nullable<int> Attempted_Ques_No { get; set; }
        public Nullable<int> Correct_Ques_No { get; set; }
        public Nullable<int> Wrong_Ques_No { get; set; }
        public Nullable<System.DateTime> Start_Time { get; set; }
        public Nullable<System.DateTime> End_Time { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<double> Percentage { get; set; }
        public string Result_Status { get; set; }
    
        public virtual tbl_Test tbl_Test { get; set; }
        public virtual tbl_Transaction tbl_Transaction { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}