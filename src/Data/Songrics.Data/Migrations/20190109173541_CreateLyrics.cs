using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Songrics.Data.Migrations
{
    public partial class CreateLyrics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Lyrics",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Lyrics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Lyrics",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lyrics_CategoryId",
                table: "Lyrics",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lyrics_Categories_CategoryId",
                table: "Lyrics",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lyrics_Categories_CategoryId",
                table: "Lyrics");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Lyrics_CategoryId",
                table: "Lyrics");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Lyrics");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Lyrics");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lyrics",
                newName: "id");
        }
    }
}
