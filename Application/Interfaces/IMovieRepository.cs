using System.Collections.Generic;
using System.Linq;
using MovieApp.Application.DTO;
using MovieApp.Application.DTO.MovieAggregate;
using System.Threading.Tasks;
using MovieApp.Application.Entities.MovieAggregate;


namespace MovieApp.Application.Interfaces
{
     public interface IMovieRepository
     {
         
         Movie GetMovieBySlug(string slug);

         Movie GetMovieById(int id);

         PosterMovie GetPosterMovie(int id);
         
         List<PosterMovie> GetMoviesBySearch(string searchString);

         IQueryable<Movie> GetMovies();

         List<ThinMovieDto> GetMoviesByCategory(int genreId);

         List<PosterMovie> GetSeasonMovies();
     }
}