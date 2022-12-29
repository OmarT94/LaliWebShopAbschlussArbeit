using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lali.DataAccess.Migrations
{
    public partial class AddArtikel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KategorieName",
                table: "Artikel");

            migrationBuilder.CreateIndex(
                name: "IX_Artikel_KategorieId",
                table: "Artikel",
                column: "KategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikel_Kategorie_KategorieId",
                table: "Artikel",
                column: "KategorieId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikel_Kategorie_KategorieId",
                table: "Artikel");

            migrationBuilder.DropIndex(
                name: "IX_Artikel_KategorieId",
                table: "Artikel");

            migrationBuilder.AddColumn<string>(
                name: "KategorieName",
                table: "Artikel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 1,
                column: "KategorieName",
                value: "Kleidung");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 2,
                column: "KategorieName",
                value: "Haushaltgeräte");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 3,
                column: "KategorieName",
                value: "Elektronikgeräte");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 4,
                column: "KategorieName",
                value: "Computer");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 5,
                column: "KategorieName",
                value: "Mobiletelefone");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 6,
                column: "KategorieName",
                value: "TestKategorie");
        }
    }
}
