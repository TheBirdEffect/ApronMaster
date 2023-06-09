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
                        //Calculate time differences to schedule efficency
                        var timeDifferences = new List<SchedulingTimeDifference>();
                        foreach (var schedule in schedules)
                        {
                            var timeDifference = new SchedulingTimeDifference();
                            var timeParts = new List<TimeSpan>();

                            //the order gets an delay and will be scheduled after regurarely orders
                            //Calculate Delay and store delay + schedule object to timeDifference object
                            var delay = baseModel.eSoS - schedule.Order.EndOfService;
                            timeDifference.duration = delay;
                            timeDifference.schedule = schedule;
                            //Add time differences of between base model and schedule
                            timeDifferences.Add(timeDifference);
                        }

                        //If the flight can be scheduled before or after existent schedules the time differences
                        //list is empty. Following actions are only for flights which get an delay
                        if (timeDifferences.Count() > 0)
                        {
                            var chosenSchedule = new VehicleSchedule();
                            //Sort the list ascending = the latest EoS-Time should be chosen
                            timeDifferences.Sort((s1, s2) => s1.schedule.Order.EndOfService.CompareTo(s2.schedule.Order.EndOfService));
                            //Store schedules which share same resource
                            var listOfDuplicatesOnResource = timeDifferences.Where(d => d.schedule.GroundVehicleId == timeDifferences.First().schedule.GroundVehicleId);
                            //If there are schedules which share resource take the scheduling with the latest EoS
                            if (listOfDuplicatesOnResource.Count() > 1)
                            {
                                var scheduleWithoutDuplicate = timeDifferences.Except(listOfDuplicatesOnResource);
                                var listOfDuplicatesSorted = listOfDuplicatesOnResource.OrderByDescending(o => o.schedule.Order.EndOfService);
                                scheduleWithoutDuplicate.Append(listOfDuplicatesSorted.First());
                                //The chosen schedule has the absolut minimum of EoS of the amount of schedules
                                chosenSchedule = scheduleWithoutDuplicate.OrderBy(o => o.schedule.Order.EndOfService).First().schedule;
                            }
                            else
                            {
                                chosenSchedule = timeDifferences.First().schedule;
                            }
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