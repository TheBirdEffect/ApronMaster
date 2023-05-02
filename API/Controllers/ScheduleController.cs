using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using API.Util;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace API.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly DataContext _context;
        public ScheduleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleSchedule>>> SetSchedule()
        {
            var scheduler = new Scheduler();
            var currentOrders = await this._context.Orders.ToListAsync();

            var baseModels = scheduler.calculateSlackAndMapToSchedulingModel(currentOrders);

            foreach (var model in baseModels)
            {
                var availableVehicles = new List<VehicleSchedule>();

                var totalSchedules = await _context.VehicleSchedules
                    .Where(gV => gV.Order.VehicleTypeId == model.Order.VehicleTypeId
                    ).ToListAsync();

                foreach(var schedule in totalSchedules)
                {
                    availableVehicles =  await _context.GroundVehicles
                            .Where(v => v.GroundVehicleId != schedule.GroundVehicleId);

                }

                Console.WriteLine($"Length: {totalVehicles.Count()}; TypeId: {model.Order.VehicleTypeId}");

            //     foreach (var vehicle in availableVehicles)
            //     {
            //         if (vehicle.GroundVehicleId.Equals(null))
            //         {
            //             var vehicleSchedule = scheduler.assignModelToGroundVehicle(
            //                 model, vehicle.GroundVehicle
            //             );

            //             this._context.Add(vehicleSchedule);
            //         }
            //         else
            //         {
            //             var schedulesOrdered = await this._context.VehicleSchedules
            //                 .Where(s =>
            //                 s.GroundVehicle.VehicleTypeId == model.Order.VehicleTypeId)
            //                 .ToListAsync();

            //             var availableGV = scheduler.returnAvailableGroundVehicles(model, schedulesOrdered);
            //         }
            //     }
            }

            return Ok();
        }
    }
}