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
    public class OrderController : BaseController
    {
        private readonly DataContext _context;
        private readonly DataContext _posContext;
        public OrderController(DataContext context, DataContext posContext)
        {
            _context = context;
            _posContext = posContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        [HttpGet("full{id}")]
        public async Task<ActionResult<Order>> AssembleOrder(int id) {
            var assembledOrder =    from o in _context.Orders
                                        join p in _context.Positions
                                            on o.PositionId equals p.PositionId
                                    select new {
                                        
                                    }
    }    
        // https://www.c-sharpcorner.com/UploadFile/ff2f08/sql-join-in-linq-linq-to-entity-linq-to-sql/
}