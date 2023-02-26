using System.ComponentModel.DataAnnotations;

namespace API.Entity
{
    public class VehicleSchedule
    {
        [Key]
        public int ScheduleId { get; set; }

        //Create FK for GroundVehicles
        public int GroundVehicleId { get; set; }  
        public GroundVehicle GroundVehicle { get; set; }

        //Create FK for Orders
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}