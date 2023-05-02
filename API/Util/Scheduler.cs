using API.Entity;
using API.Models;

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
            //Receives SchedulingBaseModel and eSoS of the flight n-1
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

            foreach (var schedule in schedVehicle)
            {
                //check if vehicle can be scheduled before currently existent vehicle scheduling
                if (Deadline <= (schedule.Order.StartOfService.AddMinutes(-5)))
                {
                    Console.WriteLine($"Deadline of new Order: {Deadline}; Estimated start of Sevice existent scheduling: {schedule.Order.StartOfService.AddMinutes(-5)}");
                    availableVehicles.Add(schedule.GroundVehicle);
                }
                else if (eSoS >= schedule.Order.EndOfService.AddMinutes(5))
                {
                    Console.WriteLine($"Deadline of new Order: {eSoS}; Estimated start of Sevice existent scheduling: {schedule.Order.EndOfService.AddMinutes(5)}");
                    availableVehicles.Add(schedule.GroundVehicle);
                }
            }

            return availableVehicles;
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