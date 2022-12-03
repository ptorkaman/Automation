using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reminder_Tbl",
                columns: table => new
                {
                    ReminderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReminderTtile = table.Column<string>(nullable: true),
                    ReminderContent = table.Column<string>(nullable: true),
                    ReminderCreateDate = table.Column<DateTime>(nullable: false),
                    ReminderDate = table.Column<DateTime>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder_Tbl", x => x.ReminderID);
                    table.ForeignKey(
                        name: "FK_Reminder_Tbl_Users_Tbl_UserID",
                        column: x => x.UserID,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_Tbl_UserID",
                table: "Reminder_Tbl",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reminder_Tbl");
        }
    }
}
