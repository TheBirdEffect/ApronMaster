using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeds230213 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AircraftTypes",
                columns: new[] { "AircraftTypeId", "Name", "hasUnitLoadOption" },
                values: new object[,]
                {
                    { 1, "Boeing737", true },
                    { 2, "Boeing737", false },
                    { 3, "AirbusA320", true },
                    { 4, "AirbusA320", false },
                    { 5, "AirbusA330", true },
                    { 6, "ATR-72", false }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "IsGate", "Name" },
                values: new object[,]
                {
                    { 1, false, "62" },
                    { 2, true, "61" },
                    { 3, true, "51" },
                    { 4, false, "41" },
                    { 5, false, "42" },
                    { 6, false, "43" },
                    { 7, false, "44" },
                    { 8, false, "31" },
                    { 9, false, "32" },
                    { 10, false, "33" },
                    { 11, false, "21" },
                    { 12, false, "22" },
                    { 13, false, "23" },
                    { 14, false, "24" },
                    { 15, false, "Ground Vehicle Parking" },
                    { 16, false, "Ground Vehicle Maintainance" },
                    { 17, false, "Maschinenhalle Ost" },
                    { 18, false, "Tanklager West" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "VehicleTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Pushback tug" },
                    { 2, "Catering truck" },
                    { 3, "Airstairs" },
                    { 4, "Apron bus" },
                    { 5, "Belt loader" },
                    { 6, "Container loader" },
                    { 7, "Water truck" },
                    { 8, "Lavatory-service vehicle" },
                    { 9, "Refueling truck" },
                    { 10, "Ground power unit" },
                    { 11, "Luggage/container truck" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "AircraftTypeId", "Arrival", "Departure", "Destination", "FlightNo" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 2, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 14, 12, 50, 0, 0, DateTimeKind.Unspecified), "EDDH", "EZY2023" },
                    { 2, 5, new DateTime(2023, 2, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 14, 15, 15, 0, 0, DateTimeKind.Unspecified), "EDDM", "LH2134" },
                    { 3, 2, new DateTime(2023, 2, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 14, 15, 15, 0, 0, DateTimeKind.Unspecified), "EDDB", "LH789" }
                });

            migrationBuilder.InsertData(
                table: "GroundVehicles",
                columns: new[] { "GroundVehicleId", "IsIdling", "Name", "PositionId", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, true, "Gepäckband1", 15, 5 },
                    { 2, true, "Gepäckband2", 15, 5 },
                    { 3, true, "Gepäckband3", 15, 5 },
                    { 4, true, "Gepäckzug á 4 Wägen", 15, 11 },
                    { 5, true, "Gepäckzug á 4 Wägen", 15, 11 },
                    { 6, true, "Gepäckzug á 4 Wägen", 15, 11 },
                    { 7, true, "Gepäckzug á 4 Wägen", 15, 11 },
                    { 8, true, "Puck-Back Fahrzeug klein", 17, 1 },
                    { 9, true, "Puck-Back Fahrzeug groß", 17, 1 },
                    { 10, true, "Flugzeugtreppe klein", 17, 3 },
                    { 11, true, "Flugzeugtreppe mittel", 17, 3 },
                    { 12, true, "Flugzeugtreppe mittel", 17, 3 },
                    { 13, true, "Flugzeugtreppe groß", 17, 3 },
                    { 14, true, "Bus 1", 17, 4 },
                    { 15, true, "Containerzug á 4 Wägen", 17, 11 },
                    { 16, true, "Containerzug á 4 Wägen", 17, 11 },
                    { 17, true, "Frischwasserfahrzeug", 17, 7 },
                    { 18, true, "Entsorgungsfahrzeug", 17, 8 },
                    { 19, true, "Tank LKW1 JETA1 ", 18, 9 },
                    { 20, true, "Tank LKW2 JETA1", 18, 9 },
                    { 21, true, "Tank LKW3 Avgas", 18, 9 },
                    { 22, true, "GPU 1", 17, 10 },
                    { 23, true, "GPU 2", 17, 10 },
                    { 24, true, "GPU 2", 17, 10 },
                    { 25, true, "High-Loader", 17, 6 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EndOfService", "FlightId", "PositionId", "QtyFuel", "StartOfService", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 3, 0, new DateTime(2023, 2, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, new DateTime(2023, 2, 14, 12, 35, 0, 0, DateTimeKind.Unspecified), 1, 3, 0, new DateTime(2023, 2, 14, 12, 10, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 3, new DateTime(2023, 2, 14, 12, 35, 0, 0, DateTimeKind.Unspecified), 1, 3, 0, new DateTime(2023, 2, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 4, new DateTime(2023, 2, 14, 12, 35, 0, 0, DateTimeKind.Unspecified), 1, 3, 0, new DateTime(2023, 2, 14, 12, 5, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 5, new DateTime(2023, 2, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 3, 0, new DateTime(2023, 2, 14, 12, 20, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 6, new DateTime(2023, 2, 14, 12, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 0, new DateTime(2023, 2, 14, 12, 5, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 7, new DateTime(2023, 2, 14, 12, 35, 0, 0, DateTimeKind.Unspecified), 1, 3, 0, new DateTime(2023, 2, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2023, 2, 14, 12, 18, 0, 0, DateTimeKind.Unspecified), 1, 3, 12000, new DateTime(2023, 2, 14, 12, 3, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 9, new DateTime(2023, 2, 14, 12, 50, 0, 0, DateTimeKind.Unspecified), 1, 3, 0, new DateTime(2023, 2, 14, 12, 42, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2023, 2, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 11, 0, new DateTime(2023, 2, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 11, new DateTime(2023, 2, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), 2, 11, 0, new DateTime(2023, 2, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2023, 2, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, 11, 0, new DateTime(2023, 2, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 13, new DateTime(2023, 2, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 11, 0, new DateTime(2023, 2, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 14, new DateTime(2023, 2, 14, 14, 40, 0, 0, DateTimeKind.Unspecified), 2, 11, 0, new DateTime(2023, 2, 14, 14, 25, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 15, new DateTime(2023, 2, 14, 12, 25, 0, 0, DateTimeKind.Unspecified), 2, 11, 0, new DateTime(2023, 2, 14, 14, 5, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 16, new DateTime(2023, 2, 14, 14, 45, 0, 0, DateTimeKind.Unspecified), 2, 11, 0, new DateTime(2023, 2, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2023, 2, 14, 14, 20, 0, 0, DateTimeKind.Unspecified), 2, 11, 30000, new DateTime(2023, 2, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 18, new DateTime(2023, 2, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), 2, 11, 0, new DateTime(2023, 2, 14, 14, 5, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 19, new DateTime(2023, 2, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, new DateTime(2023, 2, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 20, new DateTime(2023, 2, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, new DateTime(2023, 2, 14, 14, 40, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 21, new DateTime(2023, 2, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, new DateTime(2023, 2, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 22, new DateTime(2023, 2, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, new DateTime(2023, 2, 14, 14, 38, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 23, new DateTime(2023, 2, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, new DateTime(2023, 2, 14, 14, 50, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 24, new DateTime(2023, 2, 14, 14, 45, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, new DateTime(2023, 2, 14, 14, 32, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 25, new DateTime(2023, 2, 14, 14, 5, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, new DateTime(2023, 2, 14, 14, 35, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 26, new DateTime(2023, 2, 14, 14, 45, 0, 0, DateTimeKind.Unspecified), 3, 3, 15000, new DateTime(2023, 2, 14, 14, 32, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 27, new DateTime(2023, 2, 14, 15, 10, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, new DateTime(2023, 2, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AircraftTypes",
                keyColumn: "AircraftTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AircraftTypes",
                keyColumn: "AircraftTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AircraftTypes",
                keyColumn: "AircraftTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AircraftTypes",
                keyColumn: "AircraftTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AircraftTypes",
                keyColumn: "AircraftTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AircraftTypes",
                keyColumn: "AircraftTypeId",
                keyValue: 5);
        }
    }
}
