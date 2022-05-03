using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.DTO;
using MovieApp.Core.DTO.MovieAggregate;
using MovieApp.Core.Entities.MovieAggregate;
using MovieApp.Core.Helpers;
using MovieApp.Core.Interfaces;
using MovieApp.Infrastructure.Data;

namespace MovieApp.Infrastructure.Services
{
    public class GetMoviesService
    {
        private IQueryable<Movie> _query;

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new Dictionary<string, IOrderBy>
            {
                {"release", new OrderBy<DateTime>(m => m.Release)},
                {"duration", new OrderBy<int>(m => m.Duration)},
                {"title", new OrderBy<string>(m => m.Title)}
                // { "rating", new OrderBy<int>(m => Math.Round(1.0 * m.Likes / (m.Likes + m.Dislikes) * 10, 1))}
                //{ "views",   new OrderBy<int>(m => m.) }
            };


        public GetMoviesService(IMovieRepository movieRepository)
        {
            _query = movieRepository.GetMovies();
        }

        public GetMoviesService SetYears(int minYear, int maxYear)
        {
            if (minYear != 0)
                _query = _query.Where(m => m.Release.Year >= minYear);

            if (maxYear != 0)
                _query = _query.Where(m => m.Release.Year <= maxYear);

            return this;
        }

        public GetMoviesService SetCategory(int categoryId)
        {
            if (categoryId != 0)
                _query = _query.Where(m => m.Categories.Any(g => g.Id == categoryId));

            return this;
        }

        //todo link should be int
        public GetMoviesService SetRestriction(int restrictionMinLink, int restrictionMaxLink)
        {
            if (restrictionMinLink != 0)
                _query = _query.Where(m => m.Restriction.Link >= restrictionMinLink);
            
            if (restrictionMaxLink != 0)
                _query = _query.Where(m => m.Restriction.Link >= restrictionMaxLink);

            return this;
        }

        public GetMoviesService SetRestriction(int restrictionId)
        {
            if (restrictionId != 0)
                _query = _query.Where(m => m.RestrictionId == restrictionId);

            return this;
        }

        public GetMoviesService SetQuality(int qualityId)
        {
            if (qualityId != 0)
                _query = _query.Where(m => m.Qualities.Any(q => q.Id == qualityId));

            return this;
        }

        public GetMoviesService SetCountry(int countryId)
        {
            if (countryId != 0)
                _query = _query.Where(m => m.Countries.Any(c => c.Id == countryId));

            return this;
        }

        public GetMoviesService SetOrder(string order, bool directionIsAsc = true)
        {
            if (!string.IsNullOrEmpty(order))
            {
                _query = directionIsAsc
                    ? Queryable.OrderBy(_query, OrderFunctions[order].Expression)
                    : Queryable.OrderByDescending(_query, OrderFunctions[order].Expression);    
            }
            
            return this;
        }

        public MoviesWithPagination GetWithPagination(int currentPage, int pageSize)
        {
            int skipAmount = pageSize * (currentPage - 1);
            int moviesCount = _query.Count();
            int pageCount = (int) Math.Ceiling((double) moviesCount / pageSize);

            var movies = _query.Select(m => new PosterMovie(
                    m.Id, m.Title, m.Slug, m.Photos, m.Description, m.Likes, m.Dislikes, m.Categories))
                .Skip(skipAmount)
                .Take(pageSize)
                .ToList();

            return new MoviesWithPagination()
            {
                Movies = movies,
                LastPage = pageCount,
                StartPosition = currentPage - (int) Math.Ceiling((double) pageSize / 2),
                CurrentPage = currentPage,
                EndPosition = currentPage + (int) Math.Ceiling((double) pageSize / 2)
            };
        }

        public List<PosterMovie> Get()
        {
            return _query.Select(m => new PosterMovie(
                m.Id, m.Title, m.Slug, m.Photos, m.Description, m.Likes, m.Dislikes, m.Categories)).ToList();
        }
    }
}