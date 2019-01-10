using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Songrics.Data.Migrations
{
    public partial class CustomViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Lyrics",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
