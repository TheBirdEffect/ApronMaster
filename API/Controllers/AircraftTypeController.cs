using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<AircraftType> AddAircraftType([FromBody] AircraftType type) 
        {
            _context.AircraftTypes.Add(type);
            await _context.SaveChangesAsync();
            
            return type;
        }
    }
}