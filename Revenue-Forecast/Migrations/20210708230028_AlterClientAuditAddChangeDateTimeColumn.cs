using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revenue_Forecast.Migrations
{
    public partial class AlterClientAuditAddChangeDateTimeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeDateTime",
                table: "ClientAudits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeDateTime",
                table: "ClientAudits");
        }
    }
}
