using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;

namespace API.Models
{
    public class SchedulingBaseModel
    {
        public Flight Flight { get; set; }
        public GroundVehicle Vehicle { get; set; }
        public Order Order { get; set; }
        public TimeSpan timeToRun { get; set; }
        public DateTime eSoS { get; set; }
        public DateTime Deadline { get; set; }
        public double Slack { get; set; }
    }
}