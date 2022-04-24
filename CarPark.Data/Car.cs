using System;
using System.Collections.Generic;

#nullable disable

namespace CarPark.Data
{
    public partial class Car
    {
        public Car()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string LicensePlate { get; set; }
        public string CarColor { get; set; }
        public string CarType { get; set; }
        public string Company { get; set; }
        public long? ParkId { get; set; }

        public virtual Park Park { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
