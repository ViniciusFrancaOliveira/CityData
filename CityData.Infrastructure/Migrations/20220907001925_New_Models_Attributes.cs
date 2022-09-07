using Microsoft.EntityFrameworkCore.Migrations;

namespace CityData.Infrastructure.Migrations
{
    public partial class New_Models_Attributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ethnic",
                table: "States",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HDI",
                table: "States",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TerritorialArea",
                table: "States",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ethnic",
                table: "Cities",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HDI",
                table: "Cities",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TerritorialArea",
                table: "Cities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ethnic",
                table: "States");

            migrationBuilder.DropColumn(
                name: "HDI",
                table: "States");

            migrationBuilder.DropColumn(
                name: "TerritorialArea",
                table: "States");

            migrationBuilder.DropColumn(
                name: "Ethnic",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "HDI",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "TerritorialArea",
                table: "Cities");
        }
    }
}
