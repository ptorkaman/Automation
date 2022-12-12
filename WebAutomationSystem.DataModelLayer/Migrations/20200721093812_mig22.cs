using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForeignDocuments",
                columns: table => new
                {
                    ForeignDocumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNameDelivery = table.Column<string>(nullable: true),
                    PhoneNumberDelivery = table.Column<string>(nullable: true),
                    DocumentTitle = table.Column<string>(nullable: true),
                    DocumentContent = table.Column<string>(nullable: true),
                    DocumentImagePath = table.Column<string>(nullable: true),
                    DocumentEnterDate = table.Column<DateTime>(nullable: false),
                    OrgnizationDocumentName = table.Column<string>(nullable: true),
                    UserID_SaveDocument = table.Column<string>(nullable: true),
                    UserID_RecieveDocument = table.Column<string>(nullable: true),
                    DocumentNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignDocuments", x => x.ForeignDocumentID);
                    table.ForeignKey(
                        name: "FK_ForeignDocuments_Users_UserID_RecieveDocument",
                        column: x => x.UserID_RecieveDocument,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignDocuments_Users_UserID_SaveDocument",
                        column: x => x.UserID_SaveDocument,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForeignDocuments_UserID_RecieveDocument",
                table: "ForeignDocuments",
                column: "UserID_RecieveDocument");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignDocuments_UserID_SaveDocument",
                table: "ForeignDocuments",
                column: "UserID_SaveDocument");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForeignDocuments");
        }
    }
}
