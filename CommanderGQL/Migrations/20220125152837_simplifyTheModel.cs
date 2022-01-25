using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderGQL.Migrations
{
    public partial class simplifyTheModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Persson_PerssonId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Persson_PerssonId",
                table: "Passengers");

            migrationBuilder.DropTable(
                name: "Persson");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_PerssonId_StarShipFlightId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Crews_PerssonId_StarShipFlightId",
                table: "Crews");

            migrationBuilder.DropColumn(
                name: "PerssonId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PerssonId",
                table: "Crews");

            migrationBuilder.AddColumn<string>(
                name: "Persson",
                table: "Passengers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Persson",
                table: "Crews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_Persson_StarShipFlightId",
                table: "Passengers",
                columns: new[] { "Persson", "StarShipFlightId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crews_Persson_StarShipFlightId",
                table: "Crews",
                columns: new[] { "Persson", "StarShipFlightId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passengers_Persson_StarShipFlightId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Crews_Persson_StarShipFlightId",
                table: "Crews");

            migrationBuilder.DropColumn(
                name: "Persson",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Persson",
                table: "Crews");

            migrationBuilder.AddColumn<int>(
                name: "PerssonId",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PerssonId",
                table: "Crews",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_PerssonId_StarShipFlightId",
                table: "Passengers",
                columns: new[] { "PerssonId", "StarShipFlightId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crews_PerssonId_StarShipFlightId",
                table: "Crews",
                columns: new[] { "PerssonId", "StarShipFlightId" },
                unique: true);

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
    }
}
