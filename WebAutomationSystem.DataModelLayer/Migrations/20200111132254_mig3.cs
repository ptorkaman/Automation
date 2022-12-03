using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IaActive",
                table: "Users_Tbl");

            migrationBuilder.AddColumn<byte>(
                name: "IsActive",
                table: "Users_Tbl",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users_Tbl");

            migrationBuilder.AddColumn<byte>(
                name: "IaActive",
                table: "Users_Tbl",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
