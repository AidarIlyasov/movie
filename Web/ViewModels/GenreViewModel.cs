using System;
using MovieApp.Application.DTO;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.ViewModels
{
    public class MoviesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string BreadcrumbTitle { get; set; }
        public List<PosterMovie> Movies { get; set; }
        public object FilterSelectedCategory { get; set; }
    }
}
