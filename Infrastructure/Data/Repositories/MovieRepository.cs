using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using MovieApp.Application.Interfaces;
using MovieApp.Application.DTO;
using MovieApp.Application.Entities.MovieAggregate;
using MovieApp.Application.Entities;
using MovieApp.Application.Helpers;
using System.Threading.Tasks;
using System.Text;

namespace MovieApp.Infrastructure.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationContext db;
        private readonly IMapper _mapper;

        private readonly IFileManager _fileManager;
        
        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new Dictionary<string, IOrderBy>
            {
                { "release", new OrderBy<DateTime>(m => m.Release_at) },
                { "duration",  new OrderBy<int>(m => m.Duration) },
                // { "raiting", new OrderBy<int>(m => Math.Round(1.0 * m.Likes / (m.Likes + m.Dislikes) * 10, 1))}
                //{ "views",   new OrderBy<int>(m => m.) }
            };

        public MovieRepository(
            ApplicationContext context,
            IMapper mapper,
            IFileManager fileManager
        )
        {
            db = context;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        
        public MovieDto GetMovie(string slug)
        {
            return RetrieveSingleMovie()
                    .FirstOrDefault(x => x.Slug == slug);
        }

        public Movie GetMovieByIdTest(int id)
        {
            return db.Movies
                .AsNoTracking()
                .Include(c => c.Categories)
                .FirstOrDefault(x => x.Id == id);
        }

        public Movie GetMovie(int id)
        {
            return db.Movies
                    .Include(c => c.Categories)
                    .Include(c => c.Countries)
                    .Include(p => p.Photos)
                    .Include(r => r.Restriction)
                    .Include(q => q.Qualities)
                    .FirstOrDefault(x => x.Id == id);
        }

        private IQueryable<MovieDto> RetrieveSingleMovie()
        {
            return db.Movies
            .AsNoTracking()
            .Select(x => new MovieDto {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Qualities = x.Qualities.ToList(),
                Categories = x.Categories.Select(category => CategoryDto.FromCategory(category)).ToList(),
                Photos = x.Photos.Select(photo => PhotoDto.FromPhoto(photo)).ToList(),
                Comments = x.Comments.Select(comment => _mapper.Map<CommentDto>(comment)),
                Reviews = x.Reviews.Select(review => _mapper.Map<ReviewDto>(review)),
                //Countries = x.Countries.ToList(),
                Duration = x.Duration,
                Restriction = x.Restriction,
                Release = x.Release_at.ToString("yyyy-MM-dd"),
                Slug = x.Slug,
                // Raiting = Math.Round(1.0 * x.Likes / (x.Likes + x.Dislikes) * 10, 1)
                Raiting = 9.6
            }).AsQueryable();
        }

        public PosterMovie GetPosterMovie(int id)
        {
            return db.Movies
                    .Where(m => m.Id == id)
                    .Select(m => new PosterMovie(
                        m.Id, m.Title, m.Slug, m.Photos, m.Description, m.Likes, m.Dislikes, m.Categories))
                    .Single();
        }

        public List<PosterMovie> GetMoviesBySearch(string searchString)
        {
            return db.Movies.AsNoTracking()
                .Where(m => EF.Functions.Like(m.Title, $"%{searchString}%")
                            ||  EF.Functions.Like(m.Description, $"%{searchString}%"))
                .Select(m => new PosterMovie(
                    m.Id, m.Title, m.Slug, m.Photos, m.Description, m.Likes, m.Dislikes, m.Categories))
                .ToList();
        }

        public List<PosterMovie> GetMovies(int? genreId, string order = "", int currentPage = 1, bool directionIsAsc = true)
        {
            var query = db.Movies.AsNoTracking().AsQueryable();
            int pageSize = 5;
            int skipAmount = pageSize * (currentPage * 1);

            if (genreId != null)
            {
                query = query.Where(m => m.Categories.Any(g => g.Id == genreId));
            }

            if (!String.IsNullOrEmpty(order))
            {
                query = directionIsAsc
                    ? Queryable.OrderBy(query, OrderFunctions[order].Expression)
                    : Queryable.OrderByDescending(query, OrderFunctions[order].Expression);
            }
            
            int moviesCount = query.Count();
            int pageCount = (int)Math.Ceiling((double)moviesCount / pageSize);

            return query.Select(m => new PosterMovie(
                m.Id, m.Title, m.Slug, m.Photos, m.Description, m.Likes, m.Dislikes, m.Categories)).ToList();
        }

        public List<ThinMovieDto> GetMoviesByGenre(int genreId)
        {
            return db.Movies
                .Where(m => m.Categories.Any(g => g.Id == genreId))
                .Select(m => new ThinMovieDto {
                    Id = m.Id,
                    Slug = m.Slug,
                    Title = m.Title,
                    Photo = m.Photos.FirstOrDefault(p => p.IsPoster)
                })
                .ToList();
        }

        public List<PosterMovie> GetSeasonMovies()
        {
            var query = db.HomePageSettings
                .AsNoTracking()
                .Include(x => x.Movie)
                .Where(x => x.Position == "season");

            return query.Select(m => new PosterMovie(
                m.Movie.Id, m.Movie.Title, m.Movie.Slug, m.Movie.Photos, m.Movie.Description, m.Movie.Likes, m.Movie.Dislikes, m.Movie.Categories)).ToList();    
        }
        public int UpdateMovie(UpdateMovieDto request)
        {

                // foreach (PhotoDto photo in request.Photos)
                // {
                //     if (photo.Image != null)
                //         photo.Name = await _fileManager.SaveImage(photo.Image, request.Id.ToString());
                // }

                // var movie = new Movie
                // {
                //     Id = request.Id,
                //     Title = request.Title,
                //     Slug = request.Slug,
                //     Description = request.Description,
                //     // Categories = request.Categories.Select(x => new Category {
                //     //     Id = x.Id,
                //     //     Name = x.Name,
                //     //     Link = x.Link
                //     // }).ToList(),
                //     // Qualities = request.Qualities.Select(q => new Quality {
                //     //     Id = q.Id,
                //     //     Name = q.Name
                //     // }),
                //     // Restriction = new Restriction {
                //     //     Id = request.Restriction.Id,
                //     //     Type = request.Restriction.Type,
                //     //     Name = request.Restriction.Name,
                //     // },
                //     Duration = (int)request.Duration * 60,
                //     Release_at = DateTime.Parse(request.Release),
                //     // Countries = request.Countries.Select(c => new Country {
                //     //     Id = c.Id,
                //     //     Name = c.Name
                //     // }),
                //     Photos = request.Photos.Select(p => new Photo {
                //         Id = p.Id,
                //         Name = p.Name
                //     }).ToList()
                // };


                // try {
                //     db.Movies.Update(movie);
                // }
                // catch (Exception e)
                // {
                //     throw new Exception(e.Message);
                // }
                
                // return await db.SaveChangesAsync();
                return 132;
        }

        //
        // public void AddMovie(Movie movie)
        // {
        //     
        // }
        //
        //
        // public void RemoveMovie(int Id)
        // {
        //     
        // }
    }
}