using API.Data;
using API.Entity;
using API.Extensions;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Util
{
    public class Scheduler
    {
        public ICollection<SchedulingBaseModel> Schedule { get; set; }

        public ICollection<Flight> preScheduleFlights(ICollection<Flight> flights)
        {
            var orderedFlightList = new List<Flight>();
            orderedFlightList = flights.OrderBy(f => f.Arrival).ToList();

            return orderedFlightList;
        }
        public SchedulingBaseModel mapOrderToBaseModel(Order order) //Test passed
        {
            var model = new SchedulingBaseModel();

            model.Order = order;

            //Static values for taxi-in-time and taxi-out-time should be loaded dynamically from database later
            //Add five minutes on arrival for taxi-in-time
            model.eSoS = order.StartOfService;

            //Subract ten minutes of departure time for taxi-out-time
            model.Deadline = order.EndOfService;

            model.timeToRun = order.EndOfService - order.StartOfService;

            return model;
        }

        public double leastSlackTimeAlgorithm(SchedulingBaseModel model, DateTime currentTime)
        {
            //Receives SchedulingBaseModel and currentTime which is the timestamp of the moment of Schedule initialization
            //calculates the slack time of the order
            var remainingTimeToRun = model.Deadline - currentTime;

            model.Slack = model.Deadline.ToOADate() - currentTime.ToOADate() + (model.eSoS.ToOADate() - currentTime.ToOADate()) - (remainingTimeToRun.TotalHours / 1440);

            //returns slack value 
            return model.Slack;
        }

        public ICollection<GroundVehicle> returnAvailableGroundVehicles(SchedulingBaseModel model, ICollection<VehicleSchedule> schedVehicle)
        {
            var eSoS = model.eSoS;
            var Deadline = model.Deadline;

            List<GroundVehicle> availableVehicles = new List<GroundVehicle>();

            ICollection<VehicleSchedule> preFilteredSchedules = new List<VehicleSchedule>();
            var listOfUnavailableVehicles = new List<GroundVehicle>();

            foreach (var schedule in schedVehicle)
            {
                if (
                    schedule.Order.StartOfService.AddMinutes(-5) <= eSoS
                    && Deadline <= schedule.Order.EndOfService.AddMinutes(5)
                )
                {
                    listOfUnavailableVehicles.Add(schedule.GroundVehicle);
                }
                else if (schedule.Order.StartOfService.AddMinutes(-5) <= eSoS
                    && Deadline <= schedule.Order.Flight.Departure)
                {
                    listOfUnavailableVehicles.Add(schedule.GroundVehicle);
                }
                // else if (schedule.Order.Flight.Arrival <= eSoS
                //     && Deadline <= schedule.Order.EndOfService.AddMinutes(5)
                // )
                // {
                //     listOfUnavailableVehicles.Add(schedule.GroundVehicle);
                // }
            }

            if (listOfUnavailableVehicles.Any())
            {
                foreach (var schedule in schedVehicle)
                {
                    foreach (var unavailableVehicle in listOfUnavailableVehicles)
                    {
                        if (schedule.GroundVehicle.GroundVehicleId != unavailableVehicle.GroundVehicleId)
                        {
                            preFilteredSchedules.Add(schedule);
                        }
                        //Hier muss ein weiter Zweig implementiert werden, der im Falle von zu wenig ressourcen, fahrzeuge hinten anstellt.
                    }
                }
            }
            else
            {
                preFilteredSchedules = schedVehicle;
            }


            foreach (var schedule in preFilteredSchedules)
            {
                //check if vehicle can be scheduled before currently existent vehicle scheduling
                if (Deadline <= (schedule.Order.StartOfService.AddMinutes(-5)))
                {
                    Console.WriteLine($"Deadline of new Order: {Deadline}; Estimated start of Sevice existent scheduling: {schedule.Order.StartOfService.AddMinutes(-5)}");
                    availableVehicles.Add(schedule.GroundVehicle);
                }
                else if (eSoS >= schedule.Order.EndOfService.AddMinutes(5))
                {
                    Console.WriteLine($"eSoS of new Order: {eSoS}; Deadline existent scheduling: {schedule.Order.EndOfService.AddMinutes(5)}");
                    availableVehicles.Add(schedule.GroundVehicle);
                }
            }

            return availableVehicles.ToList();
        }

        public VehicleSchedule assignModelToGroundVehicle(SchedulingBaseModel model, GroundVehicle vehicle)
        {
            //receives a list of preordered orders descending by slack
            var t_vehicleSchedule = new VehicleSchedule();
            var t_vehicles = new GroundVehicle();
            var t_model = new SchedulingBaseModel();

            t_vehicles = vehicle;
            t_model = model;

            t_vehicleSchedule.GroundVehicleId = vehicle.GroundVehicleId;
            t_vehicleSchedule.OrderId = model.Order.OrderId;

            return t_vehicleSchedule;
        }

        public async Task<ActionResult<Order>> UpdateOrderTimeOfService(SchedulingBaseModel model, DataContext context)
        {
            var order = await context.Orders.SingleAsync(o => o.OrderId.Equals(model.Order.OrderId));
            if (!order.Equals(null))
            {
                order.StartOfService = model.eSoS;
                order.EndOfService = model.Deadline;

                await context.SaveChangesAsync();
                return order;
            } else {
                return null;
            }
        }

        // public ICollection<List<Order>> splitOrdersIntoSeperateLists(ICollection<Order> orders)
        // {
        //     //Receive list of orders for different vehicles of different flights
        //     var seperatedOrderLists = new List<Order>[12];
        //     //split orders by vehicletype and store it into a list
        //     foreach (var order in orders)
        //     {
        //         var vehicleIndex = order.VehicleTypeId;
        //         if (seperatedOrderLists[vehicleIndex] != null)
        //         {
        //             seperatedOrderLists[vehicleIndex].Add(order);
        //         }
        //         else
        //         {
        //             seperatedOrderLists[vehicleIndex] = new List<Order>();
        //             seperatedOrderLists[vehicleIndex].Add(order);
        //         }
        //     }

        //     return seperatedOrderLists;
        // }

        public ICollection<SchedulingBaseModel> calculateSlackAndMapToSchedulingModel(ICollection<Order> Orders)
        {
            var t_orderedOrders = Orders.OrderBy(o => o.StartOfService);
            DateTime currentTime = DateTime.Now;

            var listOfModels = new List<SchedulingBaseModel>();

            //receives orders of several flights of preordered list
            foreach (var order in t_orderedOrders)
            {
                var t_baseModel = new SchedulingBaseModel();

                //uses maping method to map orders on schedulingBaseModels
                t_baseModel = this.mapOrderToBaseModel(order);

                //uses the LeastSlackTimeAlgorithm to calculate the slack time of one kind of vehicle of all prescheduled flights
                t_baseModel.Slack = this.leastSlackTimeAlgorithm(
                    t_baseModel, currentTime
                );
                t_baseModel.Slack = t_baseModel.Slack;
                listOfModels.Add(t_baseModel);
            }

            //Order Models acending by slack
            var t_scheduledModels = listOfModels.OrderBy(m => m.Slack).ToList();
            //returns a List of scheduling base models 

            //Debugging output for the case of a test failure
            Console.WriteLine("--------------------------- Ordered: ---------------------------");
            foreach (var model in t_scheduledModels)
            {
                Console.WriteLine($"OrderNumber: {model.Order.OrderId}, Slack: {model.Slack}");
            }

            return t_scheduledModels;
        }
    }
}