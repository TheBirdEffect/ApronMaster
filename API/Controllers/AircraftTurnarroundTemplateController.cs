using API.Data;
using API.DTOs;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*
    This Controller provides all api methods to interact of the AircraftTurnaroundTemplate

*/
namespace API.Controllers
{
    public class AircraftTurnarroundTemplateController : BaseController
    {
        private readonly DataContext _context;
        public AircraftTurnarroundTemplateController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("jointdata/all")]
        public async Task<ICollection<AircraftType_ATT>> GetAircraftTypeAttJoint()
        {
            var templates = await _context.AircraftType_ATTs.ToListAsync();

            return templates;
        }

        [HttpGet("all")]
        public async Task<ICollection<AircraftTurnarroundPreset>> GetTurnarroundTemplate()
        {
            var preset = await _context.AircraftTurnarroundTemplates.ToListAsync();

            return preset;
        }

        /*
            This controller consumes an aircrafttype id and returns a List of type AircraftTurnaroundTemplate
            Params: ID of AircraftType
            Returns: List of AircraftTurnaroundTemplates which AircraftType equals to consumed AircraftType 
        */
        [HttpGet("aircraftType/{id}")]
        public async Task<ActionResult<ICollection<AircraftTurnarroundPreset>>> GetTemplatesByAircraftType(int id)
        {
            return await (from att in _context.AircraftType_ATTs
                          join tem in _context.AircraftTurnarroundTemplates
                          on att.aircraftTurnarroundTemplateId equals tem.TemplateId into __templates
                          from templates in __templates.DefaultIfEmpty()

                          where att.AircraftTypeId.Equals(id)
                          select new AircraftTurnarroundPreset
                          {
                              TemplateId = templates.TemplateId,
                              Name = templates.Name,
                              DescriptionNotes = templates.DescriptionNotes,
                              TurnarroundVehicleTimeOffsets = templates.TurnarroundVehicleTimeOffsets
                          }
            ).ToListAsync();
        }

        /*
            This controller consumes a DTO of GetTemplateForVehicleTypeDto and returns a list of AircraftTurnaroundVehicles
            It provides templates to get a collection of Templates of Vehicles a chosen Aircraft needs for the Turnaround  
            Params: GetTemplateForVehicleTypeDto called collection which includes AircraftTypeId and utilizeGangway.
            Returns: AircraftTurnaroundPreset which belong to aircrafttype and utilizeGangways.
        */
        [HttpPost("aircraftType/filteredByPositionCharacteristics")]
        public async Task<ActionResult<ICollection<AircraftTurnarroundPreset>>> GetTemplatesByAircraftTypeAndPositionFiltered(
            GetTemplateForVehicleTypeDto collection)
        {
            if (collection != null)
            {
                return await (from att in _context.AircraftType_ATTs
                              join tem in _context.AircraftTurnarroundTemplates
                              on att.aircraftTurnarroundTemplateId equals tem.TemplateId into __templates
                              from templates in __templates.DefaultIfEmpty()

                              where att.AircraftTypeId == collection.aircraftTypeId
                              && templates.utilizeGangways == collection.utilizeGangways

                              select new AircraftTurnarroundPreset
                              {
                                  TemplateId = templates.TemplateId,
                                  Name = templates.Name,
                                  DescriptionNotes = templates.DescriptionNotes,
                                  TurnarroundVehicleTimeOffsets = templates.TurnarroundVehicleTimeOffsets
                              }
                     ).ToListAsync();
            }

            return NotFound();
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
            var tempTemplate = new AircraftTurnarroundPreset();
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