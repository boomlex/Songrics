using Microsoft.EntityFrameworkCore.Migrations;

namespace Songrics.Data.Migrations
{
    public partial class UpdateNewHome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lyrics_Categories_Categoryid",
                table: "Lyrics");

            migrationBuilder.DropIndex(
                name: "IX_Lyrics_Categoryid",
                table: "Lyrics");

            migrationBuilder.DropColumn(
                name: "Categoryid",
                table: "Lyrics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoryid",
                table: "Lyrics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lyrics_Categoryid",
                table: "Lyrics",
                column: "Categoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Lyrics_Categories_Categoryid",
                table: "Lyrics",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
