using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Infrastructure.Data.Migrations
{
    public partial class AddDataToMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Dislikes", "Duration", "Likes", "Release_at", "Slug", "Title" },
                values: new object[,]
                {
                    { 2, "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении, стал одним из самых необычных обитателей блока.", 1, 189, 23, new DateTime(1999, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "green-mile", "Green Mile" },
                    { 3, "Повелитель сил тьмы Саурон направляет свою бесчисленную армию под стены Минас-Тирита, крепости Последней Надежды. Он предвкушает близкую победу, но именно это мешает ему заметить две крохотные фигурки — хоббитов, приближающихся к Роковой Горе, где им предстоит уничтожить Кольцо Всевластья.", 16, 201, 111, new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the-lord-of-the-rings-the-return-of-the-king", "The Lord of the Rings: The Return of the King" },
                    { 4, "Фильм рассказывает реальную историю загадочного Оскара Шиндлера, члена нацистской партии, преуспевающего фабриканта, спасшего во время Второй мировой войны почти 1200 евреев.", 50, 195, 78, new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "schindlers-list", "Schindler's List" },
                    { 5, "Сидя на автобусной остановке, Форрест Гамп — не очень умный, но добрый и открытый парень — рассказывает случайным встречным историю своей необыкновенной жизни. С самого малолетства он страдал от заболевания ног, и соседские хулиганы дразнили мальчика, и в один прекрасный день Форрест открыл в себе невероятные способности к бегу.Подруга детства Дженни всегда его поддерживала и защищала, но вскоре дороги их разошлись", 46, 142, 89, new DateTime(1994, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "forrest-gump", "Forrest Gump" },
                    { 6, "Когда засуха, пыльные бури и вымирание растений приводят человечество к продовольственному кризису, коллектив исследователей и учёных отправляется сквозь червоточину (которая предположительно соединяет области пространства-времени через большое расстояние) в путешествие, чтобы превзойти прежние ограничения для космических путешествий человека и найти планету с подходящими для человечества условиями.", 7, 169, 77, new DateTime(2014, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "interstellar", "Interstellar" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
