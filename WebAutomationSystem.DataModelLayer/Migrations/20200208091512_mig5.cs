using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserJob",
                columns: table => new
                {
                    UserJobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true),
                    JobID = table.Column<int>(nullable: false),
                    StartJobName = table.Column<DateTime>(nullable: false),
                    EndJobName = table.Column<DateTime>(nullable: false),
                    IaHaveJob = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJob", x => x.UserJobID);
                    table.ForeignKey(
                        name: "FK_UserJob_JobsChart_JobID",
                        column: x => x.JobID,
                        principalTable: "JobsChart",
                        principalColumn: "JobsChartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJob_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserJob_JobID",
                table: "UserJob",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_UserJob_UserID",
                table: "UserJob",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJob");
        }
    }
}
