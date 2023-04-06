using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class TurnarroundVehicleTimeOffset
    {
        [Key]
        public int TvtoId { get; set; }
        public int TimeOffsetStart { get; set; }
        public int TimeOffsetEnd { get; set; }
        public int AircraftTurnarroundTemplateId { get; set; }
        public AircraftTurnarroundTemplate? AircraftTurnarroundTemplate { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }
    }
}