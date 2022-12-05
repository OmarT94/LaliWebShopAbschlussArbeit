using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaliWebShop.Api.Migrations
{
    public partial class Warenkorb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Gesamtpreis = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarenkorbItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarenkorbItem");
        }
    }
}
