using API.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Migrations
{
    public static class ModelBuilderExtensions
    {
        public static void seedDemoData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AircraftType>().HasData(
                new AircraftType { AircraftTypeId = 1, Name = "Boeing737", hasUnitLoadOption = true },
                new AircraftType { AircraftTypeId = 2, Name = "Boeing737", hasUnitLoadOption = false },
                new AircraftType { AircraftTypeId = 3, Name = "AirbusA320", hasUnitLoadOption = true },
                new AircraftType { AircraftTypeId = 4, Name = "AirbusA320", hasUnitLoadOption = false },
                new AircraftType { AircraftTypeId = 5, Name = "AirbusA330", hasUnitLoadOption = true },
                new AircraftType { AircraftTypeId = 6, Name = "ATR-72", hasUnitLoadOption = false }
            );

            modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    FlightId = 1,
                    FlightNumber = "EZY2023",
                    Arrival = new DateTime(2023, 05, 10, 12, 00, 00),
                    Departure = new DateTime(2023, 05, 10, 12, 50, 00),
                    Destination = "EDDH",
                    AircraftTypeId = 2
                },

                new Flight
                {
                    FlightId = 2,
                    FlightNumber = "LH2134",
                    Arrival = new DateTime(2023, 05, 10, 14, 00, 00),
                    Departure = new DateTime(2023, 05, 10, 15, 15, 00),
                    Destination = "EDDM",
                    AircraftTypeId = 5
                },

                new Flight
                {
                    FlightId = 3,
                    FlightNumber = "LH789",
                    Arrival = new DateTime(2023, 05, 10, 14, 30, 00),
                    Departure = new DateTime(2023, 05, 10, 15, 15, 00),
                    Destination = "EDDB",
                    AircraftTypeId = 2
                },
                new Flight
                {
                    FlightId = 4,
                    FlightNumber = "EZY4903",
                    Arrival = new DateTime(2023, 05, 11, 05, 30, 00),
                    Departure = new DateTime(2023, 05, 11, 06, 45, 00),
                    Destination = "EDDB",
                    AircraftTypeId = 5
                },
                new Flight
                {
                    FlightId = 5,
                    FlightNumber = "TESTFLIGHT",
                    Arrival = new DateTime(2000, 01, 01, 00, 00, 00),
                    Departure = new DateTime(2000, 01, 01, 00, 01, 00),
                    Destination = "TEST",
                    AircraftTypeId = 5
                }
            );

            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = 1, Name = "62", IsGate = false },
                new Position { PositionId = 2, Name = "61", IsGate = true },
                new Position { PositionId = 3, Name = "51", IsGate = true },
                new Position { PositionId = 4, Name = "41", IsGate = false },
                new Position { PositionId = 5, Name = "42", IsGate = false },
                new Position { PositionId = 6, Name = "43", IsGate = false },
                new Position { PositionId = 7, Name = "44", IsGate = false },
                new Position { PositionId = 8, Name = "31", IsGate = false },
                new Position { PositionId = 9, Name = "32", IsGate = false },
                new Position { PositionId = 10, Name = "33", IsGate = false },
                new Position { PositionId = 11, Name = "21", IsGate = false },
                new Position { PositionId = 12, Name = "22", IsGate = false },
                new Position { PositionId = 13, Name = "23", IsGate = false },
                new Position { PositionId = 14, Name = "24", IsGate = false },
                new Position { PositionId = 15, Name = "Ground Vehicle Parking", IsGate = false },
                new Position { PositionId = 16, Name = "Ground Vehicle Maintainance", IsGate = false },
                new Position { PositionId = 17, Name = "Maschinenhalle Ost", IsGate = false },
                new Position { PositionId = 18, Name = "Tanklager West", IsGate = false }
            );

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { VehicleTypeId = 1, Name = "Pushback tug" },
                new VehicleType { VehicleTypeId = 2, Name = "Catering truck" },
                new VehicleType { VehicleTypeId = 3, Name = "Airstairs" },
                new VehicleType { VehicleTypeId = 4, Name = "Apron bus" },
                new VehicleType { VehicleTypeId = 5, Name = "Belt loader" },
                new VehicleType { VehicleTypeId = 6, Name = "Container loader" },
                new VehicleType { VehicleTypeId = 7, Name = "Water truck" },
                new VehicleType { VehicleTypeId = 8, Name = "Lavatory-service vehicle" },
                new VehicleType { VehicleTypeId = 9, Name = "Refueling truck" },
                new VehicleType { VehicleTypeId = 10, Name = "Ground power unit" },
                new VehicleType { VehicleTypeId = 11, Name = "Luggage truck" },
                new VehicleType { VehicleTypeId = 12, Name = "Container Truck" }
            );

            modelBuilder.Entity<GroundVehicle>().HasData(
                new GroundVehicle { GroundVehicleId = 1, Name = "Gepäckband1", IsIdling = true, PositionId = 15, VehicleTypeId = 5 },
                new GroundVehicle { GroundVehicleId = 2, Name = "Gepäckband2", IsIdling = true, PositionId = 15, VehicleTypeId = 5 },
                new GroundVehicle { GroundVehicleId = 3, Name = "Gepäckband3", IsIdling = true, PositionId = 15, VehicleTypeId = 5 },
                new GroundVehicle { GroundVehicleId = 4, Name = "Gepäckzug 1", IsIdling = true, PositionId = 15, VehicleTypeId = 11 },
                new GroundVehicle { GroundVehicleId = 5, Name = "Gepäckzug 2", IsIdling = true, PositionId = 15, VehicleTypeId = 11 },
                new GroundVehicle { GroundVehicleId = 6, Name = "Gepäckzug 3", IsIdling = true, PositionId = 15, VehicleTypeId = 11 },
                new GroundVehicle { GroundVehicleId = 7, Name = "Gepäckzug 4", IsIdling = true, PositionId = 15, VehicleTypeId = 11 },
                new GroundVehicle { GroundVehicleId = 8, Name = "Puck-Back Fahrzeug klein", IsIdling = true, PositionId = 17, VehicleTypeId = 1 },
                new GroundVehicle { GroundVehicleId = 9, Name = "Puck-Back Fahrzeug groß", IsIdling = true, PositionId = 17, VehicleTypeId = 1 },
                new GroundVehicle { GroundVehicleId = 10, Name = "Flugzeugtreppe klein", IsIdling = true, PositionId = 17, VehicleTypeId = 3 },
                new GroundVehicle { GroundVehicleId = 11, Name = "Flugzeugtreppe mittel", IsIdling = true, PositionId = 17, VehicleTypeId = 3 },
                new GroundVehicle { GroundVehicleId = 12, Name = "Flugzeugtreppe mittel", IsIdling = true, PositionId = 17, VehicleTypeId = 3 },
                new GroundVehicle { GroundVehicleId = 13, Name = "Flugzeugtreppe groß", IsIdling = true, PositionId = 17, VehicleTypeId = 3 },
                new GroundVehicle { GroundVehicleId = 14, Name = "Bus 1", IsIdling = true, PositionId = 17, VehicleTypeId = 4 },
                new GroundVehicle { GroundVehicleId = 15, Name = "Containerzug 1", IsIdling = true, PositionId = 17, VehicleTypeId = 12 },
                new GroundVehicle { GroundVehicleId = 16, Name = "Containerzug 2", IsIdling = true, PositionId = 17, VehicleTypeId = 12 },
                new GroundVehicle { GroundVehicleId = 17, Name = "Frischwasserfahrzeug", IsIdling = true, PositionId = 17, VehicleTypeId = 7 },
                new GroundVehicle { GroundVehicleId = 18, Name = "Entsorgungsfahrzeug", IsIdling = true, PositionId = 17, VehicleTypeId = 8 },
                new GroundVehicle { GroundVehicleId = 19, Name = "Tank LKW1 JETA1 ", IsIdling = true, PositionId = 18, VehicleTypeId = 9 },
                new GroundVehicle { GroundVehicleId = 20, Name = "Tank LKW2 JETA1", IsIdling = true, PositionId = 18, VehicleTypeId = 9 },
                new GroundVehicle { GroundVehicleId = 21, Name = "Tank LKW3 Avgas", IsIdling = true, PositionId = 18, VehicleTypeId = 9 },
                new GroundVehicle { GroundVehicleId = 22, Name = "GPU 1", IsIdling = true, PositionId = 17, VehicleTypeId = 10 },
                new GroundVehicle { GroundVehicleId = 23, Name = "GPU 2", IsIdling = true, PositionId = 17, VehicleTypeId = 10 },
                new GroundVehicle { GroundVehicleId = 24, Name = "GPU 2", IsIdling = true, PositionId = 17, VehicleTypeId = 10 },
                new GroundVehicle { GroundVehicleId = 25, Name = "High-Loader", IsIdling = true, PositionId = 17, VehicleTypeId = 6 }
            );

            modelBuilder.Entity<Order>().HasData(
                //Flug ID1
                new Order
                {
                    OrderId = 1,
                    StartOfService = new DateTime(2023, 05, 10, 12, 00, 00),
                    EndOfService = new DateTime(2023, 05, 10, 12, 30, 00),
                    PositionId = 3,
                    FlightId = 1,
                    VehicleTypeId = 5
                },
                new Order
                {
                    OrderId = 2,
                    StartOfService = new DateTime(2023, 05, 10, 12, 10, 00),
                    EndOfService = new DateTime(2023, 05, 10, 12, 35, 00),
                    PositionId = 3,
                    FlightId = 1,
                    VehicleTypeId = 5
                },
                new Order
                {
                    OrderId = 3,
                    StartOfService = new DateTime(2023, 05, 10, 12, 00, 00),
                    EndOfService = new DateTime(2023, 05, 10, 12, 35, 00),
                    PositionId = 3,
                    FlightId = 1,
                    VehicleTypeId = 11
                },
                new Order
                {
                    OrderId = 4,
                    StartOfService = new DateTime(2023, 05, 10, 12, 05, 00),
                    EndOfService = new DateTime(2023, 05, 10, 12, 35, 00),
                    PositionId = 3,
                    FlightId = 1,
                    VehicleTypeId = 11
                },
                new Order
                {
                    OrderId = 5,
                    StartOfService = new DateTime(2023, 05, 10, 12, 20, 00),
                    EndOfService = new DateTime(2023, 05, 10, 12, 30, 00),
                    PositionId = 3,
                    FlightId = 1,
                    VehicleTypeId = 7
                },
                new Order
                {
                    OrderId = 6,
                    StartOfService = new DateTime(2023, 05, 10, 12, 05, 00),
                    EndOfService = new DateTime(2023, 05, 10, 12, 15, 00),
                    PositionId = 3,
                    FlightId = 1,
                    VehicleTypeId = 8
                },
                new Order
                {
                    OrderId = 7,
                    StartOfService = new DateTime(2023, 05, 10, 12, 00, 00),
                    EndOfService = new DateTime(2023, 05, 10, 12, 35, 00),
                    PositionId = 3,
                    FlightId = 1,
                    VehicleTypeId = 3
                },
                new Order
                {
                    OrderId = 8,
                    StartOfService = new DateTime(2023, 05, 10, 12, 03, 00),
                    EndOfService = new DateTime(2023, 05, 10, 12, 18, 00),
                    fuelType = "JetA1",
                    QtyFuel = 12000,
                    PositionId = 3,
                    FlightId = 1,
                    VehicleTypeId = 9
                },
                new Order
                {
                    OrderId = 9,
                    StartOfService = new DateTime(2023, 05, 10, 12, 42, 00),
                    EndOfService = new DateTime(2023, 05, 10, 12, 50, 00),
                    PositionId = 3,
                    FlightId = 1,
                    VehicleTypeId = 1
                },

                //Flug ID2    
                new Order
                {
                    OrderId = 10,
                    StartOfService = new DateTime(2023, 05, 10, 14, 00, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 00, 00),
                    PositionId = 11,
                    FlightId = 2,
                    VehicleTypeId = 6
                },
                new Order
                {
                    OrderId = 11,
                    StartOfService = new DateTime(2023, 05, 10, 14, 00, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 05, 00),
                    PositionId = 11,
                    FlightId = 2,
                    VehicleTypeId = 3
                },
                new Order
                {
                    OrderId = 12,
                    StartOfService = new DateTime(2023, 05, 10, 14, 00, 00),
                    EndOfService = new DateTime(2023, 05, 10, 14, 30, 00),
                    PositionId = 11,
                    FlightId = 2,
                    VehicleTypeId = 12
                },
                new Order
                {
                    OrderId = 13,
                    StartOfService = new DateTime(2023, 05, 10, 14, 20, 00),
                    EndOfService = new DateTime(2023, 05, 10, 14, 50, 00),
                    PositionId = 11,
                    FlightId = 2,
                    VehicleTypeId = 12
                },
                new Order
                {
                    OrderId = 14,
                    StartOfService = new DateTime(2023, 05, 10, 14, 25, 00),
                    EndOfService = new DateTime(2023, 05, 10, 14, 40, 00),
                    PositionId = 11,
                    FlightId = 2,
                    VehicleTypeId = 7
                },
                new Order
                {
                    OrderId = 15,
                    StartOfService = new DateTime(2023, 05, 10, 14, 05, 00),
                    EndOfService = new DateTime(2023, 05, 10, 14, 25, 00),
                    PositionId = 11,
                    FlightId = 2,
                    VehicleTypeId = 8
                },
                new Order
                {
                    OrderId = 16,
                    StartOfService = new DateTime(2023, 05, 10, 14, 00, 00),
                    EndOfService = new DateTime(2023, 05, 10, 14, 45, 00),
                    PositionId = 11,
                    FlightId = 2,
                    VehicleTypeId = 3
                },
                new Order
                {
                    OrderId = 17,
                    StartOfService = new DateTime(2023, 05, 10, 14, 00, 00),
                    EndOfService = new DateTime(2023, 05, 10, 14, 20, 00),
                    fuelType = "JetA1",
                    QtyFuel = 30000,
                    PositionId = 11,
                    FlightId = 2,
                    VehicleTypeId = 9
                },
                new Order
                {
                    OrderId = 18,
                    StartOfService = new DateTime(2023, 05, 10, 14, 05, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 05, 00),
                    PositionId = 11,
                    FlightId = 2,
                    VehicleTypeId = 4
                },

                //Flug ID3
                new Order
                {
                    OrderId = 19,
                    StartOfService = new DateTime(2023, 05, 10, 14, 30, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 00, 00),
                    PositionId = 3,
                    FlightId = 3,
                    VehicleTypeId = 5
                },
                new Order
                {
                    OrderId = 20,
                    StartOfService = new DateTime(2023, 05, 10, 14, 40, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 05, 00),
                    PositionId = 3,
                    FlightId = 3,
                    VehicleTypeId = 5
                },
                new Order
                {
                    OrderId = 21,
                    StartOfService = new DateTime(2023, 05, 10, 14, 30, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 05, 00),
                    PositionId = 3,
                    FlightId = 3,
                    VehicleTypeId = 11
                },
                new Order
                {
                    OrderId = 22,
                    StartOfService = new DateTime(2023, 05, 10, 14, 38, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 05, 00),
                    PositionId = 3,
                    FlightId = 3,
                    VehicleTypeId = 11
                },
                new Order
                {
                    OrderId = 23,
                    StartOfService = new DateTime(2023, 05, 10, 14, 50, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 00, 00),
                    PositionId = 3,
                    FlightId = 3,
                    VehicleTypeId = 7
                },
                new Order
                {
                    OrderId = 24,
                    StartOfService = new DateTime(2023, 05, 10, 14, 32, 00),
                    EndOfService = new DateTime(2023, 05, 10, 14, 45, 00),
                    PositionId = 3,
                    FlightId = 3,
                    VehicleTypeId = 8
                },
                new Order
                {
                    OrderId = 25,
                    StartOfService = new DateTime(2023, 05, 10, 14, 35, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 05, 00),
                    PositionId = 3,
                    FlightId = 3,
                    VehicleTypeId = 3
                },
                new Order
                {
                    OrderId = 26,
                    StartOfService = new DateTime(2023, 05, 10, 14, 32, 00),
                    EndOfService = new DateTime(2023, 05, 10, 14, 45, 00),
                    fuelType = "JetA1",
                    QtyFuel = 15000,
                    PositionId = 3,
                    FlightId = 3,
                    VehicleTypeId = 9
                },
                new Order
                {
                    OrderId = 27,
                    StartOfService = new DateTime(2023, 05, 10, 15, 00, 00),
                    EndOfService = new DateTime(2023, 05, 10, 15, 10, 00),
                    PositionId = 3,
                    FlightId = 3,
                    VehicleTypeId = 9
                },
                new Order
                {
                    OrderId = 9999,
                    StartOfService = new DateTime(2000, 01, 01, 00, 00, 00),
                    EndOfService = new DateTime(2000, 01, 01, 00, 01, 00),
                    PositionId = 1,
                    FlightId = 5,
                    VehicleTypeId = 1
                }
            );

            modelBuilder.Entity<AircraftTurnarroundPreset>().HasData(
                new AircraftTurnarroundPreset
                {
                    TemplateId = 1,
                    Name = "A3x / 37x, PAX < 100 @Gate",
                    utilizeGangways = true,
                    hasUnitLoadOption = false,
                    DescriptionNotes = "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is used for turnarounds that utilize gangways for boarding LESS than 100 passengers.",
                },
                new AircraftTurnarroundPreset
                {
                    TemplateId = 2,
                    Name = "A3x / 37x, PAX > 100 @Gate",
                    utilizeGangways = true,
                    hasUnitLoadOption = false,
                    DescriptionNotes = "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is used for turnarounds that utilize gangways for boarding MORE than 100 passengers.",
                },
                new AircraftTurnarroundPreset
                {
                    TemplateId = 3,
                    Name = "A3x / 37x, PAX > 100 NOT @Gate",
                    utilizeGangways = false,
                    hasUnitLoadOption = false,
                    DescriptionNotes = "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is NOT used for turnarounds that utilize gangways for boarding MORE than 100 passengers.",
                },
                new AircraftTurnarroundPreset
                {
                    TemplateId = 4,
                    Name = "ATR-42/-72/-82/-92 NOT @Gate",
                    utilizeGangways = false,
                    hasUnitLoadOption = false,
                    DescriptionNotes = "Aircraft turnarrund preset for all Aircrafts of the ATR Manufacturer. This preset is NOT used for turnarounds that utilize gangways for boarding.",
                },
                new AircraftTurnarroundPreset
                {
                    TemplateId = 5,
                    Name = "Dash-Q8",
                    utilizeGangways = false,
                    hasUnitLoadOption = false,
                    DescriptionNotes = "Aircraft turnarrund preset for all Aircrafts De Havilland Dash-Q8 without unit load system. This preset is not used for turnarounds that utilize gangways for boarding.",
                },
                new AircraftTurnarroundPreset
                {
                    TemplateId = 100,
                    Name = "A3x / 37x, PAX < 100 @Gate",
                    utilizeGangways = true,
                    hasUnitLoadOption = true,
                    DescriptionNotes = "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is used for turnarounds that utilize gangways for boarding LESS than 100 passengers.",
                },
                new AircraftTurnarroundPreset
                {
                    TemplateId = 101,
                    Name = "A3x / 37x, PAX > 100 @Gate",
                    utilizeGangways = true,
                    hasUnitLoadOption = true,
                    DescriptionNotes = "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is used for turnarounds that utilize gangways for boarding MORE than 100 passengers.",
                },
                new AircraftTurnarroundPreset
                {
                    TemplateId = 102,
                    Name = "A3x / 37x, PAX > 100 NOT @Gate",
                    utilizeGangways = false,
                    hasUnitLoadOption = true,
                    DescriptionNotes = "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is NOT used for turnarounds that utilize gangways for boarding MORE than 100 passengers.",
                }
            );

            modelBuilder.Entity<TurnarroundVehicleTimeOffset>().HasData(
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 1,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 5, //Belt
                    AircraftTurnarroundTemplateId = 1 //Small
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 2,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 11, //luggage truck
                    AircraftTurnarroundTemplateId = 1 //Small
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 3,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 25,
                    VehicleTypeId = 3, //air stairs for service
                    AircraftTurnarroundTemplateId = 1 //Small
                },

                // Preset 2
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 4,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 5, //Belt
                    AircraftTurnarroundTemplateId = 2 //Big@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 5,
                    TimeOffsetStart = 10,
                    TimeOffsetEnd = 30,
                    VehicleTypeId = 5, //Belt
                    AircraftTurnarroundTemplateId = 2 //Big@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 6,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 11, //luggage truck
                    AircraftTurnarroundTemplateId = 2 //Big@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 7,
                    TimeOffsetStart = 5,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 11, //luggage truck
                    AircraftTurnarroundTemplateId = 2 //Big@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 8,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 3, //air stairs for service
                    AircraftTurnarroundTemplateId = 2 //Big@Gate
                },

                //Preset 3
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 9,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 5, //Belt
                    AircraftTurnarroundTemplateId = 3 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 10,
                    TimeOffsetStart = 10,
                    TimeOffsetEnd = 30,
                    VehicleTypeId = 5, //Belt
                    AircraftTurnarroundTemplateId = 3 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 11,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 11, //luggage truck
                    AircraftTurnarroundTemplateId = 3 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 12,
                    TimeOffsetStart = 5,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 11, //luggage truck
                    AircraftTurnarroundTemplateId = 3 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 13,
                    TimeOffsetStart = 5,
                    TimeOffsetEnd = 30,
                    VehicleTypeId = 4, //Apron Bus
                    AircraftTurnarroundTemplateId = 3 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 14,
                    TimeOffsetStart = 15,
                    TimeOffsetEnd = 45,
                    VehicleTypeId = 4, //Apron Bus
                    AircraftTurnarroundTemplateId = 3 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 15,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 30,
                    VehicleTypeId = 3, //air stairs for service
                    AircraftTurnarroundTemplateId = 3 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 16,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 3, //air stairs for service
                    AircraftTurnarroundTemplateId = 3 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 17,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 50,
                    VehicleTypeId = 10, //GPU
                    AircraftTurnarroundTemplateId = 3 //Big!@Gate
                },

                //Preset 4
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 18,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 11, //luggage truck
                    AircraftTurnarroundTemplateId = 5 //Small!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 19,
                    TimeOffsetStart = 5,
                    TimeOffsetEnd = 20,
                    VehicleTypeId = 4, //Apron Bus
                    AircraftTurnarroundTemplateId = 5 //Small!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 20,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 10, //GPU
                    AircraftTurnarroundTemplateId = 5 //Small!@Gate
                },

                //Preset 100 w UL
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 21,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 6, //High loader
                    AircraftTurnarroundTemplateId = 100 //Small
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 22,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 11, //luggage truck
                    AircraftTurnarroundTemplateId = 100 //Small
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 23,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 25,
                    VehicleTypeId = 3, //air stairs for service
                    AircraftTurnarroundTemplateId = 100 //Small
                },

                //Preset 101 w UL
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 24,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 6, //High loader
                    AircraftTurnarroundTemplateId = 101 //Big@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 25,
                    TimeOffsetStart = 10,
                    TimeOffsetEnd = 20,
                    VehicleTypeId = 5, //Belt
                    AircraftTurnarroundTemplateId = 101 //Big@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 26,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 11, //containter truck
                    AircraftTurnarroundTemplateId = 101 //Big@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 27,
                    TimeOffsetStart = 5,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 11, //container truck
                    AircraftTurnarroundTemplateId = 101 //Big@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 28,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 3, //air stairs for service
                    AircraftTurnarroundTemplateId = 101 //Big@Gate
                },

                //Preset 102 w UL
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 29,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 6, //High loader
                    AircraftTurnarroundTemplateId = 102 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 30,
                    TimeOffsetStart = 10,
                    TimeOffsetEnd = 20,
                    VehicleTypeId = 5, //Belt
                    AircraftTurnarroundTemplateId = 102 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 31,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 35,
                    VehicleTypeId = 11, //container truck
                    AircraftTurnarroundTemplateId = 102 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 32,
                    TimeOffsetStart = 10,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 11, //container truck
                    AircraftTurnarroundTemplateId = 102 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 33,
                    TimeOffsetStart = 5,
                    TimeOffsetEnd = 30,
                    VehicleTypeId = 4, //Apron Bus
                    AircraftTurnarroundTemplateId = 102 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 34,
                    TimeOffsetStart = 15,
                    TimeOffsetEnd = 45,
                    VehicleTypeId = 4, //Apron Bus
                    AircraftTurnarroundTemplateId = 102 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 35,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 30,
                    VehicleTypeId = 3, //air stairs for service
                    AircraftTurnarroundTemplateId = 102 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 36,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 40,
                    VehicleTypeId = 3, //air stairs for service
                    AircraftTurnarroundTemplateId = 102 //Big!@Gate
                },
                new TurnarroundVehicleTimeOffset
                {
                    TvtoId = 37,
                    TimeOffsetStart = 0,
                    TimeOffsetEnd = 50,
                    VehicleTypeId = 10, //GPU
                    AircraftTurnarroundTemplateId = 102 //Big!@Gate
                }
            );
            modelBuilder.Entity<AircraftType_ATT>().HasData(
                new AircraftType_ATT
                {
                    AircraftTypeId = 2,
                    aircraftTurnarroundTemplateId = 1
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 4,
                    aircraftTurnarroundTemplateId = 1
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 1,
                    aircraftTurnarroundTemplateId = 100
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 3,
                    aircraftTurnarroundTemplateId = 100
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 2,
                    aircraftTurnarroundTemplateId = 2
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 4,
                    aircraftTurnarroundTemplateId = 2
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 1,
                    aircraftTurnarroundTemplateId = 101
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 3,
                    aircraftTurnarroundTemplateId = 101
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 5,
                    aircraftTurnarroundTemplateId = 2
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 5,
                    aircraftTurnarroundTemplateId = 3
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 2,
                    aircraftTurnarroundTemplateId = 3
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 4,
                    aircraftTurnarroundTemplateId = 3
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 1,
                    aircraftTurnarroundTemplateId = 102
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 3,
                    aircraftTurnarroundTemplateId = 102
                },
                new AircraftType_ATT
                {
                    AircraftTypeId = 6,
                    aircraftTurnarroundTemplateId = 4
                }
            );
            // modelBuilder.Entity<VehicleSchedule>().HasData(
            //     new VehicleSchedule {

            //     }
            // );
        }

        public static void configureDbRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AircraftType_ATT>()
                .HasKey(i => new { i.aircraftTurnarroundTemplateId, i.AircraftTypeId });
        }
    }
}