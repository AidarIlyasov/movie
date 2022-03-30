using MovieApp.Application.Entities.MovieAggregate;

namespace MovieApp.Application.Entities
{
    public class CountryMovie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    } 
}