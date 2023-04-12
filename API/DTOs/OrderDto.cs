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

    public class TransferVehicleOffsetToOrder
    {
        public int VehicleTypeId { get; set; }
        public int TimeOffsetStart { get; set; }
        public int TimeOffsetEnd { get; set; }
        public int FuelAmmount { get; set; }
        public string FuelType { get; set; }
        public Flight Flight { get; set; }
        public Position Position { get; set; }
    }

    public class TransferSingleOrders {
        public DateTime startOfService { get; set; }
        public DateTime endOfService { get; set; }
        public string fuel { get; set; }
        public double fuelAmmount { get; set; }  
        public Flight flight { get; set; }
        public VehicleType vehicleType { get; set; }
        public Position position { get; set; }
    }
}