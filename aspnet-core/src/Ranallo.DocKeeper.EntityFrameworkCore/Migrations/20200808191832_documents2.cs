using Microsoft.EntityFrameworkCore.Migrations;

namespace Ranallo.DocKeeper.Migrations
{
    public partial class documents2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Documents",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Documents",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Documents",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "Documents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
