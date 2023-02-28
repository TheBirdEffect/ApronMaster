using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AircraftTypeController : ControllerBase
    {
        private readonly ILogger<AircraftTypeController> _logger;
        private readonly DataContext _context;
        public AircraftTypeController(ILogger<AircraftTypeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftType>>> GetAircraftType()
        {
            return await _context.AircraftTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AircraftType>> GetAircraftType(int id)
        {
            return await _context.AircraftTypes.FindAsync(id);
        }

        // [HttpPatch("{id}")]
        // public async Task<ActionResult<AircraftType>> UpdateAircraftType(int id, [FromBody] JsonPatchDocument<EntryModel> patchDocument) 
        // {
        //     var _type = new AircraftType();

        //     _type.AircraftTypeId = type.AircraftTypeId;
        //     _type.Name = type.Name;
        //     _type.hasUnitLoadOption = type.hasUnitLoadOption;

        //     _context.AircraftTypes.Update(_type);
        //     await _context.SaveChangesAsync();

        //     return _type;
        // }

        // [HttpPost]
        // public async Task<AircraftType> AddAircraftType([FromBody] AircraftType type) 
        // {
        //     _context.AircraftTypes.Add(type);
        //     await _context.SaveChangesAsync();
            
        //     return type;
        // }

        [HttpPost]
        public async Task<AircraftType> AddAircraftType(AircraftTypeDto aircraftTypeDto) 
        {
            var aType = new AircraftType {
                Name = aircraftTypeDto.Name,
                hasUnitLoadOption = aircraftTypeDto.HasUnitLoadOption
            };

            _context.AircraftTypes.Add(aType);
            await _context.SaveChangesAsync();
            
            return aType;
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteAircraftType(int id)
        {
            try 
            {
                var aType = await _context.AircraftTypes.FindAsync(id); 
                if(aType != null)
                {
                    _context.AircraftTypes.Remove(aType);
                    var status = await _context.SaveChangesAsync();

                    if(status.Equals(1)){
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                    throw new Exception("Deletion failed");
                } else {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch 
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

    }
}