using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi24.Data.Migrations
{
    public partial class CoordinatesAddedToDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Driver",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Driver",
                type: "numeric",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Driver");
        }
    }
}
