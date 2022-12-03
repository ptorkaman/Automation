using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndJobName",
                table: "UserJob_Tbl");

            migrationBuilder.DropColumn(
                name: "StartJobName",
                table: "UserJob_Tbl");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndJobDate",
                table: "UserJob_Tbl",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartJobDate",
                table: "UserJob_Tbl",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndJobDate",
                table: "UserJob_Tbl");

            migrationBuilder.DropColumn(
                name: "StartJobDate",
                table: "UserJob_Tbl");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndJobName",
                table: "UserJob_Tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartJobName",
                table: "UserJob_Tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
