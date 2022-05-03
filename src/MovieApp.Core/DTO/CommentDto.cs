using System;
using System.Collections.Generic;
using MovieApp.Core.Entities;

namespace MovieApp.Core.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public String UserLogin { get; set; }
        public DateTime Published_at { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<Comment> Replies { get; set; }
    }
}