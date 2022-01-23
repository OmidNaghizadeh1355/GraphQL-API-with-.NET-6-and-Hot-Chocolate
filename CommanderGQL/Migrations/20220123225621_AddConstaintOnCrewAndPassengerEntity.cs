using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderGQL.Migrations
{
    public partial class AddConstaintOnCrewAndPassengerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passengers_PeopleId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Crews_PeopleId",
                table: "Crews");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_PeopleId_StarShipFlightId",
                table: "Passengers",
                columns: new[] { "PeopleId", "StarShipFlightId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crews_PeopleId_StarShipFlightId",
                table: "Crews",
                columns: new[] { "PeopleId", "StarShipFlightId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passengers_PeopleId_StarShipFlightId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Crews_PeopleId_StarShipFlightId",
                table: "Crews");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_PeopleId",
                table: "Passengers",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_PeopleId",
                table: "Crews",
                column: "PeopleId");
        }
    }
}
