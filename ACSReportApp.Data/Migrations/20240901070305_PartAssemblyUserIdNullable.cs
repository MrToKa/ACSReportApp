using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACSReportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class PartAssemblyUserIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartAssemblies_CableTrays_CableTrayId",
                table: "PartAssemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_CableTrays_CableTrayId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_CableTrayId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_PartAssemblies_CableTrayId",
                table: "PartAssemblies");

            migrationBuilder.DropColumn(
                name: "CableTrayId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "CableTrayId",
                table: "PartAssemblies");

            migrationBuilder.CreateTable(
                name: "CableTrayPart",
                columns: table => new
                {
                    CableTraysId = table.Column<int>(type: "integer", nullable: false),
                    PartsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CableTrayPart", x => new { x.CableTraysId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_CableTrayPart_CableTrays_CableTraysId",
                        column: x => x.CableTraysId,
                        principalTable: "CableTrays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CableTrayPart_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CableTrayPartAssembly",
                columns: table => new
                {
                    CableTraysId = table.Column<int>(type: "integer", nullable: false),
                    PartAssembliesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CableTrayPartAssembly", x => new { x.CableTraysId, x.PartAssembliesId });
                    table.ForeignKey(
                        name: "FK_CableTrayPartAssembly_CableTrays_CableTraysId",
                        column: x => x.CableTraysId,
                        principalTable: "CableTrays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CableTrayPartAssembly_PartAssemblies_PartAssembliesId",
                        column: x => x.PartAssembliesId,
                        principalTable: "PartAssemblies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CableTrayPart_PartsId",
                table: "CableTrayPart",
                column: "PartsId");

            migrationBuilder.CreateIndex(
                name: "IX_CableTrayPartAssembly_PartAssembliesId",
                table: "CableTrayPartAssembly",
                column: "PartAssembliesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CableTrayPart");

            migrationBuilder.DropTable(
                name: "CableTrayPartAssembly");

            migrationBuilder.AddColumn<int>(
                name: "CableTrayId",
                table: "Parts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CableTrayId",
                table: "PartAssemblies",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CableTrayId",
                table: "Parts",
                column: "CableTrayId");

            migrationBuilder.CreateIndex(
                name: "IX_PartAssemblies_CableTrayId",
                table: "PartAssemblies",
                column: "CableTrayId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartAssemblies_CableTrays_CableTrayId",
                table: "PartAssemblies",
                column: "CableTrayId",
                principalTable: "CableTrays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_CableTrays_CableTrayId",
                table: "Parts",
                column: "CableTrayId",
                principalTable: "CableTrays",
                principalColumn: "Id");
        }
    }
}
