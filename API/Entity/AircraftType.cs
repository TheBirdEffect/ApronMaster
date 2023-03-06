using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class AircraftType
    {
        public int AircraftTypeId { get; set; }
        public String Name { get; set; }
        public Boolean hasUnitLoadOption { get; set; }

        // public int FlightId { get; set; }
        // public Flight Flight { get; set; }
        //public ICollection<Flight> Flights { get; set; }
    }
}