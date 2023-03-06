using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;

namespace API.DTOs
{
    public class FlightDto
    {
        public String FlightNumber {get; set;}
        public String Destination {get; set;}
        public DateTime Arrival {get; set;}
        public DateTime Departure {get; set;}
        public AircraftType AircraftType {get; set;}
    }
}