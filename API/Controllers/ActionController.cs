using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controllers
{
    public class ActionController : BaseController
    {
        private readonly DataContext _context;

        public ActionController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("calculate")]
        public void shouldCalculateRoutes()
        {
            var flights = _context.Flights.ToList();
            Console.WriteLine($"The number of flights is currently {flights.Count()}");
            foreach(var flight in flights)
            {
                Console.WriteLine($"{flight.FlightId} {flight.FlightNo} {flight.Arrival} {flight.Departure} {flight.Destination} {_context.AircraftTypes.Find(flight.AircraftTypeId).Name}");
            }
        }
    }
}