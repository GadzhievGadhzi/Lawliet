using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lawliet.Migrations
{
    /// <inheritdoc />
    public partial class EditedModels3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Users",
                type: "bytea",
                nullable: true);
        }
    }
}
