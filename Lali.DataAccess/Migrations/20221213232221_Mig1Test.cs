using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lali.DataAccess.Migrations
{
    public partial class Mig1Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artikelnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreisSingleNetto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    KategorieId = table.Column<int>(type: "int", nullable: false),
                    KategorieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestellungId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bestellung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestellNummer = table.Column<int>(type: "int", nullable: false),
                    KundenId = table.Column<int>(type: "int", nullable: false),
                    BestelltAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SummeNetto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MwSt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SummeBrutto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kunde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KundenNummer = table.Column<int>(type: "int", nullable: false),
                    Anrede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hausnummer = table.Column<int>(type: "int", nullable: false),
                    Plz = table.Column<int>(type: "int", nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warenkorb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KundenId = table.Column<int>(type: "int", nullable: false),
                    BestellungId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warenkorb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarenkorbItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    WarenkorbId = table.Column<int>(type: "int", nullable: false),
                    ArtikelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtikelBezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtikelNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtikelMenge = table.Column<int>(type: "int", nullable: false),
                    ArtikelImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtikelPreisSingleNetto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArtikelPreisGesamtNetto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mwst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gesamtpreis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KategorielName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarenkorbItem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artikel",
                columns: new[] { "Id", "Artikelnummer", "BestellungId", "Bezeichnung", "ImageURL", "KategorieId", "KategorieName", "Menge", "Name", "PreisSingleNetto" },
                values: new object[,]
                {
                    { 1, "K1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/ArtikelImages/Kleidung/Kleider.png", 1, "Kleidung", 100, "TestKleidung", 100m },
                    { 2, "H1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/ArtikelImages/Haushaltgeräte/HaushaltGerät.png", 2, "Haushaltgeräte", 100, "HaushaltgeräteTest", 100m },
                    { 3, "E1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/ArtikelImages/Elektronikgeräte/ElekGerät.png", 3, "Elektronikgeräte", 100, " ElektronikgeräteTest", 100m },
                    { 4, "C1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/ArtikelImages/Computer/Computer.png", 4, "Computer", 100, "ComputerTest", 100m },
                    { 5, "M1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/ArtikelImages/Mobiletelefone/Mobile.png", 5, "Mobiletelefone", 100, "MobiletelefoneTest", 100m },
                    { 6, "T1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/ArtikelImages/TestKategorie/Test.png", 6, "TestKategorie", 100, "TestKategorieTest", 100m }
                });

            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kleidung" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haushaltgeräte" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elektronikgeräte" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobiletelefone" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestKategorie" }
                });

            migrationBuilder.InsertData(
                table: "Kunde",
                columns: new[] { "Id", "Anrede", "Email", "Hausnummer", "KundenNummer", "Land", "Name", "Ort", "Plz", "Strasse", "Vorname" },
                values: new object[] { 1, "Herr", "TestWmail@test.com", 5, 518, "Testland", "testname", "TestOrt", 52551, "testStraße", "TestVorname" });

            migrationBuilder.InsertData(
                table: "Warenkorb",
                columns: new[] { "Id", "BestellungId", "KundenId" },
                values: new object[] { 1, 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Bestellung");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Kunde");

            migrationBuilder.DropTable(
                name: "Warenkorb");

            migrationBuilder.DropTable(
                name: "WarenkorbItem");
        }
    }
}
