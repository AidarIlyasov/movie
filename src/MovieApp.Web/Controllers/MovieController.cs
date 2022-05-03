using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Interfaces;
using MovieApp.Infrastructure.Services;
using MovieApp.Core.DTO.MovieAggregate.Filters;

namespace MovieApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieService movieService, IMovieRepository movieRepository)
        {
            _movieService = movieService;
            _movieRepository = movieRepository;
        }
        
        [HttpGet("watch/{slug:minlength(3)}")]
        public IActionResult Index(string slug)
        {
            var movie = _movieService.GetMovieBySlug(slug);;
            
            return View(movie);
        }
        
        public IActionResult GetFilteredMovies([FromForm] FilterRequestDto filterRequest)
        {
            var movies = new GetMoviesService(_movieRepository)
                .SetCategory(filterRequest.Category)
                .SetRestriction(filterRequest.RestrictionMin, filterRequest.RestrictionMax)
                .SetQuality(filterRequest.Quality)
                .SetCountry(filterRequest.Country)
                .SetYears(minYear: filterRequest.YearMin, maxYear: filterRequest.YearMax)
                .GetWithPagination(1, 5);

            return Ok(movies);
        }
    }
}
