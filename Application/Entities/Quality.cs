using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieApp.Application.Entities.MovieAggregate;

namespace MovieApp.Application.Entities
{
    public class Quality
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}