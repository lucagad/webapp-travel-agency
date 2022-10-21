using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class TravelMessageTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "message");
        }
    }
}
