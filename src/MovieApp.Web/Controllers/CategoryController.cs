using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Interfaces;
using MovieApp.Web.ViewModels;
using System.Linq;
using MovieApp.Core.Helpers;
using MovieApp.Infrastructure.Services;

namespace MovieApp.Web.Controllers
{
    [Route("/categories/")]
    public class CategoryController : Controller
    {
        private readonly IMovieRepository _moveRepository;
        private readonly IMovieFiltersService _movieFiltersService;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(
            IMovieRepository movieRepository,
            ICategoryRepository categoryRepository,
            IMovieFiltersService movieFiltersService
            )
        {
            _moveRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _movieFiltersService = movieFiltersService;
        }

        [HttpGet("{name:alpha:minlength(3)}")]
        public IActionResult GetCategoryMovies(string name)
        {
            var category = _categoryRepository.GetCategory(name);
            
            var movies = new GetMoviesService(_moveRepository)
                .SetCategory(category.Id)
                .SetOrder("duration", true)
                .GetWithPagination(1, 5);

            var model = new MoviesViewModel
            {
                BreadcrumbTitle = WordRegister.FirstCharToUpper(name),
                Link = name,
                Movies = movies.Movies,
                FilterOptions = _movieFiltersService.GetFilters()
            };

            return View("Index", model);
        }
    }
}