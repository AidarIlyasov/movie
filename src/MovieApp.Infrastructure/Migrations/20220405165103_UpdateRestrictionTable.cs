using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Infrastructure.Migrations
{
    public partial class UpdateRestrictionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Restrictions",
                newName: "Link");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Link",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Link",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Link",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Link",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Link",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Link",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Restrictions",
                newName: "Type");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: "");
        }
    }
}
