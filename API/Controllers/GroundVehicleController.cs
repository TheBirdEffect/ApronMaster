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
    public class GroundVehicleController : BaseController
    {
        private readonly DataContext _context;
        public GroundVehicleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroundVehicle>>> GetGroundVehicle()
        {
            return await _context.GroundVehicles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroundVehicle>> GetGroundVehicle(int id)
        {
            return await _context.GroundVehicles.FindAsync(id);
        }
    }
}