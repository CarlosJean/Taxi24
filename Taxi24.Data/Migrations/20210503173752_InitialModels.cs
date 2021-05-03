using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Taxi24.Data.Migrations
{
    public partial class InitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    PassengerId = table.Column<int>(type: "integer", nullable: false),
                    DemandDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cancelled = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    FareId = table.Column<int>(type: "integer", nullable: false),
                    OriginLatitude = table.Column<decimal>(type: "numeric", nullable: false),
                    OriginLongitude = table.Column<decimal>(type: "numeric", nullable: false),
                    DestinationLatitude = table.Column<decimal>(type: "numeric", nullable: false),
                    DestinationLongitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Names = table.Column<string>(type: "text", nullable: true),
                    Surnames = table.Column<string>(type: "text", nullable: true),
                    Available = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    TripId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Driver_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<string>(type: "text", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TripId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fare_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Names = table.Column<string>(type: "text", nullable: true),
                    Surnames = table.Column<string>(type: "text", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TripId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passenger_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_TripId",
                table: "Driver",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Fare_TripId",
                table: "Fare",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_TripId",
                table: "Passenger",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Fare");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "Trip");
        }
    }
}
