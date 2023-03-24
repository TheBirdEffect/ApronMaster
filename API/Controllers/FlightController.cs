using API.Data;
using API.DTOs;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class FlightController : BaseController
    {
        private readonly DataContext _context;
        public FlightController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights() 
        {
            return await _context.Flights.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            return await _context.Flights.FindAsync(id);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Flight>> AddFlight(Flight flight) 
        {
            if(flight.Equals(null)) return BadRequest("No valid flightplan object!");

            var _flight = new Flight {
                FlightNumber = flight.FlightNumber,
                Destination = flight.Destination,
                Arrival = flight.Arrival,
                Departure = flight.Departure,
                AircraftTypeId = flight.AircraftType.AircraftTypeId                            
            };

            await _context.Flights.AddAsync(_flight);
            await _context.SaveChangesAsync(); 

            return _flight;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Flight>> DeleteFlight(int id)
        {
           try 
            {
                var _flight = await _context.Flights.FindAsync(id); 
                if(_flight != null)
                {
                    _context.Flights.Remove(_flight);
                    var qtyDbActions = await _context.SaveChangesAsync();

                    if(qtyDbActions.Equals(1)){
                        return _flight;
                    }
                    throw new Exception("Deletion failed");
                } else {
                    return BadRequest();
                }
            }
            catch 
            {
                throw new Exception("Internal Server Error 500");
            }
        }


    }
}