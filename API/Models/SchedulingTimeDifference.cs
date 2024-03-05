using API.Entity;

namespace API.Models
{
    public class SchedulingTimeDifference
    {
        public VehicleSchedule schedule { get; set; }
        public TimeSpan duration { get; set; }
        public bool timeSpanBefore { get; set; }
    }
}