using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDAW.Data.Migrations
{
    public partial class Extend_IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Profile_UserId",
                table: "Listing");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Listing",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Listing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listing_ProfileId",
                table: "Listing",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_AspNetUsers_UserId",
                table: "Listing",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Profile_ProfileId",
                table: "Listing",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_AspNetUsers_UserId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Profile_ProfileId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_Listing_ProfileId",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Listing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Profile_UserId",
                table: "Listing",
                column: "UserId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
