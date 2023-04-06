using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeletedDynamicRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftTurnarroundTemplateAircraftType");

            migrationBuilder.AddForeignKey(
                name: "FK_AircraftType_ATTs_AircraftTurnarroundTemplates_aircraftTurnarroundTemplateId",
                table: "AircraftType_ATTs",
                column: "aircraftTurnarroundTemplateId",
                principalTable: "AircraftTurnarroundTemplates",
                principalColumn: "TemplateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AircraftType_ATTs_AircraftTurnarroundTemplates_aircraftTurnarroundTemplateId",
                table: "AircraftType_ATTs");

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

            migrationBuilder.CreateIndex(
                name: "IX_AircraftTurnarroundTemplateAircraftType_AircraftTypesAircraftTypeId",
                table: "AircraftTurnarroundTemplateAircraftType",
                column: "AircraftTypesAircraftTypeId");
        }
    }
}
