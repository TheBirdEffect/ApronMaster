using System.ComponentModel.DataAnnotations;

namespace API.Entity
{
    public class Flight
    {
        [Required]
        public int FlightId { get; set; }
        [Required]
        public String FlightNo { get; set; }

        public DateTime Arrival { get; set; }   
        public DateTime Departure { get; set; }
        [Required]
        public String Destination { get; set; }
        
        //Create FK for AircaftTypes
        public int? AircraftTypeId { get; set; }
        
        public AircraftType AircraftType { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}