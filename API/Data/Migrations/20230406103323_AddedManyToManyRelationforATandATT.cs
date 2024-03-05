using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedManyToManyRelationforATandATT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftTurnarroundTemplates",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionNotes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTurnarroundTemplates", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "AircraftType_ATTs",
                columns: table => new
                {
                    aircraftTurnarroundTemplateId = table.Column<int>(type: "INTEGER", nullable: false),
                    AircraftTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftType_ATTs", x => new { x.aircraftTurnarroundTemplateId, x.AircraftTypeId });
                    table.ForeignKey(
                        name: "FK_AircraftType_ATTs_AircraftTypes_AircraftTypeId",
                        column: x => x.AircraftTypeId,
                        principalTable: "AircraftTypes",
                        principalColumn: "AircraftTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AircraftTurnarroundTemplateAircraftType",
                columns: table => new
                {
                    AircraftTurnarroundTemplatesTemplateId = table.Column<int>(type: "INTEGER", nullable: false),
                    AircraftTypesAircraftTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTurnarroundTemplateAircraftType", x => new { x.AircraftTurnarroundTemplatesTemplateId, x.AircraftTypesAircraftTypeId });
                    table.ForeignKey(
                        name: "FK_AircraftTurnarroundTemplateAircraftType_AircraftTurnarroundTemplates_AircraftTurnarroundTemplatesTemplateId",
                        column: x => x.AircraftTurnarroundTemplatesTemplateId,
                        principalTable: "AircraftTurnarroundTemplates",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AircraftTurnarroundTemplateAircraftType_AircraftTypes_AircraftTypesAircraftTypeId",
                        column: x => x.AircraftTypesAircraftTypeId,
                        principalTable: "AircraftTypes",
                        principalColumn: "AircraftTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurnarroundVehicleTimeOffsets",
                columns: table => new
                {
                    TvtoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeOffsetStart = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeOffsetEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    AircraftTurnarroundTemplateId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnarroundVehicleTimeOffsets", x => x.TvtoId);
                    table.ForeignKey(
                        name: "FK_TurnarroundVehicleTimeOffsets_AircraftTurnarroundTemplates_AircraftTurnarroundTemplateId",
                        column: x => x.AircraftTurnarroundTemplateId,
                        principalTable: "AircraftTurnarroundTemplates",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurnarroundVehicleTimeOffsets_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AircraftTurnarroundTemplateAircraftType_AircraftTypesAircraftTypeId",
                table: "AircraftTurnarroundTemplateAircraftType",
                column: "AircraftTypesAircraftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftType_ATTs_AircraftTypeId",
                table: "AircraftType_ATTs",
                column: "AircraftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnarroundVehicleTimeOffsets_AircraftTurnarroundTemplateId",
                table: "TurnarroundVehicleTimeOffsets",
                column: "AircraftTurnarroundTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnarroundVehicleTimeOffsets_VehicleTypeId",
                table: "TurnarroundVehicleTimeOffsets",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftTurnarroundTemplateAircraftType");

            migrationBuilder.DropTable(
                name: "AircraftType_ATTs");

            migrationBuilder.DropTable(
                name: "TurnarroundVehicleTimeOffsets");

            migrationBuilder.DropTable(
                name: "AircraftTurnarroundTemplates");
        }
    }
}
