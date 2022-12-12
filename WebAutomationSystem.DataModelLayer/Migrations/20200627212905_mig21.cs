using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    LeaveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<byte>(nullable: false),
                    FromDate_Day = table.Column<DateTime>(nullable: true),
                    ToDate_Day = table.Column<DateTime>(nullable: true),
                    FromTime_Saati = table.Column<DateTime>(nullable: true),
                    ToTime_Saati = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LeaveRequestDate = table.Column<DateTime>(nullable: false),
                    UserID_Request = table.Column<string>(nullable: true),
                    UserID_Confirm = table.Column<string>(nullable: true),
                    LeaveAccept = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.LeaveID);
                    table.ForeignKey(
                        name: "FK_Leave_Users_UserID_Confirm",
                        column: x => x.UserID_Confirm,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leave_Users_UserID_Request",
                        column: x => x.UserID_Request,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leave_UserID_Confirm",
                table: "Leave",
                column: "UserID_Confirm");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_UserID_Request",
                table: "Leave",
                column: "UserID_Request");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leave");
        }
    }
}
