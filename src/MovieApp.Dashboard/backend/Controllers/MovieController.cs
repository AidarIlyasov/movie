using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Interfaces;
using MovieApp.Core.DTO.MovieAggregate;
using MovieApp.Infrastructure.Services;


namespace MovieApp.backend.Controllers
{
    [ApiController]
    [Route("/dashboard/movies/")]
    public class MovieController: ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieService _movieService;

        public MovieController(IMovieRepository movieRepository, IMovieService movieService)
        {
            _movieRepository = movieRepository;
            _movieService = movieService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _movieRepository.GetPosterMovie(id);
            return Ok(movie);
        }

        [HttpGet("{id:int}/edit")]
        public IActionResult EditMovie(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return Ok(movie);
        }

        [HttpGet("season")]
        public IActionResult GetSeasonMovies()
        {
            var movies = _movieRepository.GetSeasonMovies();
            return Ok(movies);
        }

        [HttpGet("filters")]
        public IActionResult GetMovies(int category = 0, int restriction = 0, int country = 0, int quality = 0, string order = "", bool asc = true)
        {
            var movies = new GetMoviesService(_movieRepository)
                .SetCategory(category)
                .SetRestriction(restriction)
                .SetQuality(quality)
                .SetCountry(country)
                .SetOrder(order, asc)
                .GetWithPagination(1, 5);
            
            return Ok(movies);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMovie([FromForm]UpdateMovieDto request)
        {
            var updatedMovie = await _movieService.UpdateMovie(request);

            return Ok(updatedMovie.Title);
        }

        [HttpDelete("{movieId:int}/categories/{catId:int}")]
        public async Task<IActionResult> RemoveCategoryFromMovie(int movieId, int catId)
        {
            var categories = await _movieService.RemoveCategory(movieId, catId);
            return Ok(categories);
        }
    }
}