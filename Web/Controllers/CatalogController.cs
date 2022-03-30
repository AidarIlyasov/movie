using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;
using MovieApp.Web.ViewModels;
using System.Linq;
using MovieApp.Application.Helpers;

namespace MovieApp.Web.Controllers
{
    [Route("[controller]")]
    public class CatalogController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMovieRepository _moveRepository;
            
        public CatalogController(
            ICategoryRepository categoryRepository,
            IMovieRepository movieRepository
            )
        {
            _categoryRepository = categoryRepository;
            _moveRepository = movieRepository;
        }

        [HttpGet]
        [Route("{name:alpha:minlength(3)}")]
        public IActionResult GetCategoryMovies(string name)
        {
            var categoriesList = _categoryRepository.GetCategories();
                ViewBag.Genres = categoriesList;

            var category = _categoryRepository.GetCategory(name);
            var movies = _moveRepository.GetMovies(category.Id, "duration", 1);

            var model = new MoviesViewModel()
            {
                Name = WordRegister.FirstCharToUpper(name),
                BreadcrumbTitle = WordRegister.FirstCharToUpper(name),
                FilterSelectedCategory = categoriesList.First().Name,
                Link = name,
                Movies = movies
            };

            return View("Category", model);
        }
    }
}