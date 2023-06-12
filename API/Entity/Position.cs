namespace API.Entity
{
    public class Position
    {
        public int PositionId { get; set; }
        public String Name { get; set; }
        public Boolean IsGate { get; set; }

        public ICollection<GroundVehicle>? GroundVehicles { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}