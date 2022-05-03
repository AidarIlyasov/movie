using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Infrastructure.Data.Migrations
{
    public partial class AddReleaseCoulumnInMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Release_at",
                table: "Movies",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Release_at",
                table: "Movies");
        }
    }
}
