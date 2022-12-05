using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaliWebShop.Api.Migrations
{
    public partial class Warenkorb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KategorielName",
                table: "WarenkorbItem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KategorielName",
                table: "WarenkorbItem");
        }
    }
}
