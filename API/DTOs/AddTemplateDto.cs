using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AddTemplateDto
    {
        public string name { get; set; }
        public string descriptionNotes { get; set; }
        public ICollection<int> aircraftTypeIds { get; set; }
    }

    public class GetTemplateForVehicleTypeDto
    {
        public int aircraftTypeId { get; set; }
        public bool utilizeGangways { get; set; }
    }
}