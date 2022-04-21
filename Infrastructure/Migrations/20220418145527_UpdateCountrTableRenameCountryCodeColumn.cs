using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Infrastructure.Migrations
{
    public partial class UpdateCountrTableRenameCountryCodeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Countries",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Countries",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
