using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobsChartID",
                table: "ForeignDocuments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ForeignDocuments_JobsChartID",
                table: "ForeignDocuments",
                column: "JobsChartID");

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignDocuments_JobsChart_JobsChartID",
                table: "ForeignDocuments",
                column: "JobsChartID",
                principalTable: "JobsChart",
                principalColumn: "JobsChartID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForeignDocuments_JobsChart_JobsChartID",
                table: "ForeignDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ForeignDocuments_JobsChartID",
                table: "ForeignDocuments");

            migrationBuilder.DropColumn(
                name: "JobsChartID",
                table: "ForeignDocuments");
        }
    }
}
