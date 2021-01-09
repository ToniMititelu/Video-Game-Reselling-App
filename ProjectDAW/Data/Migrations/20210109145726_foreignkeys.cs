using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDAW.Data.Migrations
{
    public partial class foreignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "ContentRatingID",
                table: "Genre",
                newName: "ContentRatingId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Game",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_ContentRatingId",
                table: "Genre",
                column: "ContentRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GameId",
                table: "GameGenre",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenreId",
                table: "GameGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_UserId",
                table: "Game",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_AspNetUsers_UserId",
                table: "Game",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Game_GameId",
                table: "GameGenre",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genre_GenreId",
                table: "GameGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_ContentRating_ContentRatingId",
                table: "Genre",
                column: "ContentRatingId",
                principalTable: "ContentRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_AspNetUsers_UserId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Game_GameId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genre_GenreId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_ContentRating_ContentRatingId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_ContentRatingId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_GameGenre_GameId",
                table: "GameGenre");

            migrationBuilder.DropIndex(
                name: "IX_GameGenre_GenreId",
                table: "GameGenre");

            migrationBuilder.DropIndex(
                name: "IX_Game_UserId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "ContentRatingId",
                table: "Genre",
                newName: "ContentRatingID");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersId",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
