using MovieApp.Application.Entities;
using System;
using System.Collections.Generic;

namespace MovieApp.Application.DTO
{
    public class UpdateMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        public string Slug { get; set; }
        public string Release { get; set; }
        public RestrictionDto Restriction { get; set; }
        public List<CountryDto> Countries { get; set; }
        public List<QualityDto> Qualities { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<PhotoDto> Photos {get; set; }

        // public UpdateMovieDto
        // (
        //     int id,
        //     string title,
        //     string description,
        //     float duration,
        //     string slug,
        //     string release,
        //     RestrictionDto restriction,
        //     List<CountryDto> countries,
        //     List<QualityDto> qualities,
        //     List<CategoryDto> categories,
        //     List<PhotoDto> photos
        // )
        // {
        //     Id = id;
        //     Title = title;
        //     Description = description;
        //     Duration = duration;
        //     Slug = slug;
        //     Release = DateTime.Parse(release);
        //     Restriction = restriction;
        //     Countries = countries;
        //     Qualities = qualities;
        //     Categories = categories;
        //     Photos = photos;
        // }
    }
}