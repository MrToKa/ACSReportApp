using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACSReportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TemplateTag = table.Column<string>(type: "text", nullable: false),
                    TemplateType = table.Column<string>(type: "text", nullable: false),
                    TemplateDescription = table.Column<string>(type: "text", nullable: true),
                    TemplatePath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
