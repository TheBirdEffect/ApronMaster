using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdjusted1_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 15,
                column: "VehicleTypeId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 16,
                column: "VehicleTypeId",
                value: 12);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 15,
                column: "VehicleTypeId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 16,
                column: "VehicleTypeId",
                value: 11);
        }
    }
}
