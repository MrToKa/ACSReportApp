using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ACSReportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompositeKeyFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PartAssemblyParts",
                table: "PartAssemblyParts");

            migrationBuilder.DropIndex(
                name: "IX_PartAssemblyParts_PartId",
                table: "PartAssemblyParts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PartAssemblyParts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartAssemblyParts",
                table: "PartAssemblyParts",
                columns: new[] { "PartId", "PartAssemblyId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PartAssemblyParts",
                table: "PartAssemblyParts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PartAssemblyParts",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartAssemblyParts",
                table: "PartAssemblyParts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PartAssemblyParts_PartId",
                table: "PartAssemblyParts",
                column: "PartId");
        }
    }
}
