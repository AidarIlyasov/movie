using System;
using MovieApp.Application.DTO;
using System.Collections.Generic;
using System.Linq;

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
