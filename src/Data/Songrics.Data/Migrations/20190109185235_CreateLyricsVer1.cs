using Microsoft.EntityFrameworkCore.Migrations;

namespace Songrics.Data.Migrations
{
    public partial class CreateLyricsVer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lyrics_Categories_CategoryId",
                table: "Lyrics");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Lyrics",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Lyrics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Lyrics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lyrics_UserId",
                table: "Lyrics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lyrics_Categories_CategoryId",
                table: "Lyrics",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lyrics_AspNetUsers_UserId",
                table: "Lyrics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lyrics_Categories_CategoryId",
                table: "Lyrics");

            migrationBuilder.DropForeignKey(
                name: "FK_Lyrics_AspNetUsers_UserId",
                table: "Lyrics");

            migrationBuilder.DropIndex(
                name: "IX_Lyrics_UserId",
                table: "Lyrics");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Lyrics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lyrics");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Lyrics",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lyrics_Categories_CategoryId",
                table: "Lyrics",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
