using System.Collections.Generic;
using MovieApp.Application.DTO;
using MovieApp.Application.DTO.MovieAggregate;
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
         
         List<ThinMovieDto> GetMoviesByCategory(int genreId);

         List<PosterMovie> GetSeasonMovies();
         // void AddMovie(Movie movie);
         // void RemoveMovie(int Id);
     }
}