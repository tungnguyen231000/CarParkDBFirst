using System;
using System.Collections.Generic;

#nullable disable

namespace CarPark.Data
{
    public partial class Park
    {
        public Park()
        {
            Cars = new HashSet<Car>();
        }

        public long ParkId { get; set; }
        public long? ParkArea { get; set; }
        public string ParkName { get; set; }
        public string ParkPlace { get; set; }
        public long? ParkPrice { get; set; }
        public string ParkStatus { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
