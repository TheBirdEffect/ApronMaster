using API.Entity;

namespace API.DTOs
{
    public class OrderDto
    {
        public int id { get; set; }
        public DateTime StartOfService { get; set; }
        public DateTime EndOfService { get; set; }
        public int QtyFuel { get; set; }

        public int PositionId { get; set; }
        public int FlightId { get; set; }
        public int VehicleTypeId { get; set; }
    }
}