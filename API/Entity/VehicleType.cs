using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public String Name { get; set; }

        public ICollection<GroundVehicle>? GroundVehicles { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public virtual ICollection<TurnarroundVehicleTimeOffset>? TurnarroundVehicleTimeOffsets { get; set; }
    }
}