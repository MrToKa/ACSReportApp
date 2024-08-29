using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACSReportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImagesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageTag = table.Column<string>(type: "text", nullable: false),
                    ImageType = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    CableTrayId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_CableTrays_CableTrayId",
                        column: x => x.CableTrayId,
                        principalTable: "CableTrays",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_CableTrayId",
                table: "Images",
                column: "CableTrayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
