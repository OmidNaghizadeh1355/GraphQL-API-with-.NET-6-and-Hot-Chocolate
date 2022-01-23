using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderGQL.Migrations
{
    public partial class AddPassengerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_passengers_StarShipFlights_StarShipFlightId",
                table: "passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_passengers",
                table: "passengers");

            migrationBuilder.RenameTable(
                name: "passengers",
                newName: "Passengers");

            migrationBuilder.RenameIndex(
                name: "IX_passengers_StarShipFlightId",
                table: "Passengers",
                newName: "IX_Passengers_StarShipFlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_StarShipFlights_StarShipFlightId",
                table: "Passengers",
                column: "StarShipFlightId",
                principalTable: "StarShipFlights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_StarShipFlights_StarShipFlightId",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "passengers");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_StarShipFlightId",
                table: "passengers",
                newName: "IX_passengers_StarShipFlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_passengers",
                table: "passengers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_passengers_StarShipFlights_StarShipFlightId",
                table: "passengers",
                column: "StarShipFlightId",
                principalTable: "StarShipFlights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
