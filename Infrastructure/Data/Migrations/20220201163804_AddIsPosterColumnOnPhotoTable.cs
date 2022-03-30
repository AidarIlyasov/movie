using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Infrastructure.Data.Migrations
{
    public partial class AddIsPosterColumnOnPhotoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Photos_MovieId",
                table: "Photos");

            migrationBuilder.AddColumn<bool>(
                name: "IsPoster",
                table: "Photos",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_MovieId_IsPoster",
                table: "Photos",
                columns: new[] { "MovieId", "IsPoster" },
                unique: true,
                filter: "[IsPoster] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photos_MovieId_IsPoster",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "IsPoster",
                table: "Photos");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_MovieId",
                table: "Photos",
                column: "MovieId");
        }
    }
}
