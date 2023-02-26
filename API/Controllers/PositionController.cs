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
    public class PositionController : ControllerBase
    {
        private readonly DataContext _context;
        public PositionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPosition()
        {
            return await _context.Positions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPosition(int id)
        {
            return await _context.Positions.FindAsync(id);
        }
    }
}