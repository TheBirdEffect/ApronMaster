using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDemoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 11,
                column: "Name",
                value: "Flugzeugtreppe mittel 1");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 12,
                column: "Name",
                value: "Flugzeugtreppe mittel 2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 11,
                column: "Name",
                value: "Flugzeugtreppe mittel");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 12,
                column: "Name",
                value: "Flugzeugtreppe mittel");
        }
    }
}
