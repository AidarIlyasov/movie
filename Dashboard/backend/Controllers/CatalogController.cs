using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Entities;
using MovieApp.Application.Interfaces;

namespace MovieApp.backend.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMovieRepository _movieRepository;

        public CatalogController(ICategoryRepository categoryRepository, IMovieRepository movieRepository)
        {
            _categoryRepository = categoryRepository;
            _movieRepository = movieRepository;
        }

        [HttpGet("/dashboard/categories/")]
        public IActionResult GetCategories()
        {
            var categories =  _categoryRepository.GetCategories();
            return Ok(categories);
        }

        [HttpGet("/dashboard/categories/{id:int}/movies")]
        public IActionResult GetCategoryMovies(int id)
        {
            var movies = _movieRepository.GetMoviesByGenre(id);
            return Ok(movies);
        }
    }

    // public class Genre {
    //     public int Id {get; set;}
    //     public string Name {get; set;}
    //     public int Count {get; set;}
    // }
}