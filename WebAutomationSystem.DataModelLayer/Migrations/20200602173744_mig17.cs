using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReferralLetters",
                columns: table => new
                {
                    ReferralLettersID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterID = table.Column<int>(nullable: false),
                    mainUserID = table.Column<string>(nullable: true),
                    ReferUserID = table.Column<string>(nullable: true),
                    RecieveReferUserID = table.Column<string>(nullable: true),
                    ReferDate = table.Column<DateTime>(nullable: false),
                    ReadType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralLetters", x => x.ReferralLettersID);
                    table.ForeignKey(
                        name: "FK_ReferralLetters_Letters_LetterID",
                        column: x => x.LetterID,
                        principalTable: "Letters",
                        principalColumn: "LetterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferralLetters_Users_RecieveReferUserID",
                        column: x => x.RecieveReferUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReferralLetters_Users_ReferUserID",
                        column: x => x.ReferUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReferralLetters_Users_mainUserID",
                        column: x => x.mainUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReferralLetters_LetterID",
                table: "ReferralLetters",
                column: "LetterID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralLetters_RecieveReferUserID",
                table: "ReferralLetters",
                column: "RecieveReferUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralLetters_ReferUserID",
                table: "ReferralLetters",
                column: "ReferUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralLetters_mainUserID",
                table: "ReferralLetters",
                column: "mainUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReferralLetters");
        }
    }
}
