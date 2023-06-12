using API.Entity;
using API.Util;

namespace ApiTest
{
    [TestClass]
    public class Mappings
    {
        Scheduler _scheduler = new Scheduler();
        Order tOrder;
        Flight tFlight;

        [TestInitialize]
        public void MapperTestInitialize() 
        {
            tFlight = new Flight {
                FlightId = 1,
                AircraftTypeId = 1,
                Arrival = new DateTime(2023, 04, 30, 12, 00, 00),
                Departure = new DateTime(2023, 04, 30, 13, 00, 00),
                Destination = "EDDT",
                FlightNumber = "EZY001"
            };

            tOrder = new Order {
                OrderId = 1,
                VehicleTypeId = 3,
                StartOfService = new DateTime(2023, 04, 30, 12, 05, 00),
                EndOfService = new DateTime(2023, 04, 30, 12, 45, 00),
                PositionId = 3,
                Flight = tFlight,

            };
        }

        [TestMethod]
        public void shouldMapToBaseModel()
        {
            var tBaseModel = _scheduler.mapOrderToBaseModel(tOrder);

            Assert.AreEqual(1, tBaseModel.Order.OrderId);
            Assert.AreEqual(3, tBaseModel.Order.VehicleTypeId);
            Assert.AreEqual(new DateTime(2023, 04, 30, 12, 05, 00), tBaseModel.eSoS);
            Assert.AreEqual(new DateTime(2023, 04, 30, 12, 45, 00), tBaseModel.Deadline);
            Assert.AreEqual(40, tBaseModel.timeToRun.TotalMinutes);
        }
    }
}