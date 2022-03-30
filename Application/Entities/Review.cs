using System;
using System.ComponentModel.DataAnnotations.Schema;
using MovieApp.Application.Entities.MovieAggregate;

namespace MovieApp.Application.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public DateTime Published_at { get; set; }
        public DateTime Created_at { get; set; }
        public User User { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}