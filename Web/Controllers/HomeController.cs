#nullable enable
using System;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;
using MovieApp.Web.ViewModels;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileManager _fileManager;
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(
            IFileManager fileManager,
            IMovieRepository movieRepository,
            ICategoryRepository categoryRepository
        )
        {
            _fileManager = fileManager;
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
        }
        
        [HttpGet("/")]
        public IActionResult Index(string? search = null)
        {
            if (String.IsNullOrEmpty(search)) return View();
            ViewBag.Genres = _categoryRepository.GetCategories();
                
            var movies = _movieRepository.GetMoviesBySearch(search);
            
            var model = new SearchResultViewModel()
            {
                Movies = movies,
                BreadcrumbTitle = "Search Results",
                FilterSelectedGenre = _categoryRepository.GetCategory(1).Name
            };

            return View("~/Views/Catalog/SearchResult.cshtml", model);
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

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}
