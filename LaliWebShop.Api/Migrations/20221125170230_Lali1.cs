using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaliWebShop.Api.Migrations
{
    public partial class Lali1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artikelnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreisSingleNetto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    KategorieId = table.Column<int>(type: "int", nullable: false),
                    KategorieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "BestellungsArtikel",
                columns: table => new
                {
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    BestellungId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ArtikelMenge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestellungsArtikel", x => new { x.ArtikelId, x.BestellungId });
                    table.ForeignKey(
                        name: "FK_BestellungsArtikel_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestellungsArtikel_Bestellung_BestellungId",
                        column: x => x.BestellungId,
                        principalTable: "Bestellung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artikel",
                columns: new[] { "Id", "Artikelnummer", "BestellungId", "Bezeichnung", "ImageURL", "KategorieId", "KategorieName", "Menge", "Name", "PreisSingleNetto" },
                values: new object[,]
                {
                    { 1, "K1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/Beauty/Beauty1.png", 1, "Kleidung", 100, "Glossier - Beauty Kit", 100m },
                    { 2, "H1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/Beauty/Beauty1.png", 2, "Haushaltgeräte", 100, "Glossier - Beauty Kit", 100m },
                    { 3, "E1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/Beauty/Beauty1.png", 3, "Elektronikgeräte", 100, "Glossier - Beauty Kit", 100m },
                    { 4, "C1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/Beauty/Beauty1.png", 4, "Computer", 100, "Glossier - Beauty Kit", 100m },
                    { 5, "M1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/Beauty/Beauty1.png", 5, "Mobiletelefone", 100, "Glossier - Beauty Kit", 100m },
                    { 6, "T1", null, "A kit provided by Glossier, containing skin care, hair care and makeup products", "/Images/Beauty/Beauty1.png", 6, "TestKategorie", 100, "Glossier - Beauty Kit", 100m }
                });

            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kleidung" },
                    { 2, "Haushaltgeräte" },
                    { 3, "Elektronikgeräte" },
                    { 4, "Computer" },
                    { 5, "Mobiletelefone" },
                    { 6, "TestKategorie" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BestellungsArtikel_BestellungId",
                table: "BestellungsArtikel",
                column: "BestellungId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestellungsArtikel");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Kunde");

            migrationBuilder.DropTable(
                name: "Warenkorb");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Bestellung");
        }
    }
}
