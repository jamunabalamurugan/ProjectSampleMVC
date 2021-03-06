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
    using System.ComponentModel.DataAnnotations;

    public partial class Flights_Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flights_Master()
        {
            this.Flights_Schedule = new HashSet<Flights_Schedule>();
            this.Passenger_booking_details = new HashSet<Passenger_booking_details>();
        }
        [Display(Name ="Flight ID")]
        public int flight_id { get; set; }
        [Display(Name = "Flight Name")]
        public string flight_name { get; set; }
        [Display(Name = "Business Capacity")]
        public Nullable<int> business_capacity { get; set; }
        [Display(Name = "Economy Capacity")]
        public Nullable<int> economy_capacity { get; set; }
        [Display(Name = "Route ID")]
        public Nullable<int> route_id { get; set; }
        [Display(Name = "Flight Status")]
        public string flight_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flights_Schedule> Flights_Schedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passenger_booking_details> Passenger_booking_details { get; set; }
        public virtual Routes_Master Routes_Master { get; set; }
    }
}
