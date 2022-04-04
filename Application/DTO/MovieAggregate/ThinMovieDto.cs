using MovieApp.Application.Entities;
using System.Collections.Generic;

namespace MovieApp.Application.DTO.MovieAggregate
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