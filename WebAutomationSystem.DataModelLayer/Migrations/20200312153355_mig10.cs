using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePattern_Tbl",
                columns: table => new
                {
                    RolePatternID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolePatternName = table.Column<string>(nullable: true),
                    RolePatternDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePattern_Tbl", x => x.RolePatternID);
                });

            migrationBuilder.CreateTable(
                name: "RolePatternDetails_Tbl",
                columns: table => new
                {
                    RolePatternDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolePatternID = table.Column<int>(nullable: false),
                    RoleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePatternDetails_Tbl", x => x.RolePatternDetailsID);
                    table.ForeignKey(
                        name: "FK_RolePatternDetails_Tbl_Roles_Tbl_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePatternDetails_Tbl_RolePattern_Tbl_RolePatternID",
                        column: x => x.RolePatternID,
                        principalTable: "RolePattern_Tbl",
                        principalColumn: "RolePatternID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePatternDetails_Tbl_RoleID",
                table: "RolePatternDetails_Tbl",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePatternDetails_Tbl_RolePatternID",
                table: "RolePatternDetails_Tbl",
                column: "RolePatternID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePatternDetails_Tbl");

            migrationBuilder.DropTable(
                name: "RolePattern_Tbl");
        }
    }
}
