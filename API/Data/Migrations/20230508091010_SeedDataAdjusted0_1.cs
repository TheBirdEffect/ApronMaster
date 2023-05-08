using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdjusted0_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 4,
                column: "Name",
                value: "Gepäckzug 1");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 5,
                column: "Name",
                value: "Gepäckzug 2");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 6,
                column: "Name",
                value: "Gepäckzug 3");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 7,
                column: "Name",
                value: "Gepäckzug 4");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 15,
                column: "Name",
                value: "Containerzug 1");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 16,
                column: "Name",
                value: "Containerzug 2");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 13,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 14, 20, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 11,
                column: "Name",
                value: "Luggage truck");

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "VehicleTypeId", "Name" },
                values: new object[] { 12, "Container Truck" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 4,
                column: "Name",
                value: "Gepäckzug á 4 Wägen");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 5,
                column: "Name",
                value: "Gepäckzug á 4 Wägen");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 6,
                column: "Name",
                value: "Gepäckzug á 4 Wägen");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 7,
                column: "Name",
                value: "Gepäckzug á 4 Wägen");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 15,
                column: "Name",
                value: "Containerzug á 4 Wägen");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 16,
                column: "Name",
                value: "Containerzug á 4 Wägen");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 13,
                columns: new[] { "EndOfService", "StartOfService" },
                values: new object[] { new DateTime(2023, 5, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 11,
                column: "Name",
                value: "Luggage/container truck");
        }
    }
}
