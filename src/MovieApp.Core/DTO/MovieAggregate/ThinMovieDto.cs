using MovieApp.Core.Entities;
using System.Collections.Generic;

namespace MovieApp.Core.DTO.MovieAggregate
{
    public class ThinMovieDto
    {
        public int Id { get; set; }
        public Photo Photo { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}