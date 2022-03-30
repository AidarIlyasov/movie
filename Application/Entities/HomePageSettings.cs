using MovieApp.Application.Entities.MovieAggregate;

namespace MovieApp.Application.Entities
{
    public class HomePageSettings
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string Position { get; set; } 
    }
}