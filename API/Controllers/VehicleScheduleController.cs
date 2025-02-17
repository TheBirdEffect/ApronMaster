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
    public class VehicleScheduleController : BaseController
    {
        private readonly DataContext _context;
        public VehicleScheduleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleSchedule>>> GetVehicleSchedule()
        {
            return await _context.VehicleSchedules.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleSchedule>> GetVehicleSchedule(int id)
        {
            return await _context.VehicleSchedules.FindAsync(id);
        }
    }
}