using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MovieApp.Core.DTO
{
    public class MovieDto
    {
        public int Id {get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public float Duration { get; set; }
        public string Slug { get; set; }
        public String Release { get; set; }
        public Restriction Restriction { get; set; }
        public string Poster { get; set; } = "default";

        public List<Country> Countries { get; set; }
        public List<Quality> Qualities { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<PhotoDto> Photos {get; set; }
        public IEnumerable<CommentDto> Comments { get; set; } = null;
        public IEnumerable<ReviewDto> Reviews { get; set; } = null;
    }
}