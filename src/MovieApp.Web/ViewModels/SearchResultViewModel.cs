using System.Collections.Generic;
using MovieApp.Core.DTO;

namespace MovieApp.Web.ViewModels
{
    public class SearchResultViewModel
    {
        public FilterOptionsDto FilterOptions { get; set; }
        public List<PosterMovie> Movies { get; set; }
        public string BreadcrumbTitle { get; set; }
    }
}