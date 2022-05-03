using System.ComponentModel.DataAnnotations;
using MovieApp.Core.Entities.MovieAggregate;

namespace MovieApp.Core.Entities
{
    public class HomePageSettings
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public int PositionId { get; set; }
    }
}