using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSecondApronBus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 15,
                columns: new[] { "Name", "VehicleTypeId" },
                values: new object[] { "Bus 2", 4 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 16,
                column: "Name",
                value: "Containerzug 1");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 17,
                columns: new[] { "Name", "VehicleTypeId" },
                values: new object[] { "Containerzug 2", 12 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 18,
                columns: new[] { "Name", "VehicleTypeId" },
                values: new object[] { "Frischwasserfahrzeug", 7 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 19,
                columns: new[] { "Name", "PositionId", "VehicleTypeId" },
                values: new object[] { "Entsorgungsfahrzeug", 17, 8 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 20,
                column: "Name",
                value: "Tank LKW1 JETA1 ");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 21,
                column: "Name",
                value: "Tank LKW2 JETA1");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 22,
                columns: new[] { "Name", "PositionId", "VehicleTypeId" },
                values: new object[] { "Tank LKW3 Avgas", 18, 9 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 23,
                column: "Name",
                value: "GPU 1");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 25,
                columns: new[] { "Name", "VehicleTypeId" },
                values: new object[] { "GPU 2", 10 });

            migrationBuilder.InsertData(
                table: "GroundVehicles",
                columns: new[] { "GroundVehicleId", "IsIdling", "Name", "PositionId", "VehicleTypeId" },
                values: new object[] { 26, true, "High-Loader", 17, 6 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 26);

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 15,
                columns: new[] { "Name", "VehicleTypeId" },
                values: new object[] { "Containerzug 1", 12 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 16,
                column: "Name",
                value: "Containerzug 2");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 17,
                columns: new[] { "Name", "VehicleTypeId" },
                values: new object[] { "Frischwasserfahrzeug", 7 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 18,
                columns: new[] { "Name", "VehicleTypeId" },
                values: new object[] { "Entsorgungsfahrzeug", 8 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 19,
                columns: new[] { "Name", "PositionId", "VehicleTypeId" },
                values: new object[] { "Tank LKW1 JETA1 ", 18, 9 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 20,
                column: "Name",
                value: "Tank LKW2 JETA1");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 21,
                column: "Name",
                value: "Tank LKW3 Avgas");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 22,
                columns: new[] { "Name", "PositionId", "VehicleTypeId" },
                values: new object[] { "GPU 1", 17, 10 });

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 23,
                column: "Name",
                value: "GPU 2");

            migrationBuilder.UpdateData(
                table: "GroundVehicles",
                keyColumn: "GroundVehicleId",
                keyValue: 25,
                columns: new[] { "Name", "VehicleTypeId" },
                values: new object[] { "High-Loader", 6 });
        }
    }
}
