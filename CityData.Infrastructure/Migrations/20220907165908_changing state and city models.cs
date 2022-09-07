using Microsoft.EntityFrameworkCore.Migrations;

namespace CityData.Infrastructure.Migrations
{
    public partial class changingstateandcitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TerritorialArea",
                table: "States",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "TerritorialArea",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TerritorialArea",
                table: "States",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "TerritorialArea",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
