using Microsoft.EntityFrameworkCore.Migrations;

namespace RollingMachines.Migrations
{
    public partial class UpdatedRentFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "Rents",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndDateTime",
                table: "Rents",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Rents",
                newName: "StartDateTime");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Rents",
                newName: "EndDateTime");
        }
    }
}
