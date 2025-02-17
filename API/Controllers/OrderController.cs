using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
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

        [HttpGet("flight{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> AssembleOrder(int id)
        {
            return await (from o in _context.Orders
                          join p in _context.Positions
                          on o.PositionId equals p.PositionId into __positions
                          from pos in __positions.DefaultIfEmpty()

                          join f in _context.Flights
                          on o.FlightId equals f.FlightId into __flights
                          from flight in __flights.DefaultIfEmpty()

                          join vT in _context.VehicleTypes
                          on o.VehicleTypeId equals vT.VehicleTypeId into __vehicleTypes
                          from vehicleType in __vehicleTypes.DefaultIfEmpty()

                          where o.FlightId == id
                          select new Order
                          {
                              OrderId = o.OrderId,
                              StartOfService = o.StartOfService,
                              EndOfService = o.EndOfService,
                              QtyFuel = o.QtyFuel,
                              PositionId = o.PositionId,
                              Position = new Position
                              {
                                  PositionId = pos.PositionId,
                                  Name = pos.Name,
                                  IsGate = pos.IsGate
                              },
                              FlightId = o.FlightId,
                              Flight = new Flight
                              {
                                  FlightId = flight.FlightId,
                                  AircraftTypeId = flight.AircraftTypeId,
                                  Arrival = flight.Arrival,
                                  Departure = flight.Departure,
                                  Destination = flight.Destination,
                                  FlightNumber = flight.FlightNumber
                              },
                              VehicleTypeId = o.VehicleTypeId,
                              VehicleType = new VehicleType
                              {
                                  VehicleTypeId = vehicleType.VehicleTypeId,
                                  Name = vehicleType.Name
                              }
                          }).ToListAsync();

        }

        [HttpPost("add")]
        public async Task<ActionResult<Order>> addOrder(Order order)
        {
            if (order.Equals(null)) return BadRequest("No valid flightplan object!");

            var newOrderDto = new Order
            {
                StartOfService = order.StartOfService,
                EndOfService = order.EndOfService,
                QtyFuel = order.QtyFuel,
                PositionId = order.PositionId,
                FlightId = order.FlightId,
                VehicleTypeId = order.VehicleTypeId
            };

            await _context.AddAsync(newOrderDto);
            await _context.SaveChangesAsync();
            return Ok(newOrderDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    var qtyDbActions = await _context.SaveChangesAsync();

                    if (qtyDbActions.Equals(1))
                    {
                        return order;
                    }
                    throw new Exception("Deletion failed");
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                throw new Exception("Internal Server Error 500");
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<Order>> UpdateOrder(Order order)
        {
            var _order = await _context.Orders.SingleAsync(o => o.OrderId == order.OrderId);
            Console.WriteLine(_order?.QtyFuel);

            if (_order != null)
            {
                if (_order != order)
                {
                    _order.OrderId = order.OrderId;
                    _order.StartOfService = order.StartOfService;
                    _order.EndOfService = order.EndOfService;
                    _order.QtyFuel = order.QtyFuel;
                    _order.PositionId = order.PositionId;
                    _order.FlightId = order.FlightId;
                    _order.VehicleTypeId = order.VehicleTypeId;
                }

                await _context.SaveChangesAsync();

                return Ok(_order);
            }

            return NotFound();
        }
    }
}