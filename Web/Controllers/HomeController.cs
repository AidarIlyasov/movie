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
            if (string.IsNullOrEmpty(search)) 
                return View(GetHomePageResult());

            return View("~/Views/Category/SearchResult.cshtml", GetSearchResult(search));
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

        private HomePageViewModel GetHomePageResult()
        {
            return new HomePageViewModel
            {
                SeasonMovies = _movieRepository.GetSeasonMovies(),
                NewMovies = _movieRepository.GetNewMovies(),
                ExpectedPremiereMovies = _movieRepository.GetExpectedPremiereMovies()
            };
        }

        private MoviesViewModel GetSearchResult(string search)
        {
            var movies = _movieRepository
                .GetMoviesBySearch(search.ToLower());
            
            return new MoviesViewModel
            {
                BreadcrumbTitle = "Search Results",
                // Link = name,
                Movies = movies,
                FilterOptions = _movieFiltersService.GetFilters()
            };
            
        }

        // [HttpGet("/Image/{image}")]
        // public IActionResult Image(string image)
        // {
        //     var mime = image.Substring(image.LastIndexOf('.') + 1);
        //     return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        // }
    }
}
