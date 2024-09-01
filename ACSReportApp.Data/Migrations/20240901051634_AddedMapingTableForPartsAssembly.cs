using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ACSReportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMapingTableForPartsAssembly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartAssemblies_PartAssemblyId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PartAssemblyId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "PartAssemblyId",
                table: "Parts");

            migrationBuilder.CreateTable(
                name: "PartAssemblyParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartId = table.Column<int>(type: "integer", nullable: false),
                    PartAssemblyId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartAssemblyParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartAssemblyParts_PartAssemblies_PartAssemblyId",
                        column: x => x.PartAssemblyId,
                        principalTable: "PartAssemblies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartAssemblyParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartAssemblyParts_PartAssemblyId",
                table: "PartAssemblyParts",
                column: "PartAssemblyId");

            migrationBuilder.CreateIndex(
                name: "IX_PartAssemblyParts_PartId",
                table: "PartAssemblyParts",
                column: "PartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartAssemblyParts");

            migrationBuilder.AddColumn<int>(
                name: "PartAssemblyId",
                table: "Parts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartAssemblyId",
                table: "Parts",
                column: "PartAssemblyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartAssemblies_PartAssemblyId",
                table: "Parts",
                column: "PartAssemblyId",
                principalTable: "PartAssemblies",
                principalColumn: "Id");
        }
    }
}
