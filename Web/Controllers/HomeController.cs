#nullable enable
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;
using MovieApp.Web.ViewModels;
using MovieApp.Infrastructure.Services;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileManager _fileManager;
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieFiltersService _movieFiltersService;

        public HomeController(
            IFileManager fileManager,
            IMovieRepository movieRepository,
            IMovieFiltersService movieFiltersService
        )
        {
            _fileManager = fileManager;
            _movieRepository = movieRepository;
            _movieFiltersService = movieFiltersService;
        }
        
        [HttpGet("/")]
        public IActionResult Index(string? search = null)
        {
            if (string.IsNullOrEmpty(search)) return View();

            var movies = _movieRepository
                .GetMoviesBySearch(search.ToLower());

            var model = new SearchResultViewModel
            {
                FilterOptions = _movieFiltersService.GetFilters(),
                Movies = movies,
                BreadcrumbTitle = "Search Results",
            };

            return View("~/Views/Category/SearchResult.cshtml", model);
        }

        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet("Pricing")]
        public IActionResult Pricing()
        {
            return View();
        }
        
        [HttpGet("Help")]
        public IActionResult Help()
        {
            return View();
        }
        
        [HttpGet("About")]
        public IActionResult About()
        {
            return View();
        }

        // [HttpGet("/Image/{image}")]
        // public IActionResult Image(string image)
        // {
        //     var mime = image.Substring(image.LastIndexOf('.') + 1);
        //     return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        // }
    }
}
