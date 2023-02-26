using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompletedEntities230213 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsGate = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "GroundVehicles",
                columns: table => new
                {
                    GroundVehicleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsIdling = table.Column<bool>(type: "INTEGER", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundVehicles", x => x.GroundVehicleId);
                    table.ForeignKey(
                        name: "FK_GroundVehicles_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroundVehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartOfService = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndOfService = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QtyFuel = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionId = table.Column<int>(type: "INTEGER", nullable: false),
                    FlightId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleSchedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroundVehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSchedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_VehicleSchedules_GroundVehicles_GroundVehicleId",
                        column: x => x.GroundVehicleId,
                        principalTable: "GroundVehicles",
                        principalColumn: "GroundVehicleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleSchedules_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroundVehicles_PositionId",
                table: "GroundVehicles",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroundVehicles_VehicleTypeId",
                table: "GroundVehicles",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FlightId",
                table: "Orders",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PositionId",
                table: "Orders",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleTypeId",
                table: "Orders",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSchedules_GroundVehicleId",
                table: "VehicleSchedules",
                column: "GroundVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSchedules_OrderId",
                table: "VehicleSchedules",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleSchedules");

            migrationBuilder.DropTable(
                name: "GroundVehicles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
