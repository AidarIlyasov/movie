using System;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;

namespace MovieApp.Web.Controllers
{
    public class MoviePageController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public MoviePageController(IMovieRepository repository)
        {
            _movieRepository = repository;
        }
        
        [HttpGet("watch/{slug:minlength(3)}")]
        public IActionResult Index(string slug)
        {
            //var movie = db.Movies.Join(db.Qualities,
            //    m => m.Qualities,
            //    q => q.Id,
            //    (m, q) => new { MovieId = m.Id, m.Title, QualityId = q.Id, q.Name }).First();

            //var movie = (from m in db.Movies
            //             join q in db.Qualities on m.Qualities.Id equals q.Id
            //             select new { m.Id, m.Title, q.Name }).First();

            //var movie = db.Movies.Include(q => q.Qualities)
            //                .Include(g => g.Genres).First();

            //string qualities = "";
            //    movie.Qualities.ForEach(q => qualities += q.Name + ",");

            //string genres = "";
            //    movie.Genres.ForEach(g => genres+= g.Name + ",");

            var movie = _movieRepository.GetMovie(slug);
            
            return View(movie);
        }
    }
}
