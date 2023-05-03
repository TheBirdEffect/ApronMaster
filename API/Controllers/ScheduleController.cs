using API.Data;
using API.Entity;
using API.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace API.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly DataContext _context;
        public ScheduleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("inititialize")]
        public async Task<ActionResult<IEnumerable<VehicleSchedule>>> InitializeSchedule()
        {
            var totalSchedules = await _context.VehicleSchedules.ToListAsync();
            var schedulesToBeReturned = new List<VehicleSchedule>();

            if (!totalSchedules.Any())
            {
                var groundVehicles = await _context.GroundVehicles.ToListAsync();
                var scheduleSeed = new List<VehicleSchedule>();

                var order = new Order
                {
                    OrderId = 0,
                    StartOfService = DateTime.UtcNow,
                    EndOfService = DateTime.UtcNow
                };

                foreach (var vehicle in groundVehicles)
                {
                    scheduleSeed.Add(
                        new VehicleSchedule
                        {
                            OrderId = 9999,
                            GroundVehicleId = vehicle.GroundVehicleId
                        }
                    );
                }

                await _context.VehicleSchedules.AddRangeAsync(scheduleSeed);
                await _context.SaveChangesAsync();

                return Ok("Schedules are Initialized");
            }
            else
            {
                var scheduler = new Scheduler();
                var currentOrders = await this._context.Orders.ToListAsync();

                var baseModels = scheduler.calculateSlackAndMapToSchedulingModel(currentOrders);

                foreach (var model in baseModels)
                {
                    // var schedulesOrdered = await this._context.VehicleSchedules
                    //     .Where(s =>
                    //     s.GroundVehicle.VehicleTypeId == model.Order.VehicleTypeId)
                    //     .ToListAsync();

                    var schedulesOrdered = await (
                        from vS in _context.VehicleSchedules
                        join v in _context.GroundVehicles
                        on vS.GroundVehicleId equals v.GroundVehicleId into __groundVehicleIds
                        from vehicle in __groundVehicleIds.DefaultIfEmpty()

                        where vS.GroundVehicle.VehicleTypeId == model.Order.VehicleTypeId
                        select new VehicleSchedule
                        {
                            OrderId = vS.OrderId,
                            Order = vS.Order,
                            GroundVehicleId = vehicle.GroundVehicleId,
                            GroundVehicle = new GroundVehicle
                            {
                                GroundVehicleId = vehicle.GroundVehicleId,
                                VehicleType = vehicle.VehicleType,
                                Position = vehicle.Position,
                                VehicleTypeId = vehicle.VehicleTypeId
                            }
                        }
                    ).ToListAsync();

                    var availableGV = scheduler.returnAvailableGroundVehicles(model, schedulesOrdered);
                    if (availableGV.Any())
                    {
                        var schedule = scheduler.assignModelToGroundVehicle(model, availableGV.ElementAt(0));
                        Console.WriteLine($"Order: {schedule.OrderId}; Vehicle: {schedule.GroundVehicleId}");
                        await _context.VehicleSchedules.AddAsync(schedule);
                        await _context.SaveChangesAsync();

                        schedulesToBeReturned.Add(schedule);
                    }
                }
            }
            
            return schedulesToBeReturned;
        }
    }
}