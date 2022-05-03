using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.Core.Entities.MovieAggregate;
using MovieApp.Core.DTO;
using MovieApp.Core.DTO.MovieAggregate;

namespace MovieApp.Core.Interfaces
{
    public interface IMovieService
    {
        MovieDto GetMovieById(int id);
        MovieDto GetMovieBySlug(string slug);
        Task<Movie> UpdateMovie(UpdateMovieDto request);
        Task<List<CategoryDto>> RemoveCategory(int movieId, int catId);
    }
}