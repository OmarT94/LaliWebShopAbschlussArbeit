using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lali.DataAccess.Migrations
{
    public partial class InitialIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anrede",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HandyNummer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hausnummer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Land",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ort",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Plz",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Strasse",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anrede",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HandyNummer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Hausnummer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Land",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ort",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Plz",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Strasse",
                table: "AspNetUsers");
        }
    }
}
