using System;
using MovieApp.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Core.Helpers;

namespace MovieApp.Core.DTO.MovieAggregate
{
    public class ThinMovieDto
    {
        public int Id { get; set; }
        public string Link { get;}
        public string Image { get; }
        public string Title { get; set; }
        public double Rating { get;}
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public ThinMovieDto(int id, string title, string slug, List<Category> categories, List<Photo> photos, int likes, int dislikes)
        {
            Id = id;
            Title = title;
            Link = slug;
            Image = photos?.SingleOrDefault(p => p.IsPoster)?.Name.ToString() ??  "default";
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