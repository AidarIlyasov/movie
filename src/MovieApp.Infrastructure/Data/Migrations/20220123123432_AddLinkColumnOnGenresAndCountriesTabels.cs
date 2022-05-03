using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Infrastructure.Data.Migrations
{
    public partial class AddLinkColumnOnGenresAndCountriesTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Genres",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Countries",
                type: "varchar(255)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Countries");
        }
    }
}
