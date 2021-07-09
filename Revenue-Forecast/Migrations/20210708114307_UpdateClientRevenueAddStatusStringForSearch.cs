using Microsoft.EntityFrameworkCore.Migrations;

namespace Revenue_Forecast.Migrations
{
    public partial class UpdateClientRevenueAddStatusStringForSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusString",
                table: "ClientRevenues",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusString",
                table: "ClientRevenues");
        }
    }
}
