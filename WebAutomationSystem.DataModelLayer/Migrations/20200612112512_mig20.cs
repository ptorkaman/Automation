using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notation",
                columns: table => new
                {
                    NotationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotationTitle = table.Column<string>(nullable: true),
                    NotationContent = table.Column<string>(nullable: true),
                    NotationDate = table.Column<DateTime>(nullable: false),
                    UserID_Creator = table.Column<string>(nullable: true),
                    UserID_Reciever = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notation", x => x.NotationID);
                    table.ForeignKey(
                        name: "FK_Notation_Users_UserID_Creator",
                        column: x => x.UserID_Creator,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notation_Users_UserID_Reciever",
                        column: x => x.UserID_Reciever,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notation_UserID_Creator",
                table: "Notation",
                column: "UserID_Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Notation_UserID_Reciever",
                table: "Notation",
                column: "UserID_Reciever");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notation");
        }
    }
}
