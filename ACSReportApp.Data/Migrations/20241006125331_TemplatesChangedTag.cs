using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACSReportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class TemplatesChangedTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemplateTag",
                table: "Templates",
                newName: "TemplateName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemplateName",
                table: "Templates",
                newName: "TemplateTag");
        }
    }
}
