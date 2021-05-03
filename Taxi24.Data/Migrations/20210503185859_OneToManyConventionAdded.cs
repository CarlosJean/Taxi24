using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi24.Data.Migrations
{
    public partial class OneToManyConventionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Trip_TripId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Fare_Trip_TripId",
                table: "Fare");

            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Trip_TripId",
                table: "Passenger");

            migrationBuilder.DropIndex(
                name: "IX_Passenger_TripId",
                table: "Passenger");

            migrationBuilder.DropIndex(
                name: "IX_Fare_TripId",
                table: "Fare");

            migrationBuilder.DropIndex(
                name: "IX_Driver_TripId",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Fare");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Driver");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_DriverId",
                table: "Trip",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_FareId",
                table: "Trip",
                column: "FareId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_PassengerId",
                table: "Trip",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Driver_DriverId",
                table: "Trip",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Fare_FareId",
                table: "Trip",
                column: "FareId",
                principalTable: "Fare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Passenger_PassengerId",
                table: "Trip",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Driver_DriverId",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Fare_FareId",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Passenger_PassengerId",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_DriverId",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_FareId",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_PassengerId",
                table: "Trip");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Passenger",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Fare",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Driver",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_TripId",
                table: "Passenger",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Fare_TripId",
                table: "Fare",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_TripId",
                table: "Driver",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Trip_TripId",
                table: "Driver",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fare_Trip_TripId",
                table: "Fare",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Trip_TripId",
                table: "Passenger",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
