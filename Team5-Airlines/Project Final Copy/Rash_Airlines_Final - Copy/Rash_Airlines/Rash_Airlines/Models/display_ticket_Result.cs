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
    using System.ComponentModel.DataAnnotations;

    public partial class display_ticket_Result
    {
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [Display(Name = "Booking Date")]
        public Nullable<System.DateTime> booking_date { get; set; }
        [Display(Name = "Journey Date")]
        public System.DateTime journey_date { get; set; }
        [Display(Name = "Booking ID")]
        public long booking_id { get; set; }
        [Display(Name = "Seat Number")]
        public int seat_no { get; set; }
        public Nullable<System.TimeSpan> duration { get; set; }
        [Display(Name = "Class")]
        public string @class { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
    }
}