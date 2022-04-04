using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.Application.Entities.MovieAggregate;
using MovieApp.Application.DTO;
using MovieApp.Application.DTO.MovieAggregate;

namespace MovieApp.Application.Interfaces
{
    public interface IMovieService
    {
        MovieDto GetMovie(int id);
        Task<Movie> UpdateMovie(UpdateMovieDto request);
        Task<List<CategoryDto>> RemoveCategory(int movieId, int catId);
    }
}