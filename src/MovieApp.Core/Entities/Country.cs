using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieApp.Core.Entities.MovieAggregate;

namespace MovieApp.Core.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Link { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
