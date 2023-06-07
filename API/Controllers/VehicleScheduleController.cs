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

        [HttpGet("Extended")]
        public async Task<ActionResult<IEnumerable<VehicleSchedule>>> GetExtendedSchedule()
        {
            var query = await (
                from vS in _context.VehicleSchedules
                join gV in _context.GroundVehicles
                on vS.GroundVehicleId equals gV.GroundVehicleId into __groundVehicleIds
                from vehicle in __groundVehicleIds.DefaultIfEmpty()

                join o in _context.Orders
                on vS.OrderId equals o.OrderId into __orders
                from order in __orders.DefaultIfEmpty()

                join f in _context.Flights
                on vS.Order.FlightId equals f.FlightId into __flights
                from flight in __flights.DefaultIfEmpty()

                where order.OrderId != 9999 //Seed!

                select new VehicleSchedule
                {
                    ScheduleId = vS.ScheduleId,
                    GroundVehicleId = vehicle.GroundVehicleId,
                    GroundVehicle = new GroundVehicle
                    {
                        GroundVehicleId = vehicle.GroundVehicleId,
                        Name = vehicle.Name,
                        PositionId = vehicle.PositionId,
                        Position = vehicle.Position,
                        VehicleTypeId = vehicle.VehicleTypeId,
                        VehicleType = vehicle.VehicleType
                    },
                    Order = new Order 
                    {
                        OrderId = order.OrderId,
                        FlightId = flight.FlightId,
                        Flight = new Flight
                        {
                            FlightId = flight.FlightId,
                            FlightNumber = flight.FlightNumber,
                            Arrival = flight.Arrival,
                            Departure = flight.Departure,
                            AircraftTypeId = flight.AircraftTypeId,
                            Destination = flight.Destination
                        },
                        StartOfService = order.StartOfService,
                        EndOfService = order.EndOfService,
                        Delay = order.Delay,
                        fuelType = order.fuelType,
                        QtyFuel = order.QtyFuel,
                        PositionId = order.PositionId,
                        Position = new Position
                        {
                            PositionId = order.Position.PositionId,
                            Name = order.Position.Name,
                            IsGate = order.Position.IsGate
                        }
                    }

                }
            ).ToListAsync();

            //Calculate new SoS and EoS if Delay is set
            //query all orders which have a delay from list query
            foreach(var order in query) {
                if(!order.Order.Delay.Equals(null))
                {
                    order.Order.StartOfService = (DateTime)(order.Order.StartOfService + order.Order.Delay);
                    order.Order.EndOfService = (DateTime)(order.Order.EndOfService + order.Order.Delay);
                }
            }

            var orderedQuery = query.OrderBy(q => q.GroundVehicle.GroundVehicleId);

            return Ok(orderedQuery);
        }

        [HttpDelete("all")]
        public async Task<ActionResult> deleteAllSchedules() {
            var totalSchedules = await _context.VehicleSchedules.ToListAsync();

            _context.VehicleSchedules.RemoveRange(totalSchedules);
            await _context.SaveChangesAsync();

            return Ok("Schedules removed!");
        }
    }
}