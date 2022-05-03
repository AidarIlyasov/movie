using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieApp.Core.Entities.MovieAggregate;

namespace MovieApp.Core.Entities
{
    public class Restriction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Link { get; set; }
        public List<Movie> Movies { get; set; }
    }
}