using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieApp.Core.Entities;

namespace MovieApp.Core.Entities.MovieAggregate
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Duration { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Release { get; set; } = new DateTime(1000, 1, 1);
        
        public IEnumerable<Quality> Qualities { get; set; } = new List<Quality>();
        public List<Country> Countries { get; set; } = new List<Country>();
        public int RestrictionId { get; set; } = 1;
        public Restriction Restriction { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
