using System.ComponentModel.DataAnnotations;

namespace API.Entity
{
    public class GroundVehicle
    {
        public int GroundVehicleId { get; set; }
        public String Name { get; set; }
        public Boolean IsIdling { get; set; }
        //Create FK for VehilceTypes
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        //Create FK for Positions
        public int PositionId { get; set; }
        public Position Position { get; set; }

        public ICollection<VehicleSchedule> VehicleSchedules { get; set; }
    }
}