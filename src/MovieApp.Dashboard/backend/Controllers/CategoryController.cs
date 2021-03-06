using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.DTO;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;

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
            var categories =  _categoryRepository.GetCategoriesDetails();
            return Ok(categories);
        }

        [HttpGet("{id:int}/movies")]
        public IActionResult GetCategoryMovies(int id)
        {
            //todo check this method in frontend page
            var movies = _movieRepository.GetMoviesByCategory(id);
            return Ok(movies);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCategory(CategoryDto category)
        {
            var updatedCategory = _categoryRepository.UpdateCategory(category);
            return Ok(updatedCategory);
        }

        public IActionResult AddCategory(CategoryDto category)
        {
            var addedCategory = _categoryRepository.AddCategory(category);

            return Ok(addedCategory);
        }
    }
}