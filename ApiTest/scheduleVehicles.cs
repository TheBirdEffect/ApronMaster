using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;
using API.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTest
{
    [TestClass]
    public class scheduleVehicles
    {
        Scheduler tScheduler;
        GroundVehicle tVehicle;

        Flight tFlight0;
        Flight tFlight1;
        Flight tFlight2;
        Flight tFlight3;
        Order tOrder0;
        Order tOrder1;
        Order tOrder2;

        List<Order> tOrders;

        [TestInitialize]
        public void initializeSchedulerObject()
        {
            tScheduler = new Scheduler();

            tOrders = new List<Order>();

            tFlight0 = new Flight
            {
                FlightId = 0,
                AircraftTypeId = 1,
                Arrival = new DateTime(2023, 04, 30, 12, 00, 00),
                Departure = new DateTime(2023, 04, 30, 13, 00, 00),
                Destination = "EDDF",
                FlightNumber = "EZY004"
            };

            tFlight1 = new Flight
            {
                FlightId = 1,
                AircraftTypeId = 1,
                Arrival = new DateTime(2023, 04, 30, 12, 15, 00),
                Departure = new DateTime(2023, 04, 30, 13, 10, 00),
                Destination = "EDDT",
                FlightNumber = "EZY001"
            };
            tFlight2 = new Flight
            {
                FlightId = 2,
                AircraftTypeId = 1,
                Arrival = new DateTime(2023, 04, 30, 12, 30, 00),
                Departure = new DateTime(2023, 04, 30, 13, 25, 00),
                Destination = "EDDM",
                FlightNumber = "EZY002"
            };
            tFlight3 = new Flight
            {
                FlightId = 3,
                AircraftTypeId = 1,
                Arrival = new DateTime(2023, 04, 30, 12, 35, 00),
                Departure = new DateTime(2023, 04, 30, 13, 30, 00),
                Destination = "EDDB",
                FlightNumber = "EZY003"
            };

            tOrder0 = new Order
            {
                OrderId = 0,
                VehicleTypeId = 3,
                StartOfService = new DateTime(2023, 04, 30, 12, 05, 00),
                EndOfService = new DateTime(2023, 04, 30, 12, 45, 00),
                PositionId = 3,
                Flight = tFlight0,
            };
            tOrder1 = new Order
            {
                OrderId = 1,
                VehicleTypeId = 1,
                StartOfService = new DateTime(2023, 04, 30, 12, 20, 00),
                EndOfService = new DateTime(2023, 04, 30, 12, 55, 00),
                PositionId = 3,
                Flight = tFlight1,
            };
            tOrder2 = new Order
            {
                OrderId = 2,
                VehicleTypeId = 3,
                StartOfService = new DateTime(2023, 04, 30, 12, 35, 00),
                EndOfService = new DateTime(2023, 04, 30, 13, 15, 00),
                PositionId = 3,
                Flight = tFlight2,
            };
            tOrders.Add(tOrder2);
            tOrders.Add(tOrder1);
            tOrders.Add(tOrder0);
        }


        [TestMethod]
        public void shouldReturnSlackForOrder()
        {
            var _tSchedulingModel = tScheduler.mapOrderToBaseModel(tOrder0);
            var _tSlackTime = tScheduler.leastSlackTimeAlgorithm(
                _tSchedulingModel, tOrder0.StartOfService
            );

            Assert.AreEqual(3.2337604816135013E-12, _tSlackTime);
        }

        [TestMethod]
        public void shouldReturnOrderedListOfBaseModels()
        {
            var _listOfOrderedModels = tScheduler.scheduleOrders(tOrders);

            for (int index = 0; index < _listOfOrderedModels.Count - 1; index++)
            {
                Assert.IsTrue(
                    _listOfOrderedModels.ElementAt(index).Slack
                    < _listOfOrderedModels.ElementAt(index + 1).Slack);
            }

            Assert.AreEqual(0, _listOfOrderedModels.ElementAt(0).Flight.FlightId);
            Assert.AreEqual(0, _listOfOrderedModels.ElementAt(0).Order.OrderId);
        }

        [TestMethod]
        public void shouldSplitOrdersByVehicleType()
        {
            var splittedOrdersList = tScheduler.splitOrdersIntoSeperateLists(tOrders).ElementAt(3);
            //The count of list elements equals two because the amount of vehicleTypes with number 3 is two
            Assert.AreEqual(2, splittedOrdersList.Count());

            splittedOrdersList = tScheduler.splitOrdersIntoSeperateLists(tOrders).ElementAt(1);
            //The count of list elements equals two because the amount of vehicleTypes with number 3 is one
            Assert.AreEqual(1, splittedOrdersList.Count());

        }
    }
}