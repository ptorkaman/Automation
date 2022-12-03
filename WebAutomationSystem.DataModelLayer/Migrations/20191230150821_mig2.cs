using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users_Tbl",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthDayDate",
                table: "Users_Tbl",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Users_Tbl",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users_Tbl",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "Users_Tbl",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IaActive",
                table: "Users_Tbl",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Users_Tbl",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MelliCode",
                table: "Users_Tbl",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalCode",
                table: "Users_Tbl",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Users_Tbl",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SignaturePath",
                table: "Users_Tbl",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "BirthDayDate",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "IaActive",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "MelliCode",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "PersonalCode",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Users_Tbl");

            migrationBuilder.DropColumn(
                name: "SignaturePath",
                table: "Users_Tbl");
        }
    }
}
