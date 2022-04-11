using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieApp.Application.Entities.MovieAggregate;

namespace MovieApp.Application.Entities
{
    public class Restriction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public List<Movie> Movies { get; set; }
    }
}