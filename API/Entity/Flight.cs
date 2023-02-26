using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class Flight
    {
        public int FlightId { get; set; }
        public String FlightNo { get; set; }

        public DateTime Arrival { get; set; }   
        public DateTime Departure { get; set; }
        public String Destination { get; set; }
        
        //Create FK for AircaftTypes
        public int AircraftTypeId { get; set; }
        public AircraftType AircraftType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}