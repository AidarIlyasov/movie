using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.DTO;
using MovieApp.Application.Entities;
using MovieApp.Application.Interfaces;

namespace MovieApp.backend.Controllers
{
    [ApiController]
    [Route("/dashboard/categories/")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMovieRepository _movieRepository;

        public CategoryController(ICategoryRepository categoryRepository, IMovieRepository movieRepository)
        {
            _categoryRepository = categoryRepository;
            _movieRepository = movieRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            return Ok();
        }

        [HttpGet("")]
        public IActionResult GetCategories()
        {
            var categories =  _categoryRepository.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id:int}/movies")]
        public IActionResult GetCategoryMovies(int id)
        {
            var movies = _movieRepository.GetMoviesByCategory(id);
            return Ok(movies);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCategory(CategoryDto category)
        {
            var updatedCategory = _categoryRepository.UpdateCategory(category);
            return Ok(updatedCategory);
        }
    }
}