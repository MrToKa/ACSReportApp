using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACSReportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageDescAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageDescription",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDescription",
                table: "Images");
        }
    }
}
