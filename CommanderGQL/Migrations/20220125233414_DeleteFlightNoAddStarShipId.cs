using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderGQL.Migrations
{
    public partial class DeleteFlightNoAddStarShipId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightNo",
                table: "StarShipFlights");

            migrationBuilder.AddColumn<int>(
                name: "StarshipId",
                table: "StarShipFlights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarshipId",
                table: "StarShipFlights");

            migrationBuilder.AddColumn<string>(
                name: "FlightNo",
                table: "StarShipFlights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
