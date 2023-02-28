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
    public class VehicleTypeController : BaseController
    {
        private readonly DataContext _context;

        public VehicleTypeController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleType>>> GetVehicleType() 
        {
            return await _context.VehicleTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleType>> GetVehicleType(int id) 
        {
            return await _context.VehicleTypes.FindAsync(id);
        }
    }
}