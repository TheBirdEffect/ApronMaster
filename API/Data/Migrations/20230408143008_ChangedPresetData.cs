using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPresetData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "doService",
                table: "AircraftTurnarroundTemplates");

            migrationBuilder.DropColumn(
                name: "doUnitLoad",
                table: "AircraftTurnarroundTemplates");

            migrationBuilder.DropColumn(
                name: "pushbackNeeded",
                table: "AircraftTurnarroundTemplates");

            migrationBuilder.DropColumn(
                name: "refuelingNeeded",
                table: "AircraftTurnarroundTemplates");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 1,
                column: "Name",
                value: "A3x / 37x, PAX < 100 @Gate");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 2,
                column: "Name",
                value: "A3x / 37x, PAX > 100 @Gate");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 3,
                column: "Name",
                value: "A3x / 37x, PAX > 100 NOT @Gate");

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 4,
                columns: new[] { "DescriptionNotes", "Name" },
                values: new object[] { "Aircraft turnarrund preset for all Aircrafts of the ATR Manufacturer. This preset is not used for turnarounds that utilize gangways for boarding.", "ATR-42/-72/-82/-92 NOT @Gate" });

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 5,
                columns: new[] { "DescriptionNotes", "Name" },
                values: new object[] { "Aircraft turnarrund preset for all Aircrafts De Havilland Dash-Q8 without unit load system. This preset is not used for turnarounds that utilize gangways for boarding.", "Dash-Q8" });

            migrationBuilder.InsertData(
                table: "AircraftType_ATTs",
                columns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 5, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 6, 4 }
                });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 1,
                column: "TimeOffsetEnd",
                value: 40);

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 3,
                columns: new[] { "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 25, 0, 3 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 4,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 2, 0, 5 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 5,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 2, 30, 10, 5 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 6,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "VehicleTypeId" },
                values: new object[] { 2, 35, 11 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 7,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "VehicleTypeId" },
                values: new object[] { 2, 40, 11 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 8,
                column: "VehicleTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 9,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart" },
                values: new object[] { 3, 35, 0 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 10,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 3, 30, 10, 5 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 11,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetStart" },
                values: new object[] { 3, 0 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 12,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "VehicleTypeId" },
                values: new object[] { 3, 40, 11 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 13,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 3, 30, 5, 4 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 14,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 3, 45, 15, 4 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 15,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd" },
                values: new object[] { 3, 30 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 16,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 3, 40, 0, 3 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 17,
                columns: new[] { "TimeOffsetEnd", "VehicleTypeId" },
                values: new object[] { 50, 10 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 18,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 5, 40, 0, 11 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 19,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 5, 20, 5, 4 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 20,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 5, 40, 0, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.AddColumn<bool>(
                name: "doService",
                table: "AircraftTurnarroundTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "doUnitLoad",
                table: "AircraftTurnarroundTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "pushbackNeeded",
                table: "AircraftTurnarroundTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "refuelingNeeded",
                table: "AircraftTurnarroundTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 1,
                columns: new[] { "Name", "doService", "doUnitLoad", "pushbackNeeded", "refuelingNeeded" },
                values: new object[] { "A3x / 37x, PAX < 100", true, false, true, true });

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 2,
                columns: new[] { "Name", "doService", "doUnitLoad", "pushbackNeeded", "refuelingNeeded" },
                values: new object[] { "A3x / 37x, PAX > 100", true, false, true, true });

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 3,
                columns: new[] { "Name", "doService", "doUnitLoad", "pushbackNeeded", "refuelingNeeded" },
                values: new object[] { "A3x / 37x, PAX > 100", true, false, true, true });

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 4,
                columns: new[] { "DescriptionNotes", "Name", "doService", "doUnitLoad", "pushbackNeeded", "refuelingNeeded" },
                values: new object[] { "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series with unit load system. This preset is not used for turnarounds that utilize gangways for boarding more than 100 passengers.", "A3x / 37x, PAX > 100, unit loaded", true, true, true, true });

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 5,
                columns: new[] { "DescriptionNotes", "Name", "doService", "doUnitLoad", "pushbackNeeded", "refuelingNeeded" },
                values: new object[] { "Aircraft turnarrund preset for all Aircrafts of the ATR Manufacturer. This preset is not used for turnarounds that utilize gangways for boarding.", "ATR-42/-72/-82/-92", true, false, true, true });

            migrationBuilder.InsertData(
                table: "AircraftTurnarroundTemplates",
                columns: new[] { "TemplateId", "DescriptionNotes", "Name", "doService", "doUnitLoad", "pushbackNeeded", "refuelingNeeded", "utilizeGangways" },
                values: new object[,]
                {
                    { 6, "Aircraft turnarrund preset for all Aircrafts De Havilland Dash-Q8 without unit load system. This preset is not used for turnarounds that utilize gangways for boarding.", "Dash-Q8", true, false, true, true, false },
                    { 7, "Aircraft turnarrund preset for all Aircrafts De Havilland Dash-Q8 without unit load system. This preset is not used for turnarounds that utilize gangways for boarding.", "ATR-42/-72/-82/-92", true, false, false, false, false }
                });

            migrationBuilder.InsertData(
                table: "AircraftType_ATTs",
                columns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 3, 4 },
                    { 5, 4 },
                    { 6, 5 }
                });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 1,
                column: "TimeOffsetEnd",
                value: 30);

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 3,
                columns: new[] { "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 20, 5, 8 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 4,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 1, 20, 7 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 5,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 1, 60, 40, 1 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 6,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "VehicleTypeId" },
                values: new object[] { 1, 25, 3 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 7,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "VehicleTypeId" },
                values: new object[] { 1, 20, 9 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 8,
                column: "VehicleTypeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 9,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart" },
                values: new object[] { 2, 25, 10 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 10,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 2, 35, 0, 11 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 11,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetStart" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 12,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "VehicleTypeId" },
                values: new object[] { 2, 20, 8 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 13,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 2, 35, 20, 7 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 14,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 2, 60, 45, 1 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 15,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd" },
                values: new object[] { 2, 35 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 16,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 2, 20, 5, 9 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 17,
                columns: new[] { "TimeOffsetEnd", "VehicleTypeId" },
                values: new object[] { 35, 5 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 18,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 3, 25, 10, 5 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 19,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 3, 35, 0, 11 });

            migrationBuilder.UpdateData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 20,
                columns: new[] { "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[] { 3, 35, 5, 11 });

            migrationBuilder.InsertData(
                table: "TurnarroundVehicleTimeOffsets",
                columns: new[] { "TvtoId", "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[,]
                {
                    { 21, 3, 20, 5, 8 },
                    { 22, 3, 35, 20, 7 },
                    { 23, 3, 60, 45, 1 },
                    { 24, 3, 35, 0, 3 },
                    { 25, 3, 40, 0, 3 },
                    { 26, 3, 20, 5, 9 },
                    { 27, 3, 40, 0, 10 },
                    { 28, 4, 35, 0, 6 },
                    { 29, 4, 25, 10, 6 },
                    { 30, 4, 35, 0, 11 },
                    { 31, 4, 35, 5, 11 },
                    { 32, 4, 20, 5, 8 },
                    { 33, 4, 35, 20, 7 },
                    { 34, 4, 60, 45, 1 },
                    { 35, 4, 35, 0, 3 },
                    { 36, 4, 40, 0, 3 },
                    { 37, 4, 20, 5, 9 },
                    { 38, 4, 40, 0, 10 },
                    { 39, 5, 35, 0, 11 },
                    { 40, 5, 20, 5, 8 },
                    { 41, 5, 35, 20, 7 },
                    { 42, 5, 60, 45, 1 },
                    { 43, 5, 40, 0, 10 },
                    { 44, 5, 20, 5, 9 }
                });

            migrationBuilder.InsertData(
                table: "AircraftType_ATTs",
                columns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                values: new object[] { 6, 7 });

            migrationBuilder.InsertData(
                table: "TurnarroundVehicleTimeOffsets",
                columns: new[] { "TvtoId", "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[,]
                {
                    { 45, 6, 40, 0, 5 },
                    { 46, 6, 40, 0, 11 },
                    { 47, 6, 20, 5, 8 },
                    { 48, 6, 35, 20, 7 },
                    { 49, 6, 60, 45, 1 },
                    { 50, 6, 20, 5, 9 },
                    { 51, 6, 40, 0, 10 },
                    { 52, 6, 40, 0, 5 },
                    { 53, 6, 40, 0, 11 },
                    { 54, 6, 20, 5, 8 },
                    { 55, 6, 35, 20, 7 },
                    { 56, 6, 40, 0, 10 }
                });
        }
    }
}
