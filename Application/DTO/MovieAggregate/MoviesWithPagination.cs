using System.Collections.Generic;

namespace MovieApp.Application.DTO.MovieAggregate
{
    public class MoviesWithPagination
    {
        public List<PosterMovie> Movies { get; set; } = new List<PosterMovie>();
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
    }
}