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

        Flight tFlight0;
        Flight tFlight1;
        Flight tFlight2;
        Flight tFlight3;

        Order tOrder0;
        Order tOrder2;
        Order tOrder5;
        Order tOrder8;
        GroundVehicle tVehicle0;
        // GroundVehicle tVehicle1;
        // GroundVehicle tVehicle2;
        GroundVehicle tVehicle3;
        VehicleSchedule tSchedule0;
        VehicleSchedule tSchedule1;
        List<Order> tOrders;
        List<GroundVehicle> tGroundVehicles;
        List<VehicleSchedule> tSchedules;


        [TestInitialize]
        public void initializeSchedulerObject()
        {
            tScheduler = new Scheduler();

            tOrder0 = new Order();

            tVehicle0 = new GroundVehicle();
            // tVehicle1 = new GroundVehicle();
            // tVehicle2 = new GroundVehicle();
            tVehicle3 = new GroundVehicle();

            tOrders = new List<Order>();

            tGroundVehicles = new List<GroundVehicle>();

            tSchedules = new List<VehicleSchedule>();

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
                Departure = new DateTime(2023, 04, 30, 13, 30, 00),
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
                VehicleTypeId = 11,
                StartOfService = new DateTime(2023, 04, 30, 12, 05, 00),
                EndOfService = new DateTime(2023, 04, 30, 12, 45, 00),
                PositionId = 3,
                Flight = tFlight0,
            };
            var tOrder1 = new Order
            {
                OrderId = 1,
                VehicleTypeId = 11,
                StartOfService = new DateTime(2023, 04, 30, 12, 10, 00),
                EndOfService = new DateTime(2023, 04, 30, 12, 25, 00),
                PositionId = 3,
                Flight = tFlight0,
            };
            tOrder2 = new Order
            {
                OrderId = 2,
                VehicleTypeId = 5,
                StartOfService = new DateTime(2023, 04, 30, 12, 05, 00),
                EndOfService = new DateTime(2023, 04, 30, 12, 45, 00),
                PositionId = 3,
                Flight = tFlight0,
            };
            var tOrder3 = new Order
            {
                OrderId = 3,
                VehicleTypeId = 11,
                StartOfService = new DateTime(2023, 04, 30, 12, 20, 00),
                EndOfService = new DateTime(2023, 04, 30, 13, 00, 00),
                PositionId = 5,
                Flight = tFlight1,
            };
            var tOrder4 = new Order
            {
                OrderId = 4,
                VehicleTypeId = 11,
                StartOfService = new DateTime(2023, 04, 30, 12, 25, 00),
                EndOfService = new DateTime(2023, 04, 30, 12, 35, 00),
                PositionId = 5,
                Flight = tFlight1,
            };
            tOrder5 = new Order
            {
                OrderId = 5,
                VehicleTypeId = 5,
                StartOfService = new DateTime(2023, 04, 30, 12, 20, 00),
                EndOfService = new DateTime(2023, 04, 30, 13, 00, 00),
                PositionId = 5,
                Flight = tFlight1,
            };
            var tOrder6 = new Order
            {
                OrderId = 6,
                VehicleTypeId = 11,
                StartOfService = new DateTime(2023, 04, 30, 12, 50, 00),
                EndOfService = new DateTime(2023, 04, 30, 13, 30, 00),
                PositionId = 9,
                Flight = tFlight2,
            };
            var tOrder7 = new Order
            {
                OrderId = 7,
                VehicleTypeId = 11,
                StartOfService = new DateTime(2023, 04, 30, 13, 00, 00),
                EndOfService = new DateTime(2023, 04, 30, 13, 20, 00),
                PositionId = 9,
                Flight = tFlight2,
            };
            tOrder8 = new Order
            {
                OrderId = 8,
                VehicleTypeId = 5,
                StartOfService = new DateTime(2023, 04, 30, 12, 50, 00),
                EndOfService = new DateTime(2023, 04, 30, 13, 45, 00),
                PositionId = 9,
                Flight = tFlight2,
            };

            tVehicle0 = new GroundVehicle
            {
                GroundVehicleId = 0,
                Name = "LuggageTruck0",
                PositionId = 6,
                IsIdling = false,
                VehicleTypeId = 11
            };

            var tVehicle1 = new GroundVehicle
            {
                GroundVehicleId = 1,
                Name = "Belt0",
                PositionId = 6,
                IsIdling = true,
                VehicleTypeId = 5
            };

            var tVehicle2 = new GroundVehicle
            {
                GroundVehicleId = 2,
                Name = "Belt1",
                PositionId = 6,
                IsIdling = true,
                VehicleTypeId = 5
            };

            tVehicle3 = new GroundVehicle
            {
                GroundVehicleId = 3,
                Name = "Belt2",
                PositionId = 6,
                IsIdling = true,
                VehicleTypeId = 5
            };

            tSchedule0 = new VehicleSchedule 
            {
                ScheduleId = 0,
                GroundVehicle = tVehicle1,
                Order = tOrder2
            };

            tSchedule1 = new VehicleSchedule 
            {
                ScheduleId = 1,
                GroundVehicle = tVehicle2,
                Order = tOrder5
            };

            tOrders.Add(tOrder2);
            tOrders.Add(tOrder1);
            tOrders.Add(tOrder0);
            tOrders.Add(tOrder3);
            tOrders.Add(tOrder5);
            tOrders.Add(tOrder4);
            tOrders.Add(tOrder7);
            tOrders.Add(tOrder8);
            tOrders.Add(tOrder6);

            tGroundVehicles.Add(tVehicle1);
            tGroundVehicles.Add(tVehicle2);

            tSchedules.Add(tSchedule0);
            tSchedules.Add(tSchedule1);
        }

        [TestMethod]
        public void shouldReturnSlackForOrder()
        {
            var testTime = new DateTime(2023, 04, 30, 00, 00, 00);
            var _tSchedulingModel = tScheduler.mapOrderToBaseModel(tOrder0);
            var _tSlackTime = tScheduler.leastSlackTimeAlgorithm(
                _tSchedulingModel, testTime
            );

            Assert.AreEqual(1.0258680555523219, _tSlackTime, $"Current value: {_tSlackTime}");
        }

        

        // [TestMethod]
        // public void shouldSplitOrdersByVehicleType()
        // {
        //     var splittedOrdersList = tScheduler.splitOrdersIntoSeperateLists(tOrders).ElementAt(5);
        //     //The count of list elements equals two because the amount of vehicleTypes with number 3 is two
        //     Assert.AreEqual(2, splittedOrdersList.Count());

        //     splittedOrdersList = tScheduler.splitOrdersIntoSeperateLists(tOrders).ElementAt(11);
        //     //The count of list elements equals two because the amount of vehicleTypes with number 3 is one
        //     Assert.AreEqual(4, splittedOrdersList.Count());

        // }

        [TestMethod]
        public void shouldReturnOrderedListOfBaseModels()
        {
            var _listOfOrderedModels = tScheduler.calculateSlackAndMapToSchedulingModel(tOrders);
            for (int index = 0; index < _listOfOrderedModels.Count - 1; index++)
            {
                Assert.IsTrue(
                    _listOfOrderedModels.ElementAt(index).Slack
                    <= _listOfOrderedModels.ElementAt(index + 1).Slack);
            }
        }

        [TestMethod]
        public void shouldReturnOrderAssignedToVehicle()
        {
            var _tSchedulingModel = tScheduler.mapOrderToBaseModel(tOrder0);
            var _tVehicleSchedule = tScheduler.assignModelToGroundVehicle(
                _tSchedulingModel, tVehicle0
            );

            Assert.AreEqual(0, _tVehicleSchedule.OrderId);
            Assert.AreEqual(0, _tVehicleSchedule.GroundVehicleId);
        }
    }
}