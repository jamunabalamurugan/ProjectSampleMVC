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

    public partial class Routes_Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Routes_Master()
        {
            this.Flights_Master = new HashSet<Flights_Master>();
            this.Flights_Schedule = new HashSet<Flights_Schedule>();
        }
    
        [Display(Name ="Route ID")]
        public int route_id { get; set; }
        [Display(Name = "Departure")]
        public Nullable<int> departure { get; set; }
        [Display(Name = "Arrival")]
        public Nullable<int> arrival { get; set; }
        [Display(Name = "Economy Cost")]
        public Nullable<decimal> economy_cost { get; set; }
        [Display(Name = "Business Cost")]
        public Nullable<decimal> business_cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flights_Master> Flights_Master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flights_Schedule> Flights_Schedule { get; set; }
        public virtual Place Place { get; set; }
        public virtual Place Place1 { get; set; }
    }
}
