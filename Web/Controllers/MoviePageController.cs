using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;

namespace MovieApp.Web.Controllers
{
    public class MoviePageController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviePageController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet("watch/{slug:minlength(3)}")]
        public IActionResult Index(string slug)
        {
            var movie = _movieService.GetMovieBySlug(slug);;
            
            return View(movie);
        }
    }
}
