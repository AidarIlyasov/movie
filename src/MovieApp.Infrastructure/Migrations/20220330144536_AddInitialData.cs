using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MovieApp.Infrastructure.Migrations
{
    public partial class AddInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Likes = table.Column<int>(type: "integer", nullable: false),
                    Dislikes = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Release_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RestrictionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Restrictions_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "Restrictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryMovie",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    MoviesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMovie", x => new { x.CategoriesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryMovie",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "integer", nullable: false),
                    MoviesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMovie", x => new { x.CountriesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CountryMovie_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomePageSettings",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageSettings", x => new { x.MovieId, x.Position });
                    table.ForeignKey(
                        name: "FK_HomePageSettings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieQuality",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "integer", nullable: false),
                    QualitiesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieQuality", x => new { x.MoviesId, x.QualitiesId });
                    table.ForeignKey(
                        name: "FK_MovieQuality_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieQuality_Qualities_QualitiesId",
                        column: x => x.QualitiesId,
                        principalTable: "Qualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    IsPoster = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Likes = table.Column<int>(type: "integer", nullable: false),
                    Dislikes = table.Column<int>(type: "integer", nullable: false),
                    ParrentId = table.Column<int>(type: "integer", nullable: false),
                    Published_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Likes = table.Column<int>(type: "integer", nullable: false),
                    Dislikes = table.Column<int>(type: "integer", nullable: false),
                    Published_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Link", "Name" },
                values: new object[,]
                {
                    { 1, "action", "action" },
                    { 2, "cartoons", "cartoons" },
                    { 3, "romantic", "romantic" },
                    { 4, "comedy", "comedy" },
                    { 5, "scientific", "scientific" },
                    { 6, "horror", "horror" },
                    { 7, "thriller", "thriller" },
                    { 8, "drama", "drama" },
                    { 9, "adventure", "adventure" },
                    { 10, "fantastic", "fantastic" },
                    { 11, "fantasy", "fantasy" },
                    { 12, "western", "western" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "Link", "Name" },
                values: new object[,]
                {
                    { 2, null, "france", "France" },
                    { 1, null, "usa", "USA" }
                });

            migrationBuilder.InsertData(
                table: "Qualities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "FullHD" },
                    { 2, "HD" },
                    { 3, "SD" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "21", "" },
                    { 2, "18", "" },
                    { 3, "16", "" },
                    { 4, "14", "" },
                    { 5, "12", "" },
                    { 6, "6", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Dislikes", "Duration", "Likes", "Release_at", "RestrictionId", "Slug", "Title" },
                values: new object[,]
                {
                    { 5, "Сидя на автобусной остановке, Форрест Гамп — не очень умный, но добрый и открытый парень — рассказывает случайным встречным историю своей необыкновенной жизни. С самого малолетства он страдал от заболевания ног, и соседские хулиганы дразнили мальчика, и в один прекрасный день Форрест открыл в себе невероятные способности к бегу.Подруга детства Дженни всегда его поддерживала и защищала, но вскоре дороги их разошлись", 46, 142, 89, new DateTime(1994, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "forrest-gump", "Forrest Gump" },
                    { 2, "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении, стал одним из самых необычных обитателей блока.", 1, 189, 23, new DateTime(1999, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "green-mile", "Green Mile" },
                    { 3, "Повелитель сил тьмы Саурон направляет свою бесчисленную армию под стены Минас-Тирита, крепости Последней Надежды. Он предвкушает близкую победу, но именно это мешает ему заметить две крохотные фигурки — хоббитов, приближающихся к Роковой Горе, где им предстоит уничтожить Кольцо Всевластья.", 16, 201, 111, new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "the-lord-of-the-rings-the-return-of-the-king", "The Lord of the Rings: The Return of the King" },
                    { 6, "Когда засуха, пыльные бури и вымирание растений приводят человечество к продовольственному кризису, коллектив исследователей и учёных отправляется сквозь червоточину (которая предположительно соединяет области пространства-времени через большое расстояние) в путешествие, чтобы превзойти прежние ограничения для космических путешествий человека и найти планету с подходящими для человечества условиями.", 7, 169, 77, new DateTime(2014, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "interstellar", "Interstellar" },
                    { 4, "Фильм рассказывает реальную историю загадочного Оскара Шиндлера, члена нацистской партии, преуспевающего фабриканта, спасшего во время Второй мировой войны почти 1200 евреев.", 50, 195, 78, new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "schindlers-list", "Schindler's List" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Email", "Login", "Password", "RoleId" },
                values: new object[] { 1, "", "admin@mail.ru", "admin", "12345678", 1 });

            migrationBuilder.InsertData(
                table: "CategoryMovie",
                columns: new[] { "CategoriesId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "HomePageSettings",
                columns: new[] { "MovieId", "Position" },
                values: new object[,]
                {
                    { 5, "season" },
                    { 2, "season" },
                    { 3, "season" },
                    { 4, "season" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMovie_MoviesId",
                table: "CategoryMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryMovie_MoviesId",
                table: "CountryMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieQuality_QualitiesId",
                table: "MovieQuality",
                column: "QualitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RestrictionId",
                table: "Movies",
                column: "RestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_MovieId_IsPoster",
                table: "Photos",
                columns: new[] { "MovieId", "IsPoster" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryMovie");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CountryMovie");

            migrationBuilder.DropTable(
                name: "HomePageSettings");

            migrationBuilder.DropTable(
                name: "MovieQuality");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Qualities");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Restrictions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
