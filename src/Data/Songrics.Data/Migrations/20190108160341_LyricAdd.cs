using Microsoft.EntityFrameworkCore.Migrations;

namespace Songrics.Data.Migrations
{
    public partial class LyricAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Type_Categories_Categoryid",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Type");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "Lyrics");

            migrationBuilder.RenameColumn(
                name: "TypeLyric",
                table: "Lyrics",
                newName: "VideoLink");

            migrationBuilder.RenameIndex(
                name: "IX_Type_Categoryid",
                table: "Lyrics",
                newName: "IX_Lyrics_Categoryid");

            migrationBuilder.AddColumn<string>(
                name: "AlbumName",
                table: "Lyrics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                table: "Lyrics",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lyrics",
                table: "Lyrics",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lyrics_Categories_Categoryid",
                table: "Lyrics",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lyrics_Categories_Categoryid",
                table: "Lyrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lyrics",
                table: "Lyrics");

            migrationBuilder.DropColumn(
                name: "AlbumName",
                table: "Lyrics");

            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "Lyrics");

            migrationBuilder.RenameTable(
                name: "Lyrics",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "VideoLink",
                table: "Type",
                newName: "TypeLyric");

            migrationBuilder.RenameIndex(
                name: "IX_Lyrics_Categoryid",
                table: "Type",
                newName: "IX_Type_Categoryid");

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "Type",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Categories_Categoryid",
                table: "Type",
                column: "Categoryid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
