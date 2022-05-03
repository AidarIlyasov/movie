using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using MovieApp.Core.DTO;

namespace MovieApp.Web.ViewModels
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Raiting { get; set; }
        public float Duration { get; set; }
        public string Slug { get; set; }
        public DateTime Relese { get; set; }
        public Restriction Restriction { get; set; }

        public List<Country> Countries;
        public List<Quality> Qualities;
        public List<Category> Genres;
        public List<Photo> Photos;
        public IEnumerable<CommentDto> Comments { get; set; } = null;
        public IEnumerable<ReviewDto> Reviews { get; set; } = null;
    }
}
