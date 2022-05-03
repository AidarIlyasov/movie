using System.Collections.Generic;
using MovieApp.Core.DTO;
using MovieApp.Core.DTO.MovieAggregate.Filters;

namespace MovieApp.Web.ViewModels
{
    public class SearchResultViewModel
    {
        public FilterOptionsDto FilterOptions { get; set; }
        public List<PosterMovie> Movies { get; set; }
        public string BreadcrumbTitle { get; set; }
    }
}