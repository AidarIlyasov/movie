using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieApp.Application.Entities;

namespace MovieApp.Application.Entities.MovieAggregate
{
    public class Movie
    {
        // public Movie()
        // {
        //     GenreMovie = new HashSet<GenreMovie>();
        // }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Duration { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Release_at { get; set; } = new DateTime(1000, 1, 1);
        
        public IEnumerable<Quality> Qualities { get; set; }
        public List<Country> Countries { get; set; }
        public int RestrictionId { get; set; } = 1;
        public Restriction Restriction { get; set; }
        public List<Photo> Photos { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Category> Categories { get; set; }
         // public ICollection<GenreMovie> GenreMovie { get; set; }
    }
}
