using Microsoft.AspNetCore.Http;
using MovieApp.Application.Entities;

namespace MovieApp.Application.DTO
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public bool IsPoster { get; set; } = false;
        public IFormFile Image { get; set; }

        public static PhotoDto FromPhoto(Photo photo) 
        {
            return new PhotoDto
            {
                Id = photo.Id,
                Name = photo.Name,
                IsPoster = photo.IsPoster
            };
        }
    }
}