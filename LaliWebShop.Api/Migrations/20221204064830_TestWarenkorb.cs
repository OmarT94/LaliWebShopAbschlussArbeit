using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaliWebShop.Api.Migrations
{
    public partial class TestWarenkorb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "Kunde",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Warenkorb",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
