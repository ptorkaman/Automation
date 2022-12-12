using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInDraft",
                table: "Letters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SentLetters",
                columns: table => new
                {
                    SentLetterdID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterID = table.Column<int>(nullable: false),
                    SentLetterDate = table.Column<DateTime>(nullable: false),
                    userId_sender = table.Column<string>(nullable: true),
                    userId_reciever = table.Column<string>(nullable: true),
                    ReadType = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentLetters", x => x.SentLetterdID);
                    table.ForeignKey(
                        name: "FK_SentLetters_Letters_LetterID",
                        column: x => x.LetterID,
                        principalTable: "Letters",
                        principalColumn: "LetterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SentLetters_Users_userId_reciever",
                        column: x => x.userId_reciever,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SentLetters_LetterID",
                table: "SentLetters",
                column: "LetterID");

            migrationBuilder.CreateIndex(
                name: "IX_SentLetters_userId_reciever",
                table: "SentLetters",
                column: "userId_reciever");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentLetters");

            migrationBuilder.DropColumn(
                name: "IsInDraft",
                table: "Letters");
        }
    }
}
