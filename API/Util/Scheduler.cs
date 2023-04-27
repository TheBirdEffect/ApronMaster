using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entity;
using API.Models;

namespace API.Util
{
    public class Scheduler
    {
        public Scheduler()
        {
            setBasicScheduleCollection();
        }

        public ICollection<List<SchedulingBaseModel>> Schedule { get; set; }

        public void setBasicScheduleCollection() 
        {
            var amountOfVehicleTypes = Enum.GetNames(typeof(VehicleTypeEnum)).Count();
            Schedule = new List<List<SchedulingBaseModel>>();
            for(int index = 0; index < amountOfVehicleTypes; index++) 
            {
                this.Schedule.Add(new List<SchedulingBaseModel>());
            }   
        }

        public ICollection<SchedulingBaseModel> getVehicleScheduleList(VehicleTypeEnum type) 
        {
            return this.Schedule.ElementAt((int)type);
        }

        public void setVehicleScheduleList(List<SchedulingBaseModel> model, VehicleTypeEnum type) 
        {
            //Hier Soll ein Model zu einer bestehenden liste nach vehicle Enum geadded werden
            this.Schedule.Add(model);
        }

        public ICollection<Flight> preScheduleFlights(ICollection<Flight> flights) 
        {
            var orderedFlightList = new List<Flight>();
            orderedFlightList = flights.OrderBy(f => f.Arrival).ToList();

            return orderedFlightList;
        }
        public VehicleSchedule scheduleVehicles(Order order, GroundVehicle groundVehicle) 
        {
            var _order = order;

            var _schedule = new VehicleSchedule {
                OrderId = _order.OrderId,
                GroundVehicleId = groundVehicle.GroundVehicleId
            };
            
            return _schedule;
        }
    }
}