using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lali.DataAccess.Migrations
{
    public partial class Bestellung : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kunde");

            migrationBuilder.RenameColumn(
                name: "KundenId",
                table: "Bestellung",
                newName: "Plz");

            migrationBuilder.RenameColumn(
                name: "BestellNummer",
                table: "Bestellung",
                newName: "BenutzerId");

            migrationBuilder.AddColumn<string>(
                name: "Anrede",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrzahlungId",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HandyNummer",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hausnummer",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Land",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ort",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Strasse",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vorname",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BestellungItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestellungId = table.Column<int>(type: "int", nullable: false),
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    ArtikelPreisSingleNetto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArtikelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestellungItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestellungItems");

            migrationBuilder.DropColumn(
                name: "Anrede",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "BrzahlungId",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "HandyNummer",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "Hausnummer",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "Land",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "Ort",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "Strasse",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "Vorname",
                table: "Bestellung");

            migrationBuilder.RenameColumn(
                name: "Plz",
                table: "Bestellung",
                newName: "KundenId");

            migrationBuilder.RenameColumn(
                name: "BenutzerId",
                table: "Bestellung",
                newName: "BestellNummer");

            migrationBuilder.CreateTable(
                name: "Kunde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anrede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hausnummer = table.Column<int>(type: "int", nullable: false),
                    KundenNummer = table.Column<int>(type: "int", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plz = table.Column<int>(type: "int", nullable: false),
                    Strasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kunde",
                columns: new[] { "Id", "Anrede", "Email", "Hausnummer", "KundenNummer", "Land", "Name", "Ort", "Plz", "Strasse", "Vorname" },
                values: new object[] { 1, "Herr", "TestWmail@test.com", 5, 518, "Testland", "testname", "TestOrt", 52551, "testStraße", "TestVorname" });
        }
    }
}
