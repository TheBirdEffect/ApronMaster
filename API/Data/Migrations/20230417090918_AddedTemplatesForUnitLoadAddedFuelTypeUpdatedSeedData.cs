using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTemplatesForUnitLoadAddedFuelTypeUpdatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.AddColumn<string>(
                name: "fuelType",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "hasUnitLoadOption",
                table: "AircraftTurnarroundTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 1,
                column: "hasUnitLoadOption",
                value: false);

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 2,
                column: "hasUnitLoadOption",
                value: false);

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 3,
                column: "hasUnitLoadOption",
                value: false);

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 4,
                column: "hasUnitLoadOption",
                value: false);

            migrationBuilder.UpdateData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 5,
                column: "hasUnitLoadOption",
                value: false);

            migrationBuilder.InsertData(
                table: "AircraftTurnarroundTemplates",
                columns: new[] { "TemplateId", "DescriptionNotes", "Name", "hasUnitLoadOption", "utilizeGangways" },
                values: new object[,]
                {
                    { 100, "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is used for turnarounds that utilize gangways for boarding LESS than 100 passengers.", "A3x / 37x, PAX < 100 @Gate", true, true },
                    { 101, "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is used for turnarounds that utilize gangways for boarding MORE than 100 passengers.", "A3x / 37x, PAX > 100 @Gate", true, true },
                    { 102, "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series. This preset is NOT used for turnarounds that utilize gangways for boarding MORE than 100 passengers.", "A3x / 37x, PAX > 100 NOT @Gate", true, false }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8,
                column: "fuelType",
                value: "JetA1");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 11,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 12,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 13,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 14,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 15,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 16,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 17,
                column: "fuelType",
                value: "JetA1");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 18,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 19,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 20,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 21,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 22,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 23,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 24,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 25,
                column: "fuelType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 26,
                column: "fuelType",
                value: "JetA1");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 27,
                column: "fuelType",
                value: null);

            migrationBuilder.InsertData(
                table: "AircraftType_ATTs",
                columns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                values: new object[,]
                {
                    { 1, 100 },
                    { 3, 100 },
                    { 1, 101 },
                    { 3, 101 },
                    { 1, 102 },
                    { 3, 102 }
                });

            migrationBuilder.InsertData(
                table: "TurnarroundVehicleTimeOffsets",
                columns: new[] { "TvtoId", "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[,]
                {
                    { 21, 100, 40, 0, 6 },
                    { 22, 100, 35, 0, 11 },
                    { 23, 100, 25, 0, 3 },
                    { 24, 101, 35, 0, 6 },
                    { 25, 101, 20, 10, 5 },
                    { 26, 101, 35, 0, 11 },
                    { 27, 101, 40, 5, 11 },
                    { 28, 101, 35, 0, 3 },
                    { 29, 102, 35, 0, 6 },
                    { 30, 102, 20, 10, 5 },
                    { 31, 102, 35, 0, 11 },
                    { 32, 102, 40, 10, 11 },
                    { 33, 102, 30, 5, 4 },
                    { 34, 102, 45, 15, 4 },
                    { 35, 102, 30, 0, 3 },
                    { 36, 102, 40, 0, 3 },
                    { 37, 102, 50, 0, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 1, 100 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 3, 100 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 1, 101 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 3, 101 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 1, 102 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 3, 102 });

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
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 102);

            migrationBuilder.DropColumn(
                name: "fuelType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "hasUnitLoadOption",
                table: "AircraftTurnarroundTemplates");

            migrationBuilder.InsertData(
                table: "AircraftType_ATTs",
                columns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 3, 3 }
                });
        }
    }
}
