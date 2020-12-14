using Microsoft.EntityFrameworkCore.Migrations;

namespace RollingMachines.Migrations
{
    public partial class UpdatedRentFields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fine",
                table: "Rents");

            migrationBuilder.AddColumn<float>(
                name: "PriceInPent",
                table: "Rents",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceInPent",
                table: "Rents");

            migrationBuilder.AddColumn<int>(
                name: "Fine",
                table: "Rents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
