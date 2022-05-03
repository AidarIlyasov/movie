using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieApp.Core.Entities.MovieAggregate;

namespace MovieApp.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Link { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
