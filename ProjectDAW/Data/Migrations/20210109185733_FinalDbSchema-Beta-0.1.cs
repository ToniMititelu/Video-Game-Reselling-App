using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDAW.Data.Migrations
{
    public partial class FinalDbSchemaBeta01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Game_GameId",
                table: "Bid");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_AspNetUsers_UserId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_UserId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "BuyNowPrice",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "StartingPrice",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Bid",
                newName: "ListingId");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_GameId",
                table: "Bid",
                newName: "IX_Bid_ListingId");

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyNowPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listing_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listing_Profile_UserId",
                        column: x => x.UserId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listing_GameId",
                table: "Listing",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_UserId",
                table: "Listing",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Listing_ListingId",
                table: "Bid",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Listing_ListingId",
                table: "Bid");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.RenameColumn(
                name: "ListingId",
                table: "Bid",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_ListingId",
                table: "Bid",
                newName: "IX_Bid_GameId");

            migrationBuilder.AddColumn<decimal>(
                name: "BuyNowPrice",
                table: "Game",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Game",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresAt",
                table: "Game",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "StartingPrice",
                table: "Game",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Game",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_UserId",
                table: "Game",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Game_GameId",
                table: "Bid",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_AspNetUsers_UserId",
                table: "Game",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
