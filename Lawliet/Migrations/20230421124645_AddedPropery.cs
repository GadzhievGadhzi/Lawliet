using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lawliet.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlreadyExist",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlreadyExist",
                table: "Users");
        }
    }
}
