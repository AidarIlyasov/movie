using System;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Core.Helpers;
using MovieApp.Core.Entities;

namespace MovieApp.Core.DTO
{
    public class PosterMovie
    {
        public int Id { get; }
        public string Title { get; }
        public string Link { get; }
        public string Image { get; }
        public string Description { get; }
        public double Rating { get; }
        public List<CategoryDto> Categories { get; }

        public PosterMovie(int id, string title, string link, List<Photo> photos, string description, int likes, int dislikes, IEnumerable<Category> categories)
        {
            Id = id;
            Title = title;
            Link = link;
            Image = photos.Any() ? photos.Single(p => p.IsPoster).Name : "default";
            Description = description;
            Rating = Math.Round(1.0 * likes / (likes + dislikes) * 10, 1);
            Categories = categories.Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = WordRegister.FirstCharToUpper(c.Name),
                Link = c.Link
            }).ToList();
        }
    }
}
