using MovieApp.Core.DTO;

namespace MovieApp.Core.Interfaces
{
    public interface IMovieFiltersService
    {
        FilterOptionsDto GetFilters();
    }
}