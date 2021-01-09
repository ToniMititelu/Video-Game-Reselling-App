using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDAW.Data.Migrations
{
    public partial class gamegenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Game",
                newName: "ExpiresAt");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Game",
                newName: "StartingPrice");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Game",
                newName: "AspNetUsersId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Game",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContentRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentRatingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentRating");

            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropColumn(
                name: "BuyNowPrice",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "StartingPrice",
                table: "Game",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ExpiresAt",
                table: "Game",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "AspNetUsersId",
                table: "Game",
                newName: "Genre");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
