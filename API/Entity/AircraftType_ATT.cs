using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class AircraftType_ATT
    {
        public int aircraftTurnarroundTemplateId { get; set; }
        public AircraftTurnarroundTemplate? aircraftTurnarroundTemplate { get; set; }

        public int AircraftTypeId { get; set; }
        public AircraftType? AircraftType { get; set; }
    }
}