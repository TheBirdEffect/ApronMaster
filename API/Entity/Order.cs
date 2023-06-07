using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public DateTime StartOfService { get; set; }
        [Required]
        public DateTime EndOfService { get; set; }
        public TimeSpan? Delay { get; set; }
        public int QtyFuel { get; set; }
        public string? fuelType { get; set; }

        //Create FK for Position
        public int PositionId { get; set; }
        public Position? Position { get; set; }

        //Create FK for Flight
        public int FlightId { get; set; }
        public Flight? Flight { get; set; }

        //Create FK for VehicleType
        public int VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }

        public ICollection<VehicleSchedule>? VehicleSchedules { get; set; }
    }
}