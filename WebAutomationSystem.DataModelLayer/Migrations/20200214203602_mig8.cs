using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDayDate",
                table: "Users_Tbl");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDayDateMilladi",
                table: "Users_Tbl",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDayDateMilladi",
                table: "Users_Tbl");

            migrationBuilder.AddColumn<string>(
                name: "BirthDayDate",
                table: "Users_Tbl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
