using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaliWebShop.Api.Migrations
{
    public partial class Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "TestKleidung");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "HaushaltgeräteTest");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: " ElektronikgeräteTest");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "ComputerTest");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "MobiletelefoneTest");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "TestKategorieTest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Glossier");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Beauty Kit");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: " Kit");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Glossier - Beauty Kit");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Glossier - Beauty Kit");

            migrationBuilder.UpdateData(
                table: "Artikel",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Glossier - Beauty Kit");
        }
    }
}
