using API.Data;
using API.Entity;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Util
{
    /* 
        This Class provides several useful methods for the scheduling process
    */
    public class Scheduler
    {
        public ICollection<SchedulingBaseModel> Schedule { get; set; }

        /*
            Method: mapOrderToBaseModel
            Description: This method is used to map an order object to an SchedulingBaseModel object
            Params: Order object which is need to map to an BaseModel
            Returns: BaseModel object
        */
        public SchedulingBaseModel mapOrderToBaseModel(Order order)
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

        /*
            Method: leastSlckTimeAlgorithm
            Description: This mehtod is used to calculate slack time of a SchedulingBaseModel
            Params: SchedulingBaseModel which contains eSoS(SoS)- and Deadline(EoS) times and currentTime to calculate the Slack of the Order
            Returns: Calculated Slack
        */
        public double leastSlackTimeAlgorithm(SchedulingBaseModel model, DateTime currentTime)
        {
            //Receives SchedulingBaseModel and currentTime which is the timestamp of the moment of Schedule initialization
            //calculates the slack time of the order
            var remainingTimeToRun = model.Deadline - currentTime;

            model.Slack = model.Deadline.ToOADate() - currentTime.ToOADate() + (model.eSoS.ToOADate() - currentTime.ToOADate()) - (remainingTimeToRun.TotalHours / 1440);

            //returns slack value 
            return model.Slack;
        }

        /*
            Method: assignModelToGroundVehicle
            Description: This method assigns the SchedulingBaseModel and GroundVehicle to a VehicleSchedule after the scheduling process
            Params: SchedulingBaseModel and GroundVehicle which should to be mapped on a VehicleSchedule
            Returns: Final VehicleSchedule object
        */
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

        /*
        Method: SetOrderDelay
        Description: This method calculates the delay of an order after scheduling algorithm decided that the order has to be scheduled delayed
        Params: SchedulingBaseModel which has to scheduled delayed and the DataContext to access database 
        */
        public async Task<ActionResult<Order>> SetOrderDelay(SchedulingBaseModel model, DataContext context)
        {
            var order = await context.Orders.SingleAsync(o => o.OrderId.Equals(model.Order.OrderId));
            if (!order.Equals(null))
            {
                order.Delay = model.eSoS - order.StartOfService;

                await context.SaveChangesAsync();
                return order;
            }
            else
            {
                return null;
            }
        }

        /*
        Method: ClearOrderDelay
        Description: This method sets the delay in order to null if the scheduling algorithm decided that there is no mehr delay for chosen SchedulingBaseModel
        Params: SchedulingBaseModel for which the delay should be cleared and DataContext to access database 
        */
        public async Task<ActionResult<Order>> ClearOrderDelay(SchedulingBaseModel model, DataContext context)
        {
            var order = await context.Orders.SingleAsync(o => o.OrderId.Equals(model.Order.OrderId));
            if (!order.Equals(null))
            {
                order.Delay = null;

                await context.SaveChangesAsync();
                return order;
            }
            else
            {
                return null;
            }
        }

        /*
        Method: calculateSlackAndMapToSchedulingModel
        Description: This method is used to map a List of Orders to a List of SchedulingBaseModels. Also every the Slack of every SchedulingBaseModel will be calculated and stored to associated SchedulingBaseModel
        Params: ICollection (LIST) of orders which should be calculated and mapped
        Returns: List of calculated and mapped SchedulingBaseModels
        */
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

            return t_scheduledModels;
        }
    }
}