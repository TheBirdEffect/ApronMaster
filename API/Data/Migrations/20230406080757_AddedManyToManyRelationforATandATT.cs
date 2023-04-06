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
            migrationBuilder.DropForeignKey(
                name: "FK_AircraftTurnarroundTemplates_AircraftTypes_AircraftTypeId",
                table: "AircraftTurnarroundTemplates");

            migrationBuilder.DropIndex(
                name: "IX_AircraftTurnarroundTemplates_AircraftTypeId",
                table: "AircraftTurnarroundTemplates");

            migrationBuilder.DropColumn(
                name: "AircraftTypeId",
                table: "AircraftTurnarroundTemplates");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftTurnarroundTemplateAircraftType");

            migrationBuilder.AddColumn<int>(
                name: "AircraftTypeId",
                table: "AircraftTurnarroundTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AircraftTurnarroundTemplates_AircraftTypeId",
                table: "AircraftTurnarroundTemplates",
                column: "AircraftTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AircraftTurnarroundTemplates_AircraftTypes_AircraftTypeId",
                table: "AircraftTurnarroundTemplates",
                column: "AircraftTypeId",
                principalTable: "AircraftTypes",
                principalColumn: "AircraftTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
