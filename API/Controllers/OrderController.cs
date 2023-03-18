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
                                     VehicleType = new VehicleType {
                                        VehicleTypeId = vehicleType.VehicleTypeId,
                                        Name = vehicleType.Name
                                     }
                                 }).ToListAsync();

            // Console.WriteLine("OrderId\tSoS\tEoS\tQtyFuel\tPosId\tPosName\tIsGate\tFlightID\tVehTypeID");
            // foreach (Order data in assembledOrder)
            // {
            //     Console.WriteLine(data.OrderId
            //     + "\t" + data.StartOfService
            //     + "\t" + data.EndOfService
            //     + "\t" + data.QtyFuel
            //     + "\t" + data.PositionId
            //     + "\t" + data.Position.PositionId
            //     + "\t" + data.Position.Name
            //     + "\t" + data.Position.IsGate
            //     + "\t" + data.FlightId
            //     + "\t" + data.VehicleTypeId
            //     );
            // }

        }
    }
    // https://www.c-sharpcorner.com/UploadFile/ff2f08/sql-join-in-linq-linq-to-entity-linq-to-sql/
}