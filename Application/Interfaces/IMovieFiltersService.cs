using MovieApp.Application.DTO;

namespace MovieApp.Application.Interfaces
{
    public interface IMovieFiltersService
    {
        FilterOptionsDto GetFilters();
    }
}