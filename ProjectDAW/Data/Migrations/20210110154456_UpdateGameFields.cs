using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDAW.Data.Migrations
{
    public partial class UpdateGameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContentRatingId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Game",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Game",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Game_ContentRatingId",
                table: "Game",
                column: "ContentRatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_ContentRating_ContentRatingId",
                table: "Game",
                column: "ContentRatingId",
                principalTable: "ContentRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_ContentRating_ContentRatingId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ContentRatingId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ContentRatingId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Game");
        }
    }
}
