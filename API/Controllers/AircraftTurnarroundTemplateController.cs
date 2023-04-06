using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers
{
    public class AircraftTurnarroundTemplateController : BaseController
    {
        private readonly DataContext _context;
        public AircraftTurnarroundTemplateController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<AircraftTurnarroundTemplate>> SetTurnarroundTemplate(
            AircraftTurnarroundTemplate template
        )
        {
            var tempTemplateData = new AircraftTurnarroundTemplate();

            if (!template.Equals(null))
            {
                tempTemplateData.Name = template.Name;
                tempTemplateData.DescriptionNotes = template.DescriptionNotes;
                var aircraftTypeList = new List<AircraftType>();
                foreach (var aircraftType in template.AircraftTypes)
                {
                    aircraftTypeList.Add(
                        _context.AircraftTypes.FirstOrDefault(i => i.AircraftTypeId == aircraftType.AircraftTypeId)
                    );
                }

                await _context.AircraftTurnarroundTemplates.AddAsync(tempTemplateData);
                await _context.SaveChangesAsync();

                return Ok(tempTemplateData);
            }

            return NotFound(template);





        }

    }
}