using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieApp.Core.Entities.MovieAggregate;

namespace MovieApp.Core.Entities
{
    public class Quality
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}