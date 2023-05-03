using API.Entity;
using API.Util;
using Microsoft.Data.Sqlite;

namespace ApiTest;

[TestClass]
public class scheduleFlights
{
    Scheduler _scheduler;
    Order _order;
    GroundVehicle _vehicle;

    Flight _flight1;
    Flight _flight2;
    Flight _flight3;
    Flight _flight4;
    List<Flight> _flights;


    [TestInitialize]
    public void initializeSchedulerObject()
    {
        _scheduler = new Scheduler();
        _flights = new List<Flight>();
        _vehicle = new GroundVehicle
        {
            GroundVehicleId = 1
        };


        _order = new Order
        {
            OrderId = 1
        };

        _flight1 = new Flight
        {
            FlightId = 0,
            AircraftTypeId = 1,
            Arrival = new DateTime(2023, 04, 30, 17, 00, 00),
            Departure = new DateTime(2023, 04, 30, 17, 55, 00),
            Destination = "EDDF",
            FlightNumber = "EZY004"
        };

        _flight2 = new Flight
        {
            FlightId = 1,
            AircraftTypeId = 1,
            Arrival = new DateTime(2023, 04, 30, 12, 00, 00),
            Departure = new DateTime(2023, 04, 30, 13, 00, 00),
            Destination = "EDDT",
            FlightNumber = "EZY001"
        };
        _flight3 = new Flight
        {
            FlightId = 2,
            AircraftTypeId = 1,
            Arrival = new DateTime(2023, 04, 30, 12, 20, 00),
            Departure = new DateTime(2023, 04, 30, 13, 15, 00),
            Destination = "EDDM",
            FlightNumber = "EZY002"
        };
        _flight4 = new Flight
        {
            FlightId = 3,
            AircraftTypeId = 1,
            Arrival = new DateTime(2023, 04, 30, 12, 35, 00),
            Departure = new DateTime(2023, 04, 30, 13, 30, 00),
            Destination = "EDDB",
            FlightNumber = "EZY003"
        };

        _flights.Add(_flight1);
        _flights.Add(_flight2);
        _flights.Add(_flight3);
        _flights.Add(_flight4);
    }

    [TestMethod]
    public void shouldOrderListOfFlights() 
    {
        var orderedFlights = _scheduler.preScheduleFlights(_flights);

        Assert.AreEqual(new DateTime(2023, 04, 30, 12, 00, 00), orderedFlights.First().Arrival, $"Arrival: {orderedFlights.First().Arrival}");
        Assert.AreEqual(new DateTime(2023, 04, 30, 12, 20, 00), orderedFlights.ElementAt(1).Arrival, $"Arrival: {orderedFlights.ElementAt(1).Arrival}");
        Assert.AreEqual(new DateTime(2023, 04, 30, 12, 35, 00), orderedFlights.ElementAt(2).Arrival, $"Arrival: {orderedFlights.ElementAt(1).Arrival}");
        Assert.AreEqual(new DateTime(2023, 04, 30, 17, 00, 00), orderedFlights.ElementAt(3).Arrival, $"Arrival: {orderedFlights.ElementAt(1).Arrival}");
    }


}