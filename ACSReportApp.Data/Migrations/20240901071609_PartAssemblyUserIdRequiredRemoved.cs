using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACSReportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class PartAssemblyUserIdRequiredRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartAssemblies_AspNetUsers_ApplicationUserId",
                table: "PartAssemblies");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PartAssemblies",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_PartAssemblies_AspNetUsers_ApplicationUserId",
                table: "PartAssemblies",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartAssemblies_AspNetUsers_ApplicationUserId",
                table: "PartAssemblies");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PartAssemblies",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartAssemblies_AspNetUsers_ApplicationUserId",
                table: "PartAssemblies",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
