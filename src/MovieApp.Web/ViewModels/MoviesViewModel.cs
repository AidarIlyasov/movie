using System;
using MovieApp.Core.DTO;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Core.DTO.MovieAggregate.Filters;

namespace MovieApp.Web.ViewModels
{
    public class MoviesViewModel
    {
        public string Link { get; set; }
        public string BreadcrumbTitle { get; set; }
        public List<PosterMovie> Movies { get; set; }
        public FilterOptionsDto FilterOptions { get; set; }
    }
}
