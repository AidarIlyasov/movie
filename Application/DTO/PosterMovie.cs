using System;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Application.Helpers;
using MovieApp.Application.Entities;

namespace MovieApp.Application.DTO
{
    public class PosterMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Raiting { get; set; }
        public List<Category> Categories { get; set; }

        public PosterMovie(int id, string title, string link, List<Photo> photos, string description, int likes, int dislikes, IEnumerable<Category> categories)
        {
            Id = id;
            Title = title;
            Link = link;
            Image = photos.Any() ? photos.Single(p => p.IsPoster).Name : "default";
            Description = description;
            // Raiting = Math.Round(1.0 * likes / (likes + dislikes) * 10, 1);
            Raiting = 9.6;
            Categories = categories.Select(g => new Category
            {
                Name = WordRegister.FirstCharToUpper(g.Name),
                Link = g.Link
            }).ToList();
        }
    }
}
