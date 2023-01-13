using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lali.DataAccess.Migrations
{
    public partial class BestellungManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tracking",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transporter",
                table: "Bestellung",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tracking",
                table: "Bestellung");

            migrationBuilder.DropColumn(
                name: "Transporter",
                table: "Bestellung");
        }
    }
}
