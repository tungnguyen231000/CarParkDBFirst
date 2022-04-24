using System;
using System.Collections.Generic;

#nullable disable

namespace CarPark.Data
{
    public partial class Trip
    {
        public Trip()
        {
            BookingOffices = new HashSet<BookingOffice>();
            Tickets = new HashSet<Ticket>();
        }

        public long TripId { get; set; }
        public int? BookedTicketNumber { get; set; }
        public string CarType { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public string Destination { get; set; }
        public string Driver { get; set; }
        public int? MaximumOnlineTicketNumber { get; set; }

        public virtual ICollection<BookingOffice> BookingOffices { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
