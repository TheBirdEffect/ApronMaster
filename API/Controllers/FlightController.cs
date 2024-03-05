using API.Data;
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

        /*
            This controller consumes a flightId and returns a Flight with informations of its belonging AircraftType.
            Params: Flight id of flight which should returned 
            Returns: Flight with full AircraftType-Object 
        */

        [HttpGet("full/{id}")]
        public async Task<ActionResult<Flight>> GetFlightFull(int id)
        {
            return await (from f in _context.Flights
                          join a in _context.AircraftTypes
                          on f.AircraftTypeId equals a.AircraftTypeId into __aircraftTypes
                          from aT in __aircraftTypes.DefaultIfEmpty()

                          where f.FlightId == id
                          select new Flight
                          {
                              FlightId = f.FlightId,
                              FlightNumber = f.FlightNumber,
                              Arrival = f.Arrival,
                              Departure = f.Departure,
                              Destination = f.Destination,
                              AircraftTypeId = f.AircraftTypeId,
                              AircraftType = new AircraftType
                              {
                                  AircraftTypeId = aT.AircraftTypeId,
                                  Name = aT.Name,
                                  hasUnitLoadOption = aT.hasUnitLoadOption
                              }
                          }
            ).FirstAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            return await _context.Flights.FindAsync(id);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Flight>> AddFlight(Flight flight)
        {
            if (flight.Equals(null)) return BadRequest("No valid flightplan object!");

            var _flight = new Flight
            {
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

        [HttpPost("update")]
        public async Task<ActionResult<Flight>> UpdateFlight(Flight flight)
        {
            var _flight = await _context.Flights.SingleAsync(f => f.FlightId == flight.FlightId);

            if (_flight != null)
            {
                if (_flight != flight)
                {
                    _flight.FlightId = flight.FlightId;
                    _flight.FlightNumber = flight.FlightNumber;
                    _flight.Arrival = flight.Arrival;
                    _flight.Departure = flight.Departure;
                    _flight.Destination = flight.Destination;
                    _flight.AircraftTypeId = flight.AircraftTypeId;
                }

                await _context.SaveChangesAsync();
                return Ok(_flight);
            }
            return NotFound("Cant update flight because flight was not found");
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Flight>> DeleteFlight(int id)
        {
            try
            {
                var _flight = await _context.Flights.FindAsync(id);
                if (_flight != null)
                {
                    _context.Flights.Remove(_flight);
                    var qtyDbActions = await _context.SaveChangesAsync();

                    if (qtyDbActions.Equals(1))
                    {
                        return _flight;
                    }
                    throw new Exception("Deletion failed");
                }
                else
                {
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