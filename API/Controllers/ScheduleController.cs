using API.Data;
using API.Entity;
using API.Models;
using API.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var vehicles = totalSchedules;
            var schedulesToBeReturned = new List<VehicleSchedule>();

            if (!totalSchedules.Any())
            {
                //     var groundVehicles = await _context.GroundVehicles.ToListAsync();
                //     var scheduleSeed = new List<VehicleSchedule>();

                //     var order = new Order
                //     {
                //         OrderId = 0,
                //         Flight = new Flight {
                //                         Arrival = new DateTime(2000, 01, 01, 00, 00, 00),
                //                         Departure = new DateTime(2000, 01, 01, 00, 00, 00)
                //                     },
                //         StartOfService = DateTime.UtcNow,
                //         EndOfService = DateTime.UtcNow
                //     };

                //     foreach (var vehicle in groundVehicles)
                //     {
                //         scheduleSeed.Add(
                //             new VehicleSchedule
                //             {
                //                 OrderId = 9999,
                //                 GroundVehicleId = vehicle.GroundVehicleId
                //             }
                //         );
                //     }

                //     await _context.VehicleSchedules.AddRangeAsync(scheduleSeed);
                //     await _context.SaveChangesAsync();

                //     return Ok("Schedules are Initialized");

                var scheduler = new Scheduler();
                var currentOrders = await this._context.Orders.ToListAsync();

                var baseModels = scheduler.calculateSlackAndMapToSchedulingModel(currentOrders);

                foreach (var baseModel in baseModels)
                {
                    var totalVehicles = _context.GroundVehicles
                        .Where(v => v.VehicleTypeId == baseModel.Order.VehicleTypeId)
                        .Count();

                    var schedules = await _context.VehicleSchedules
                        .Where(s => s.GroundVehicle.VehicleTypeId == baseModel.Order.VehicleTypeId)
                        .ToListAsync();

                    if (schedules.Count() == totalVehicles)
                    {
                        var schedulesOrdered = await (
                        from vS in _context.VehicleSchedules
                        join v in _context.GroundVehicles
                        on vS.GroundVehicleId equals v.GroundVehicleId into __groundVehicleIds
                        from vehicle in __groundVehicleIds.DefaultIfEmpty()

                        join o in _context.Orders
                        on vS.OrderId equals o.OrderId into __orders
                        from order in __orders.DefaultIfEmpty()

                        join f in _context.Flights
                        on vS.Order.FlightId equals f.FlightId into __flights
                        from flight in __flights.DefaultIfEmpty()

                        where vS.GroundVehicle.VehicleTypeId == baseModel.Order.VehicleTypeId
                        select new VehicleSchedule
                        {
                            OrderId = vS.OrderId,
                            Order = new Order
                            {
                                OrderId = order.OrderId,
                                StartOfService = order.StartOfService,
                                EndOfService = order.EndOfService,
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
                            },
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

                        var availableGV = scheduler.returnAvailableGroundVehicles(baseModel, schedulesOrdered);

                        if (availableGV.Any())
                        {
                            var schedule = scheduler.assignModelToGroundVehicle(baseModel, availableGV.ElementAt(0));
                            Console.WriteLine($"Order: {schedule.OrderId}; Vehicle: {schedule.GroundVehicleId}");
                            await _context.VehicleSchedules.AddAsync(schedule);
                            await _context.SaveChangesAsync();

                            schedulesToBeReturned.Add(schedule);
                        }
                    }
                    else
                    {
                        var groundVehicles = await _context.GroundVehicles
                            .Where(gV => gV.VehicleTypeId == baseModel.Order.VehicleTypeId).ToListAsync();

                        var availableVehicles = new List<GroundVehicle>();

                        if (schedules.Any())
                        {
                            foreach (var schedule in schedules)
                            {
                                foreach (var vehicle in groundVehicles)
                                {
                                    if (schedule.GroundVehicleId != vehicle.GroundVehicleId)
                                    {
                                        availableVehicles.Add(vehicle);
                                    }
                                }
                            }
                        }
                        else
                        {
                            availableVehicles.AddRange(groundVehicles);
                        }


                        if (availableVehicles.Any())
                        {
                            var schedule = scheduler.assignModelToGroundVehicle(baseModel, availableVehicles.ElementAt(0));
                            Console.WriteLine($"Order: {schedule.OrderId}; Vehicle: {schedule.GroundVehicleId}");
                            await _context.VehicleSchedules.AddAsync(schedule);
                            await _context.SaveChangesAsync();

                            schedulesToBeReturned.Add(schedule);
                        }
                    }


                }

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

                        join o in _context.Orders
                        on vS.OrderId equals o.OrderId into __orders
                        from order in __orders.DefaultIfEmpty()

                        join f in _context.Flights
                        on vS.Order.FlightId equals f.FlightId into __flights
                        from flight in __flights.DefaultIfEmpty()

                        where vS.GroundVehicle.VehicleTypeId == model.Order.VehicleTypeId
                        select new VehicleSchedule
                        {
                            OrderId = vS.OrderId,
                            Order = new Order
                            {
                                OrderId = order.OrderId,
                                StartOfService = order.StartOfService,
                                EndOfService = order.EndOfService,
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
                            },
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

        [HttpGet("schedule")]
        public async Task<ActionResult<IEnumerable<VehicleSchedule>>> InitiateSchedule()
        {

            var orders = await _context.Orders.ToListAsync();
            if (!orders.Count.Equals(0))
            {
                //Intanciate Scheduler
                var scheduler = new Scheduler();

                //Calculate Slack and map to ScheduleBaseModel
                var calculatedBaseModels = scheduler.calculateSlackAndMapToSchedulingModel(orders);

                foreach (var baseModel in calculatedBaseModels)
                {
                    //Check how much vehicles exist of orders vehicle type
                    var vehicles = await _context.GroundVehicles
                        .Where(v => v.VehicleTypeId == baseModel.Order.VehicleTypeId)
                        .ToListAsync();

                    //Check if there are Schedules in Database which VehicleType equals BaseModel´s VehicleType
                    var schedules = await _context.VehicleSchedules
                        .Where(s => s.GroundVehicle.VehicleTypeId == baseModel.Order.VehicleTypeId)
                        .ToListAsync();

                    //If no schedules have been found the order can be assinged and added directly
                    if (schedules.Count().Equals(0))
                    {
                        await scheduler.ClearOrderDelay(baseModel, _context);
                        var newVehicleSchedule = scheduler.assignModelToGroundVehicle(baseModel, vehicles.ElementAt(0));
                        Console.WriteLine($"Order: {newVehicleSchedule.OrderId}; Vehicle: {newVehicleSchedule.GroundVehicleId}");
                        await _context.VehicleSchedules.AddAsync(newVehicleSchedule);
                        await _context.SaveChangesAsync();
                    }
                    //If count of schedules is less-than or equal to the total amount of vehicles 
                    // -> Check which vehicle isn´t scheduled yet -> schedule that vehicle
                    else if (schedules.Count() < vehicles.Count())
                    {
                        // var availableVehicles = new List<GroundVehicle>();

                        //Extract Ground Vehicles from each schedule
                        var extractedGroundVehicles = new List<GroundVehicle>();
                        foreach (var schedule in schedules)
                        {
                            extractedGroundVehicles.Add(schedule.GroundVehicle);
                        }

                        //Save vehicles of scheduling except already scheduled vehicles
                        var availableVehicles = vehicles.Except(extractedGroundVehicles);

                        await scheduler.ClearOrderDelay(baseModel, _context);
                        var newVehicleSchedule = scheduler.assignModelToGroundVehicle(baseModel, availableVehicles.ElementAt(0));
                        Console.WriteLine($"Order: {newVehicleSchedule.OrderId}; Vehicle: {newVehicleSchedule.GroundVehicleId}");
                        await _context.VehicleSchedules.AddAsync(newVehicleSchedule);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var newVehicleSchedule = new VehicleSchedule();
                        //Check if the baseModel can be scheduled before or after any existing schedule
                        //Calculate time differences to schedule efficency
                        var timeDifferences = new List<SchedulingTimeDifference>();
                        //var soretedSchedules = schedules.OrderByDescending(s => s.ScheduleId).ToList();
                        foreach (var schedule in schedules)
                        {
                            var timeDifference = new SchedulingTimeDifference();
                            var timeParts = new List<TimeSpan>();

                            // if (schedule.Order.StartOfService >= baseModel.Deadline.AddMinutes(5)
                            // && timeDifferences.Count() == 0)
                            // {
                            //     //The delay has to be cleared. So in case of a new scheduling cycle the delay will be calculated new
                            //     await scheduler.ClearOrderDelay(baseModel, _context);
                            //     newVehicleSchedule = scheduler.assignModelToGroundVehicle(baseModel, schedule.GroundVehicle);
                            // }
                            if (schedule.Order.EndOfService.AddMinutes(5) <= baseModel.eSoS)
                            {
                                //The delay has to be cleared. So in case of a new scheduling cycle the delay will be calculated new
                                await scheduler.ClearOrderDelay(baseModel, _context);
                                newVehicleSchedule = scheduler.assignModelToGroundVehicle(baseModel, schedule.GroundVehicle);
                            }
                            //If the flight couldn´t be scheduled before or after already scheduled flights
                            //the order gets an delay and will be scheduled after regurarely orders
                            else
                            {
                                //Calculate Delay and store delay + schedule object to timeDifference object
                                var delay = baseModel.eSoS - schedule.Order.EndOfService;
                                timeDifference.duration = delay;
                                timeDifference.schedule = schedule;
                                //Add time differences of between base model and schedule
                                timeDifferences.Add(timeDifference);
                            }
                        }

                        //If the flight can be scheduled before or after existent schedules the time differences
                        //list is empty. Following actions are only for flights which get an delay
                        if (timeDifferences.Count() > 0)
                        {
                            //Sort the list ascending = the smallest delay should be chosen
                            timeDifferences.Sort((s1, s2) => s1.duration.CompareTo(s2.duration));
                            var chosenSchedule = timeDifferences.Last().schedule;
                            var newBaseModel = baseModel;
                            //If the chosen schedule has already a delay it has to be added to the following delay else not
                            if (!chosenSchedule.Order.Delay.Equals(null))
                            {
                                newBaseModel.eSoS = (DateTime)(chosenSchedule.Order.EndOfService.AddMinutes(5) + chosenSchedule.Order.Delay);
                            }
                            else
                            {
                                newBaseModel.eSoS = chosenSchedule.Order.EndOfService.AddMinutes(5);
                            }
                            //Set new baseModel´s Start of Service (inclusive delays)
                            newBaseModel.Deadline = newBaseModel.eSoS + newBaseModel.timeToRun;
                            //Assing new baseModel to its vehicle
                            newVehicleSchedule = scheduler.assignModelToGroundVehicle(newBaseModel, chosenSchedule.GroundVehicle);
                            //Set delay to orders database entry
                            var test = scheduler.SetOrderDelay(newBaseModel, _context);
                        }


                        Console.WriteLine($"Order: {newVehicleSchedule.OrderId}; Vehicle: {newVehicleSchedule.GroundVehicleId}");
                        await _context.VehicleSchedules.AddAsync(newVehicleSchedule);
                        await _context.SaveChangesAsync();

                    }
                }
            }
            else
            {
                return NotFound();
            }

            var allSchedules = await _context.VehicleSchedules.ToListAsync();

            return allSchedules;
        }

        [HttpGet("updateSchedule")]
        public async Task<ActionResult<IEnumerable<VehicleSchedule>>> UpdateSchedule()
        {
            var totalSchedules = await _context.VehicleSchedules.ToListAsync();

            if (!totalSchedules.Equals(null))
            {
                _context.VehicleSchedules.RemoveRange(totalSchedules);
                await _context.SaveChangesAsync();
            }


            return await InitiateSchedule();
        }

        private object List<T>()
        {
            throw new NotImplementedException();
        }
    }
}