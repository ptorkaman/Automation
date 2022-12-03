using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomationSystem.DataModelLayer.Migrations
{
    public partial class mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    LetterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterContent = table.Column<string>(nullable: true),
                    LetterSubject = table.Column<string>(nullable: true),
                    ImmediatellyStatus = table.Column<byte>(nullable: false),
                    ClassificationStatus = table.Column<byte>(nullable: false),
                    AttachmentStatus = table.Column<bool>(nullable: false),
                    ReplyStatus = table.Column<bool>(nullable: false),
                    LetterAttachamentFile = table.Column<string>(nullable: true),
                    ReplyDate = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    LetterCreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.LetterID);
                    table.ForeignKey(
                        name: "FK_Letters_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Letters_UserID",
                table: "Letters",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Letters");
        }
    }
}
