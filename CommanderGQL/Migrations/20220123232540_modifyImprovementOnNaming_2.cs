using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderGQL.Migrations
{
    public partial class modifyImprovementOnNaming_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Person_PeopleId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Person_PeopleId",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "PeopleId",
                table: "Passengers",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_PeopleId_StarShipFlightId",
                table: "Passengers",
                newName: "IX_Passengers_PersonId_StarShipFlightId");

            migrationBuilder.RenameColumn(
                name: "PeopleId",
                table: "Crews",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Crews_PeopleId_StarShipFlightId",
                table: "Crews",
                newName: "IX_Crews_PersonId_StarShipFlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Person_PersonId",
                table: "Crews",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Person_PersonId",
                table: "Passengers",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Person_PersonId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Person_PersonId",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Passengers",
                newName: "PeopleId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_PersonId_StarShipFlightId",
                table: "Passengers",
                newName: "IX_Passengers_PeopleId_StarShipFlightId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Crews",
                newName: "PeopleId");

            migrationBuilder.RenameIndex(
                name: "IX_Crews_PersonId_StarShipFlightId",
                table: "Crews",
                newName: "IX_Crews_PeopleId_StarShipFlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Person_PeopleId",
                table: "Crews",
                column: "PeopleId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Person_PeopleId",
                table: "Passengers",
                column: "PeopleId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
