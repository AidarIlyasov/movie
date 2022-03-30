using System.Collections.Generic;
using MovieApp.Application.DTO;

namespace MovieApp.Web.ViewModels
{
    public class SearchResultViewModel
    {
        public List<PosterMovie> Movies { get; set; }
        public string BreadcrumbTitle { get; set; }
        
        public string FilterSelectedGenre { get; set; }
    }
}