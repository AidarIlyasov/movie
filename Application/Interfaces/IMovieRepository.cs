using System.Collections.Generic;
using MovieApp.Application.DTO;
using System.Threading.Tasks;
using MovieApp.Application.Entities.MovieAggregate;


namespace MovieApp.Application.Interfaces
{
     public interface IMovieRepository
     {
         
         MovieDto GetMovie(string slug);

         Movie GetMovie(int id);

         PosterMovie GetPosterMovie(int id);
         
         List<PosterMovie> GetMoviesBySearch(string searchString);

         List<PosterMovie> GetMovies(int? genreId, string order, int currentPage, bool directionIsAsc = true);
         
         List<ThinMovieDto> GetMoviesByGenre(int genreId);

         List<PosterMovie> GetSeasonMovies();

         Movie GetMovieByIdTest(int id);
         int UpdateMovie(UpdateMovieDto movie);
         // void AddMovie(Movie movie);
         // void RemoveMovie(int Id);
     }
}