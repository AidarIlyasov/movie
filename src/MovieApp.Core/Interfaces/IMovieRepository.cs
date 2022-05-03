using System.Collections.Generic;
using System.Linq;
using MovieApp.Core.DTO;
using MovieApp.Core.DTO.MovieAggregate;
using System.Threading.Tasks;
using MovieApp.Core.Entities.MovieAggregate;


namespace MovieApp.Core.Interfaces
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
         List<MovieDto> GetNewMovies();
         List<ThinMovieDto> GetExpectedPremiereMovies();
     }
}