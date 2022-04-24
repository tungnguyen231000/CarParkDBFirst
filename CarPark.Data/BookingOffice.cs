using System;
using System.Collections.Generic;

#nullable disable

namespace CarPark.Data
{
    public partial class BookingOffice
    {
        public long OfficeId { get; set; }
        public DateTime? EndContractDeadline { get; set; }
        public string OfficeName { get; set; }
        public string OfficePhone { get; set; }
        public string OfficePlace { get; set; }
        public long? OfficePrice { get; set; }
        public DateTime? StartContractDeadline { get; set; }
        public long? TripId { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
