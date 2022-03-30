using MovieApp.Application.Entities.MovieAggregate;
using MovieApp.Application.DTO;

namespace MovieApp.Application.Interfaces
{
    public interface IMovieService
    {
        MovieDto GetMovie(int id);
        Movie UpdateMovie(UpdateMovieDto request);
    }
}