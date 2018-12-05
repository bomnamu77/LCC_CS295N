using Microsoft.EntityFrameworkCore.Migrations;

namespace RPSGame.Migrations
{
    public partial class updateGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_GamerUserID",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GamerUserID",
                table: "Games",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GamerUserID",
                table: "Games",
                newName: "IX_Games_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserID",
                table: "Games",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserID",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Games",
                newName: "GamerUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_UserID",
                table: "Games",
                newName: "IX_Games_GamerUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_GamerUserID",
                table: "Games",
                column: "GamerUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
