using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedFirstPresetTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AircraftTurnarroundTemplates",
                columns: new[] { "TemplateId", "DescriptionNotes", "Name" },
                values: new object[] { 1, "Aircraft turnarrund preset for all Aircrafts of the Airbus A3x series and all Boeing 73x Series without unit load system. This preset is used for turnarounds which use gangways for the boarding.", "A3x / 37x Small" });

            migrationBuilder.InsertData(
                table: "AircraftType_ATTs",
                columns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "TurnarroundVehicleTimeOffsets",
                columns: new[] { "TvtoId", "AircraftTurnarroundTemplateId", "TimeOffsetEnd", "TimeOffsetStart", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, 1, 30, 0, 5 },
                    { 2, 1, 35, 0, 11 },
                    { 3, 1, 20, 5, 8 },
                    { 4, 1, 35, 20, 7 },
                    { 5, 1, 60, 40, 1 },
                    { 6, 1, 25, 0, 3 },
                    { 7, 1, 20, 5, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AircraftType_ATTs",
                keyColumns: new[] { "AircraftTypeId", "aircraftTurnarroundTemplateId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TurnarroundVehicleTimeOffsets",
                keyColumn: "TvtoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AircraftTurnarroundTemplates",
                keyColumn: "TemplateId",
                keyValue: 1);
        }
    }
}
