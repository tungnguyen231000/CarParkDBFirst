using System;
using System.Collections.Generic;

#nullable disable

namespace CarPark.Data
{
    public partial class Ticket
    {
        public long TicketId { get; set; }
        public TimeSpan? BookingTime { get; set; }
        public string CustomerName { get; set; }
        public string LicensePlate { get; set; }
        public long? TripId { get; set; }

        public virtual Car LicensePlateNavigation { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
