using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderGQL.Migrations
{
    public partial class FixSomeTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Person_PersonId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Person_PersonId",
                table: "Passengers");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Passengers",
                newName: "PerssonId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_PersonId_StarShipFlightId",
                table: "Passengers",
                newName: "IX_Passengers_PerssonId_StarShipFlightId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Crews",
                newName: "PerssonId");

            migrationBuilder.RenameIndex(
                name: "IX_Crews_PersonId_StarShipFlightId",
                table: "Crews",
                newName: "IX_Crews_PerssonId_StarShipFlightId");

            migrationBuilder.CreateTable(
                name: "Persson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persson", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Persson_PerssonId",
                table: "Crews",
                column: "PerssonId",
                principalTable: "Persson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Persson_PerssonId",
                table: "Passengers",
                column: "PerssonId",
                principalTable: "Persson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Persson_PerssonId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Persson_PerssonId",
                table: "Passengers");

            migrationBuilder.DropTable(
                name: "Persson");

            migrationBuilder.RenameColumn(
                name: "PerssonId",
                table: "Passengers",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_PerssonId_StarShipFlightId",
                table: "Passengers",
                newName: "IX_Passengers_PersonId_StarShipFlightId");

            migrationBuilder.RenameColumn(
                name: "PerssonId",
                table: "Crews",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Crews_PerssonId_StarShipFlightId",
                table: "Crews",
                newName: "IX_Crews_PersonId_StarShipFlightId");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

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
    }
}
