using System;
using System.ComponentModel.DataAnnotations;
using MovieApp.Core.Entities.MovieAggregate;

namespace MovieApp.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }
        [MinLength(2)]
        public string Description { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int ParrentId { get; set; }
        public DateTime Published_at { get; set; }
        public DateTime Created_at { get; set; }
        public User User { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}