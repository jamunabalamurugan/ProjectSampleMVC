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
    
    public partial class Passenger_ticket_check_Result
    {
        public long booking_id { get; set; }
        public int no_of_seats { get; set; }
        public string @class { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public System.DateTime journey_date { get; set; }
    }
}