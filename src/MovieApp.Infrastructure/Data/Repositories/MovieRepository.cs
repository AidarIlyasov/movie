using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using MovieApp.Core.Interfaces;
using MovieApp.Core.DTO;
using MovieApp.Core.DTO.MovieAggregate;
using MovieApp.Core.Entities.MovieAggregate;
using MovieApp.Core.Enums;
using MovieApp.Core.Helpers;
using System.Threading.Tasks;
using System.Text;
using MovieApp.Core.Entities;

namespace MovieApp.Infrastructure.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        
        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new Dictionary<string, IOrderBy>
            {
                { "release", new OrderBy<DateTime>(m => m.Release) },
                { "duration",  new OrderBy<int>(m => m.Duration) },
                { "alphabet", new OrderBy<string>(m => m.Title)}
                // { "raiting", new OrderBy<int>(m => Math.Round(1.0 * m.Likes / (m.Likes + m.Dislikes) * 10, 1))}
                //{ "views",   new OrderBy<int>(m => m.) }
            };

        public MovieRepository(
            ApplicationContext context,
            IMapper mapper,
            IFileManager fileManager
        )
        {
            _context = context;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        
        public Movie GetMovieBySlug(string slug)
        {
            return GetMovie()
                    .FirstOrDefault(x => x.Slug == slug);
        }

        public Movie GetMovieById(int id)
        {
            return GetMovie()
                .FirstOrDefault(x => x.Id == id);
        }

        private IQueryable<Movie> GetMovie()
        {
            return _context.Movies
                    .Include(c => c.Categories)
                    .Include(c => c.Countries)
                    .Include(p => p.Photos)
                    .Include(r => r.Restriction)
                    .Include(q => q.Qualities)
                    .AsQueryable();
        }

        public PosterMovie GetPosterMovie(int id)
        {
            return _context.Movies
                    .Where(m => m.Id == id)
                    .Select(m => new PosterMovie(
                        m.Id, m.Title, m.Slug, m.Photos, m.Description, m.Likes, m.Dislikes, m.Categories))
                    .Single();
        }

        public List<PosterMovie> GetMoviesBySearch(string searchString)
        {
            return _context.Movies.AsNoTracking()
                .Where(m => EF.Functions.Like(m.Title.ToLower(), $"%{searchString}%")
                            ||  EF.Functions.Like(m.Description.ToLower(), $"%{searchString}%"))
                .Select(m => new PosterMovie(
                    m.Id, m.Title, m.Slug, m.Photos, m.Description, m.Likes, m.Dislikes, m.Categories))
                .ToList();
        }


        public IQueryable<Movie> GetMovies()
        {
            return _context.Movies
                    .AsNoTracking()
                    .AsQueryable();
        }

        public List<ThinMovieDto> GetMoviesByCategory(int catId)
        {
            return _context.Movies
                .Where(m => m.Categories.Any(g => g.Id == catId))
                .Select(m => new ThinMovieDto(m.Id, m.Title, m.Slug, m.Categories, m.Photos, m.Likes, m.Dislikes))
                .ToList();
        }

        public List<PosterMovie> GetSeasonMovies()
        {
            var query = _context.HomePageSettings
                .Include(x => x.Movie)
                .Where(x => x.PositionId == (int)HomePagePositionsEnum.Season);

            return query.Select(m => new PosterMovie(
                m.Movie.Id, m.Movie.Title, m.Movie.Slug, m.Movie.Photos, m.Movie.Description, m.Movie.Likes, m.Movie.Dislikes, m.Movie.Categories)).ToList();    
        }

        public List<MovieDto> GetNewMovies()
        {
            var query=  _context.HomePageSettings
                .Include(x => x.Movie)
                .ThenInclude(r => r.Restriction)
                .Where(x => x.PositionId == (int)HomePagePositionsEnum.New);

            var rest = query.Select(x => x.Movie.Restriction);
            
            return query.Select(x => new MovieDto
            {
                Id = x.MovieId,
                Title = x.Movie.Title,
                Slug = x.Movie.Slug,
                Description = x.Movie.Description,
                Poster = x.Movie.Photos.SingleOrDefault(p => p.IsPoster).Name.ToString(),
                Categories = x.Movie.Categories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Link = c.Link
                }).ToList(),
                Qualities = x.Movie.Qualities.ToList(),
                Restriction = x.Movie.Restriction,
                Rating = Math.Round(1.0 * x.Movie.Likes / (x.Movie.Likes + x.Movie.Dislikes) * 10, 1)
            }).ToList();
        }

        public List<ThinMovieDto> GetExpectedPremiereMovies()
        {
            var query = _context.HomePageSettings
                .Include(x => x.Movie)
                .Where(x => x.PositionId == (int)HomePagePositionsEnum.Expected);

            return query.Select(x => new ThinMovieDto(x.Movie.Id, x.Movie.Title, x.Movie.Slug, x.Movie.Categories, x.Movie.Photos, x.Movie.Likes, x.Movie.Dislikes))
                .ToList();
        }
    }
}