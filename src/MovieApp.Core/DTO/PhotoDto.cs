using Microsoft.AspNetCore.Http;
using MovieApp.Core.Entities;

namespace MovieApp.Core.DTO
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
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