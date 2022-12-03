using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministrativeForm",
                columns: table => new
                {
                    AdministrativeFormID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministrativeFormType = table.Column<bool>(nullable: false),
                    AdministrativeFormTitle = table.Column<string>(nullable: true),
                    AdministrativeFormContent = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeForm", x => x.AdministrativeFormID);
                    table.ForeignKey(
                        name: "FK_AdministrativeForm_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeForm_UserID",
                table: "AdministrativeForm",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministrativeForm");
        }
    }
}
