using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookcrossing.Data.Migrations
{
    public partial class UpdateBookUserEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    SubscribeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscribeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.SubscribeId, x.SubscribeId1 });
                    table.ForeignKey(
                        name: "FK_BookUser_Books_SubscribeId1",
                        column: x => x.SubscribeId1,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Users_SubscribeId",
                        column: x => x.SubscribeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsDeleted",
                table: "Users",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_IsDeleted",
                table: "Publishers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfIssuingBooks_IsDeleted",
                table: "HistoryOfIssuingBooks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IsDeleted",
                table: "Books",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_IsDeleted",
                table: "Authors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_SubscribeId1",
                table: "BookUser",
                column: "SubscribeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropIndex(
                name: "IX_Users_IsDeleted",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_IsDeleted",
                table: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_HistoryOfIssuingBooks_IsDeleted",
                table: "HistoryOfIssuingBooks");

            migrationBuilder.DropIndex(
                name: "IX_Books_IsDeleted",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_IsDeleted",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");
        }
    }
}
