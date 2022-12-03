using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles_Tbl",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleLevel",
                table: "Roles_Tbl",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles_Tbl");

            migrationBuilder.DropColumn(
                name: "RoleLevel",
                table: "Roles_Tbl");
        }
    }
}
