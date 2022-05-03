using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Infrastructure.Migrations
{
    public partial class ChangeRestrictionLinkColumnTypeToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Link",
                table: "Restrictions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Link",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Link",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Link",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Link",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Link",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Link",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Restrictions",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Link",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Link",
                value: "18");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Link",
                value: "16");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Link",
                value: "14");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Link",
                value: "12");

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Link",
                value: "6");
        }
    }
}
