using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
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

        [HttpGet("all")]
        public async Task<ICollection<AircraftType_ATT>> GetTurnarroundTemplate()
        {
            var templates = await _context.AircraftType_ATTs.ToListAsync();

            return templates;
        }


        [HttpGet("aircraftType{id}")]
        public async Task<ActionResult<ICollection<AircraftTurnarroundTemplate>>> GetTemplatesByAircraftType(int id)
        {
            return await(from att in _context.AircraftType_ATTs
                         join tem in _context.AircraftTurnarroundTemplates
                         on att.aircraftTurnarroundTemplateId equals tem.TemplateId into __templates
                         from templates in __templates.DefaultIfEmpty()
                         
                         where att.AircraftTypeId.Equals(id)
                         select new AircraftTurnarroundTemplate {
                            TemplateId = templates.TemplateId,
                            Name = templates.Name,
                            DescriptionNotes = templates.DescriptionNotes,
                            TurnarroundVehicleTimeOffsets = templates.TurnarroundVehicleTimeOffsets
                         }
            ).ToListAsync();
        }


        /**
            This controller is used to store templates  
        */

        [HttpPost("add")]
        public async Task<ActionResult<ICollection<AircraftType_ATT>>> SetTurnarroundTemplate(
            AddTemplateDto templateDto
        )
        {
            var tempAircraftType_ATT = new AircraftType_ATT();
            var tempTemplate = new AircraftTurnarroundTemplate();
            var aircraftTypeIdList = new List<int>();

            var returnableAircratTypeATT = new List<String>();


            if (templateDto != null)
            {
                tempTemplate.Name = templateDto.name;
                tempTemplate.DescriptionNotes = templateDto.descriptionNotes;

                _context.AircraftTurnarroundTemplates.Add(tempTemplate);
                await _context.SaveChangesAsync();

                //Map template data on the joint table
                //tempAircraftType_ATT.AircraftTypeId = templateDto.aircraftTypeId;
                foreach (int aircraftTypeId in templateDto.aircraftTypeIds)
                {
                    tempAircraftType_ATT.AircraftTypeId = aircraftTypeId;
                    tempAircraftType_ATT.aircraftTurnarroundTemplateId = tempTemplate.TemplateId;
                    var bla = _context.AircraftType_ATTs.Add(tempAircraftType_ATT).ToString();
                    await _context.SaveChangesAsync();
                    returnableAircratTypeATT.Add(bla);
                }



                return Ok(returnableAircratTypeATT);
            }

            return NotFound();
        }

    }
}