using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IaActive",
                table: "Users");

            migrationBuilder.AddColumn<byte>(
                name: "IsActive",
                table: "Users",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.AddColumn<byte>(
                name: "IaActive",
                table: "Users",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
