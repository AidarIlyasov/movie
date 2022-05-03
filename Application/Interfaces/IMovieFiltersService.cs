using MovieApp.Core.DTO;
using MovieApp.Core.DTO.MovieAggregate.Filters;

namespace MovieApp.Core.Interfaces
{
    public interface IMovieFiltersService
    {
        FilterOptionsDto GetFilters();
    }
}