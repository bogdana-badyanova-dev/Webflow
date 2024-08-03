using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webflow.Migrations
{
    /// <inheritdoc />
    public partial class AddMoodleCourseElements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoodleCourseElement_Courses_CourseId",
                table: "MoodleCourseElement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoodleCourseElement",
                table: "MoodleCourseElement");

            migrationBuilder.RenameTable(
                name: "MoodleCourseElement",
                newName: "MoodleCourseElements");

            migrationBuilder.RenameIndex(
                name: "IX_MoodleCourseElement_CourseId",
                table: "MoodleCourseElements",
                newName: "IX_MoodleCourseElements_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoodleCourseElements",
                table: "MoodleCourseElements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoodleCourseElements_Courses_CourseId",
                table: "MoodleCourseElements",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoodleCourseElements_Courses_CourseId",
                table: "MoodleCourseElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoodleCourseElements",
                table: "MoodleCourseElements");

            migrationBuilder.RenameTable(
                name: "MoodleCourseElements",
                newName: "MoodleCourseElement");

            migrationBuilder.RenameIndex(
                name: "IX_MoodleCourseElements_CourseId",
                table: "MoodleCourseElement",
                newName: "IX_MoodleCourseElement_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoodleCourseElement",
                table: "MoodleCourseElement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoodleCourseElement_Courses_CourseId",
                table: "MoodleCourseElement",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
