using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webflow.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFileModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Skill",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "Files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "Files",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "Files");
        }
    }
}
