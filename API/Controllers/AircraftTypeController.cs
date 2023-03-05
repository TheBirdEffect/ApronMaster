using System.Net;
using API.Data;
using API.DTOs;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AircraftTypeController : BaseController
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
        public async Task<ActionResult<AircraftType>> DeleteAircraftType(int id)
        {
            try 
            {
                var aType = await _context.AircraftTypes.FindAsync(id); 
                if(aType != null)
                {
                    _context.AircraftTypes.Remove(aType);
                    var qtyDbActions = await _context.SaveChangesAsync();

                    if(qtyDbActions.Equals(1)){
                        return aType;
                    }
                    throw new Exception("Deletion failed");
                } else {
                    return BadRequest();
                }
            }
            catch 
            {
                throw new Exception("Internal Server Error 500");
            }
        }

    }
}