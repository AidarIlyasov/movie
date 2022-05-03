using System.Collections.Generic;
using MovieApp.Core.DTO;
using MovieApp.Core.DTO.MovieAggregate;

namespace MovieApp.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string Title = "Home Page title";
        public List<PosterMovie> SeasonMovies = new List<PosterMovie>();
        public List<MovieDto> NewMovies = new List<MovieDto>();
        public List<ThinMovieDto> ExpectedPremiereMovies = new List<ThinMovieDto>();
    }
}