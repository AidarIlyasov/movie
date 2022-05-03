using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MovieApp.Infrastructure.Migrations
{
    public partial class UpdateHomePageSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePageSettings",
                table: "HomePageSettings");

            migrationBuilder.DeleteData(
                table: "HomePageSettings",
                keyColumns: new[] { "MovieId", "Position" },
                keyColumnTypes: new[] { "integer", "character varying(50)" },
                keyValues: new object[] { 2, "season" });

            migrationBuilder.DeleteData(
                table: "HomePageSettings",
                keyColumns: new[] { "MovieId", "Position" },
                keyColumnTypes: new[] { "integer", "character varying(50)" },
                keyValues: new object[] { 3, "season" });

            migrationBuilder.DeleteData(
                table: "HomePageSettings",
                keyColumns: new[] { "MovieId", "Position" },
                keyColumnTypes: new[] { "integer", "character varying(50)" },
                keyValues: new object[] { 4, "season" });

            migrationBuilder.DeleteData(
                table: "HomePageSettings",
                keyColumns: new[] { "MovieId", "Position" },
                keyColumnTypes: new[] { "integer", "character varying(50)" },
                keyValues: new object[] { 5, "season" });

            migrationBuilder.DropColumn(
                name: "Position",
                table: "HomePageSettings");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "HomePageSettings",
                type: "integer",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePageSettings",
                table: "HomePageSettings",
                columns: new[] { "MovieId", "PositionId" });

            migrationBuilder.CreateTable(
                name: "HomePagePositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePagePositions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HomePagePositions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "season" },
                    { 2, "new" },
                    { 3, "expected" }
                });

            migrationBuilder.InsertData(
                table: "HomePageSettings",
                columns: new[] { "MovieId", "PositionId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePagePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomePageSettings",
                table: "HomePageSettings");

            migrationBuilder.DeleteData(
                table: "HomePageSettings",
                keyColumns: new[] { "MovieId", "PositionId" },
                keyColumnTypes: new[] { "integer", "integer" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "HomePageSettings",
                keyColumns: new[] { "MovieId", "PositionId" },
                keyColumnTypes: new[] { "integer", "integer" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "HomePageSettings",
                keyColumns: new[] { "MovieId", "PositionId" },
                keyColumnTypes: new[] { "integer", "integer" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "HomePageSettings",
                keyColumns: new[] { "MovieId", "PositionId" },
                keyColumnTypes: new[] { "integer", "integer" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "HomePageSettings");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "HomePageSettings",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomePageSettings",
                table: "HomePageSettings",
                columns: new[] { "MovieId", "Position" });

            migrationBuilder.InsertData(
                table: "HomePageSettings",
                columns: new[] { "MovieId", "Position" },
                values: new object[,]
                {
                    { 2, "season" },
                    { 3, "season" },
                    { 4, "season" },
                    { 5, "season" }
                });
        }
    }
}
