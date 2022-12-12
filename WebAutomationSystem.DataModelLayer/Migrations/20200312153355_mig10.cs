using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePattern",
                columns: table => new
                {
                    RolePatternID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolePatternName = table.Column<string>(nullable: true),
                    RolePatternDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePattern", x => x.RolePatternID);
                });

            migrationBuilder.CreateTable(
                name: "RolePatternDetails",
                columns: table => new
                {
                    RolePatternDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolePatternID = table.Column<int>(nullable: false),
                    RoleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePatternDetails", x => x.RolePatternDetailsID);
                    table.ForeignKey(
                        name: "FK_RolePatternDetails_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePatternDetails_RolePattern_RolePatternID",
                        column: x => x.RolePatternID,
                        principalTable: "RolePattern",
                        principalColumn: "RolePatternID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePatternDetails_RoleID",
                table: "RolePatternDetails",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePatternDetails_RolePatternID",
                table: "RolePatternDetails",
                column: "RolePatternID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePatternDetails");

            migrationBuilder.DropTable(
                name: "RolePattern");
        }
    }
}
