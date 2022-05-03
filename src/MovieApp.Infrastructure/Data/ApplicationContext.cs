using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieApp.Core.Entities;
using MovieApp.Core.Entities.MovieAggregate;
using MovieApp.Core.Helpers;
using Microsoft.Extensions.Options;

namespace MovieApp.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Review> Reviews{ get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<HomePageSettings> HomePageSettings { get; set; }
        public DbSet<HomePagePosition> HomePagePositions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            // string adminEmail = _config["Secret:Admin:Email"];
            // string adminPassword = _config["Secret:Admin:Password"];
            // string adminLogin = _config["Secret:Admin:Login"];

            string adminEmail = "admin@mail.ru";
            string adminPassword = "12345678";
            string adminLogin = "admin";

            var adminRole = new Role { Id = 1, Name = adminRoleName };
            var userRole = new Role { Id = 2, Name = userRoleName };
            var adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id, Login = adminLogin };

            var restriction1 = new Restriction { Id = 1, Name = "21+", Link = 2};
            var restriction2 = new Restriction { Id = 2, Name = "18+" , Link = 18};
            var restriction3 = new Restriction { Id = 3, Name = "16+" , Link = 16};
            var restriction4 = new Restriction { Id = 4, Name = "14+" , Link = 14};
            var restriction5 = new Restriction { Id = 5, Name = "12+" , Link = 12};
            var restriction6 = new Restriction { Id = 6, Name = "6+" , Link = 6};

            var country1 = new Country {Id = 1, Name = "USA", Link = "usa" };
            var country2 = new Country {Id = 2, Name = "France", Link = "france" };

            var category1 = new Category { Id = 1, Name = "action", Link = "action" };
            var category2 = new Category { Id = 2, Name = "cartoons", Link = "cartoons" };
            var category3 = new Category { Id = 3, Name = "romantic", Link = "romantic" };
            var category4 = new Category { Id = 4, Name = "comedy", Link = "comedy" };
            var category5 = new Category { Id = 5, Name = "scientific", Link = "scientific" };
            var category6 = new Category { Id = 6, Name = "horror", Link = "horror" };
            var category7 = new Category { Id = 7, Name = "thriller", Link = "thriller" };
            var category8 = new Category { Id = 8, Name = "drama", Link = "drama" };
            var category9 = new Category { Id = 9, Name = "adventure", Link = "adventure" };
            var category10 = new Category { Id = 10, Name = "fantastic", Link = "fantastic" };
            var category11 = new Category { Id = 11, Name = "fantasy", Link = "fantasy" };
            var category12 = new Category { Id = 12, Name = "western", Link = "western" };


            var quality1 = new Quality { Id = 1, Name = "FullHD" };
            var quality2 = new Quality { Id = 2, Name = "HD" };
            var quality3 = new Quality { Id = 3, Name = "SD" };

            var movie1 = new Movie { Id = 2, Likes = 23, Dislikes = 1, RestrictionId = 2, Title = "Green Mile", Release = new DateTime(1999, 4, 18), Duration = 189, Slug = "green-mile", Description = "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении, стал одним из самых необычных обитателей блока." };
            var movie2 = new Movie { Id = 3, Likes = 111, Dislikes = 16, RestrictionId = 3, Title = "The Lord of the Rings: The Return of the King", Release = new DateTime(2003, 12, 1), Duration = 201, Slug = "the-lord-of-the-rings-the-return-of-the-king", Description = "Повелитель сил тьмы Саурон направляет свою бесчисленную армию под стены Минас-Тирита, крепости Последней Надежды. Он предвкушает близкую победу, но именно это мешает ему заметить две крохотные фигурки — хоббитов, приближающихся к Роковой Горе, где им предстоит уничтожить Кольцо Всевластья." };
            var movie3 = new Movie { Id = 4, Likes = 78, Dislikes = 50, RestrictionId = 5, Title = "Schindler's List", Release = new DateTime(1993, 11, 30), Duration = 195, Slug = "schindlers-list", Description = "Фильм рассказывает реальную историю загадочного Оскара Шиндлера, члена нацистской партии, преуспевающего фабриканта, спасшего во время Второй мировой войны почти 1200 евреев." };
            var movie4 = new Movie { Id = 5, Likes = 89, Dislikes = 46, RestrictionId = 1, Title = "Forrest Gump", Release = new DateTime(1994, 6, 23), Duration = 142, Slug = "forrest-gump", Description = "Сидя на автобусной остановке, Форрест Гамп — не очень умный, но добрый и открытый парень — рассказывает случайным встречным историю своей необыкновенной жизни. С самого малолетства он страдал от заболевания ног, и соседские хулиганы дразнили мальчика, и в один прекрасный день Форрест открыл в себе невероятные способности к бегу.Подруга детства Дженни всегда его поддерживала и защищала, но вскоре дороги их разошлись" };
            var movie5 = new Movie { Id = 6, Likes = 77, Dislikes = 7, RestrictionId = 4, Title = "Interstellar", Release = new DateTime(2014, 1, 26), Duration = 169, Slug = "interstellar", Description = "Когда засуха, пыльные бури и вымирание растений приводят человечество к продовольственному кризису, коллектив исследователей и учёных отправляется сквозь червоточину (которая предположительно соединяет области пространства-времени через большое расстояние) в путешествие, чтобы превзойти прежние ограничения для космических путешествий человека и найти планету с подходящими для человечества условиями." };
            
            
            
            modelBuilder.Entity<Photo>()
                .Property(b => b.IsPoster)
                .HasColumnName("IsPoster")
                .HasDefaultValueSql("false");

            modelBuilder.Entity<Country>().HasData(new Country[] {country1, country2 });
            modelBuilder.Entity<Restriction>().HasData(new Restriction[] { restriction1, restriction2, restriction3, restriction4, restriction5, restriction6 });
            modelBuilder.Entity<Category>().HasData(category1 ,category2 ,category3 ,category4 ,category5 ,category6 ,category7 ,category8 ,category9 ,category10 ,category11 ,category12);
            modelBuilder.Entity<Quality>().HasData(new Quality[] {quality1, quality2, quality3 });
            modelBuilder.Entity<Movie>().HasData(new Movie[] { movie1, movie2, movie3, movie4, movie5 });
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });

            modelBuilder.Entity<Movie>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Movies)
                .UsingEntity(j => j.ToTable("CategoryMovie").HasData(
                    new [] {
                        new { MoviesId = movie1.Id, CategoriesId = category1.Id },
                        new { MoviesId = movie1.Id, CategoriesId = category2.Id },
                    }
                ));
            
            
            modelBuilder.Entity<HomePagePosition>()
                .HasData(new[] {
                    new HomePagePosition { Name = "season", Id = 1},
                    new HomePagePosition { Name = "new", Id = 2},
                    new HomePagePosition { Name = "expected", Id = 3},
                });

            modelBuilder.Entity<HomePageSettings>()
                .HasKey(p => new { p.MovieId, p.PositionId });

             modelBuilder.Entity<HomePageSettings>()    
                .HasData(new HomePageSettings[] {
                    new HomePageSettings { MovieId = movie1.Id, PositionId = 1},
                    new HomePageSettings { MovieId = movie2.Id, PositionId = 1},
                    new HomePageSettings { MovieId = movie3.Id, PositionId = 1},
                    new HomePageSettings { MovieId = movie4.Id, PositionId = 1},
                });

            base.OnModelCreating(modelBuilder);
        }
    }

}
