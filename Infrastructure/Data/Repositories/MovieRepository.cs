using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using MovieApp.Application.Interfaces;
using MovieApp.Application.DTO;
using MovieApp.Application.DTO.MovieAggregate;
using MovieApp.Application.Entities.MovieAggregate;
using MovieApp.Application.Entities;
using MovieApp.Application.Helpers;
using System.Threading.Tasks;
using System.Text;

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
                .Select(m => new ThinMovieDto {
                    Id = m.Id,
                    Slug = m.Slug,
                    Title = m.Title,
                    Photo = m.Photos.FirstOrDefault(p => p.IsPoster),
                    Categories = m.Categories.Select(c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Link = c.Link
                    }).ToList()
                })
                .ToList();
        }

        public List<PosterMovie> GetSeasonMovies()
        {
            var query = _context.HomePageSettings
                .AsNoTracking()
                .Include(x => x.Movie)
                .Where(x => x.Position == "season");

            return query.Select(m => new PosterMovie(
                m.Movie.Id, m.Movie.Title, m.Movie.Slug, m.Movie.Photos, m.Movie.Description, m.Movie.Likes, m.Movie.Dislikes, m.Movie.Categories)).ToList();    
        }
    }
}