using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefreshedDemoDataV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 1,
                column: "DescriptionNotes",
                value: "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is used for turnarounds that utilize gangways for boarding LESS than 100 passengers.");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 2,
                column: "DescriptionNotes",
                value: "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is used for turnarounds that utilize gangways for boarding MORE than 100 passengers.");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 3,
                column: "DescriptionNotes",
                value: "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is NOT used for turnarounds that utilize gangways for boarding MORE than 100 passengers.");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 4,
                column: "DescriptionNotes",
                value: "Aircraft turnarrund preset for all Aircrafts of the ATR Manufacturer. This preset is NOT used for turnarounds that utilize gangways for boarding.");

            migrationBuilder.InsertData(
                table: "AircraftType_ATTs",
                columns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                values: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 1,
                columns: new[] { "Arrival", "Departure" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 50, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 2,
                columns: new[] { "Arrival", "Departure" },
                values: new object[] { new DateTime(2023, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 15, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 3,
                columns: new[] { "Arrival", "Departure" },
                values: new object[] { new DateTime(2023, 4, 18, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 15, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 4,
                columns: new[] { "Arrival", "Departure" },
                values: new object[] { new DateTime(2023, 4, 19, 5, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 19, 6, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 10, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 20, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 3, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 12, 42, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 11,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 12,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 13,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 14,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 14, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 25, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 15,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 12, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 16,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 17,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 14, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 18,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 19,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 20,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 40, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 21,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 22,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 38, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 23,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 50, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 24,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 32, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 25,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 14, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 35, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 26,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 14, 32, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 27,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 18, 15, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 18, 15, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 1,
                column: "DescriptionNotes",
                value: "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series without unit load system. This preset is used for turnarounds that utilize gangways for boarding less than 100 passengers.");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 2,
                column: "DescriptionNotes",
                value: "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series without unit load system. This preset is used for turnarounds that utilize gangways for boarding more than 100 passengers.");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 3,
                column: "DescriptionNotes",
                value: "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series without unit load system. This preset is not used for turnarounds that utilize gangways for boarding more than 100 passengers.");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 4,
                column: "DescriptionNotes",
                value: "Aircraft turnarrund preset for all Aircrafts of the ATR Manufacturer. This preset is not used for turnarounds that utilize gangways for boarding.");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 1,
                columns: new[] { "Arrival", "Departure" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 50, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 2,
                columns: new[] { "Arrival", "Departure" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 15, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 3,
                columns: new[] { "Arrival", "Departure" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 15, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 4,
                columns: new[] { "Arrival", "Departure" },
                values: new object[] { new DateTime(2023, 4, 15, 5, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 15, 6, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 10, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 20, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 3, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 12, 42, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 11,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 12,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 13,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 14,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 25, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 15,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 12, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 16,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 17,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 18,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 19,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 20,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 40, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 21,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 22,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 38, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 23,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 50, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 24,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 32, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 25,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 35, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 26,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 14, 32, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 27,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
