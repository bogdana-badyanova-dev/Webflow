using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webflow.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnDeadlineToCompleteDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deadline",
                table: "MoodleCourseElements",
                newName: "CompleteDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompleteDate",
                table: "MoodleCourseElements",
                newName: "Deadline");
        }
    }
}
