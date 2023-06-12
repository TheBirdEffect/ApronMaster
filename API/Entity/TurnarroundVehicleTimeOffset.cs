using System.ComponentModel.DataAnnotations;

namespace API.Entity
{
    public class TurnarroundVehicleTimeOffset
    {
        [Key]
        public int TvtoId { get; set; }
        public int TimeOffsetStart { get; set; }
        public int TimeOffsetEnd { get; set; }
        public int AircraftTurnarroundTemplateId { get; set; }
        public AircraftTurnarroundPreset? AircraftTurnarroundTemplate { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }
    }
}