using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lawliet.Migrations
{
    /// <inheritdoc />
    public partial class EditedTopicModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Task",
                table: "LessonTopics",
                newName: "PictureUrl");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "LessonTopics",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LessonTopics",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "LessonTopics");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "LessonTopics");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "LessonTopics",
                newName: "Task");
        }
    }
}
