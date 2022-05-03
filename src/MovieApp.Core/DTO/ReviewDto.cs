using System;
using System.Collections.Generic;

namespace MovieApp.Core.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Published_at { get; set; }
        public DateTime Created_at { get; set; }
        public string UserLogin { get; set; }
        public double Raiting { get; set; }
    }
}