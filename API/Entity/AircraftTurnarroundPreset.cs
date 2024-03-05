using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Entity
{
    public class AircraftTurnarroundPreset
    {
        [Key]
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public bool utilizeGangways { get; set; }
        public bool hasUnitLoadOption { get; set; }
        public string? DescriptionNotes { get; set; }
        // public int AircraftTypeId { get; set; }
        // public AircraftType? AircraftType { get; set; }
        //public virtual ICollection<AircraftType_ATT>? AircraftTypes { get; set; }
        public virtual ICollection<TurnarroundVehicleTimeOffset>? TurnarroundVehicleTimeOffsets { get; set; }
    }
}