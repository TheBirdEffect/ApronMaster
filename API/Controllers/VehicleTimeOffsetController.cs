using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /*
        The controller methods in this class only will return static values which represent
        Vehicle offsets of dynamic generatable ground vehicles. 
        This methods don´t consume any Parameters. This methods only return objects of type
        TurnaroundVehicleTimeOffset.
    */
    public class VehicleTimeOffsetController : BaseController
    {
        private readonly DataContext _context;
        public VehicleTimeOffsetController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("get/refuling")]
        public ActionResult<TurnarroundVehicleTimeOffset> GetRefulingTimeOffset()
        {
            return new TurnarroundVehicleTimeOffset
            {
                VehicleTypeId = 9,
                TimeOffsetStart = 0,
                TimeOffsetEnd = 20
            };
        }

        [HttpGet("get/service")]
        public ActionResult<IEnumerable<TurnarroundVehicleTimeOffset>> GetServiceTimeOffset()
        {

            TurnarroundVehicleTimeOffset[] offsets = {
                    new TurnarroundVehicleTimeOffset
                    {
                        VehicleTypeId = 8,
                        TimeOffsetStart = 0,
                        TimeOffsetEnd = 20
                    },

                    new TurnarroundVehicleTimeOffset
                    {
                        VehicleTypeId = 7,
                        TimeOffsetStart = 20,
                        TimeOffsetEnd = 35
                    }
                };

            return offsets;
        }

        [HttpGet("get/pushback")]
        public ActionResult<TurnarroundVehicleTimeOffset> GetPushbackTimeOffset()
        {
            return new TurnarroundVehicleTimeOffset
            {
                VehicleTypeId = 1,
                TimeOffsetStart = -20,
                TimeOffsetEnd = -5  
            };
        }
    }
}