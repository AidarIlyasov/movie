using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;
using MovieApp.Application.DTO;
using MovieApp.Infrastructure.Services;


namespace MovieApp.backend.Controllers
{
    [ApiController]
    public class MovieController: ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieService _movieService;

        public MovieController(IMovieRepository movieRepository, IMovieService movieService)
        {
            _movieRepository = movieRepository;
            _movieService = movieService;
        }

        [HttpGet("/dashboard/movies/{id:int}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _movieRepository.GetPosterMovie(id);
            return Ok(movie);
        }

        [HttpGet("/dashboard/movies/{id:int}/edit")]
        public IActionResult EditMovie(int id)
        {
            var movie = _movieService.GetMovie(id);
            return Ok(movie);
        }

        [HttpGet("/dashboard/movies/season/")]
        public IActionResult GetSeasonMovies()
        {
            var movies = _movieRepository.GetSeasonMovies();
            return Ok(movies);
        }

        [HttpPost("/dashboard/movies/{id:int}")]
        public IActionResult UpdateMovie([FromForm]UpdateMovieDto request)
        {

        //    var updatedMovie = _movieRepository.UpdateMovie(request);
        //    var result = new MovieDto (id: updatedMovie.Id);
            // await _movieRepository.UpdateMovie(movie);
            var updatedMovie = _movieService.UpdateMovie(request);

            return Ok(updatedMovie.Countries);
        }
    }
}