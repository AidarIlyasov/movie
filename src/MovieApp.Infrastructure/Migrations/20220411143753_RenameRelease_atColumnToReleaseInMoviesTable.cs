using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Infrastructure.Migrations
{
    public partial class RenameRelease_atColumnToReleaseInMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Release_at",
                table: "Movies",
                newName: "Release");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Reviews",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Qualities",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "HomePageSettings",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Countries",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Countries",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Categories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Link", "Name" },
                values: new object[] { "2", "21+" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Link", "Name" },
                values: new object[] { "18", "18+" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Link", "Name" },
                values: new object[] { "16", "16+" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Link", "Name" },
                values: new object[] { "14", "14+" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Link", "Name" },
                values: new object[] { "12", "12+" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Link", "Name" },
                values: new object[] { "6", "6+" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Release",
                table: "Movies",
                newName: "Release_at");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Reviews",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Qualities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "HomePageSettings",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Countries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Countries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Link", "Name" },
                values: new object[] { null, "21" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Link", "Name" },
                values: new object[] { null, "18" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Link", "Name" },
                values: new object[] { null, "16" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Link", "Name" },
                values: new object[] { null, "14" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Link", "Name" },
                values: new object[] { null, "12" });

            migrationBuilder.UpdateData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Link", "Name" },
                values: new object[] { null, "6" });
        }
    }
}
