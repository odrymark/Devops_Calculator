using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCalculationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calculation",
                table: "Calculations");

            migrationBuilder.AddColumn<char>(
                name: "type",
                table: "Calculations",
                type: "character(1)",
                nullable: false,
                defaultValue: ' ');
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Calculations");

            migrationBuilder.AddColumn<string>(
                name: "calculation",
                table: "Calculations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
