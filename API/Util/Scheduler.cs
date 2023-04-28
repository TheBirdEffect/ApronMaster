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

            model.Slack = model.Deadline.ToOADate() - currentTime.ToOADate() - remainingTimeToRun.TotalDays;
            //returns slack value 
            return model.Slack;
        }

        public ICollection<SchedulingBaseModel> assignOrderToVehicle(ICollection<SchedulingBaseModel> model)
        {
            //receives a list of preordered orders descending by slack
            //Assigns a physical vehicle to orders 
            return new List<SchedulingBaseModel>();
        }

        public ICollection<List<Order>> splitOrdersIntoSeperateLists(ICollection<Order> orders)
        {
            //Receive list of orders for different vehicles of different flights
            var seperatedOrderLists = new List<Order>[12];
            //split orders by vehicletype and store it into a list
            foreach (var order in orders)
            {
                var vehicleIndex = order.VehicleTypeId;
                if (seperatedOrderLists[vehicleIndex] != null)
                {
                    seperatedOrderLists[vehicleIndex].Add(order);
                } else {
                    seperatedOrderLists[vehicleIndex] = new List<Order>();
                    seperatedOrderLists[vehicleIndex].Add(order);
                }
            }

            return seperatedOrderLists;
        }

        public ICollection<SchedulingBaseModel> calculateSlackAndMapToSchedulingModel(ICollection<Order> Orders)
        {
            var t_orderedOrders = Orders.OrderBy(o => o.StartOfService);
            DateTime currentTime = new DateTime(2023, 04, 30, 12, 15, 00);
            var scheduledModels = new List<SchedulingBaseModel>();
            Console.WriteLine("--------------------------- Ordered: ---------------------------");
            for(var index = 0; index < t_orderedOrders.Count(); index++) 
            {
                Console.WriteLine($"OrderNumber: {t_orderedOrders.ElementAt(index).OrderId} eSoS: {t_orderedOrders.ElementAt(index).StartOfService}");
            }
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
                scheduledModels.Add(t_baseModel);
            }

            //Order Models acending by slack
            // scheduledModels.Sort((a,b) => a.Slack.CompareTo(b.Slack));
            scheduledModels.OrderBy(m => m.Order.OrderId).ToList();
            //returns a List of scheduling base models 
            Console.WriteLine("--------------------------- Ordered: ---------------------------");
            foreach(var model in scheduledModels) 
            {
                Console.WriteLine($"OrderNumber: {model.Order.OrderId}, Slack: {model.Slack}");
            }

            return scheduledModels;
        }
    }
}