//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rash_Airlines.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Passenger_Reg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passenger_Reg()
        {
            this.feedbacks = new HashSet<feedback>();
            this.Passenger_booking_details = new HashSet<Passenger_booking_details>();
            this.Passengers_Details = new HashSet<Passengers_Details>();
            this.Passengers_Details_New = new HashSet<Passengers_Details_New>();
        }
    
        public int passenger_id { get; set; }
        public string title { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public string confirm_pwd { get; set; }
        public System.DateTime dob { get; set; }
        public string mobile { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passenger_booking_details> Passenger_booking_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passengers_Details> Passengers_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passengers_Details_New> Passengers_Details_New { get; set; }
    }
}