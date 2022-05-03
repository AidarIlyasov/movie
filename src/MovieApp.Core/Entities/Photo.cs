using MovieApp.Core.Entities.MovieAggregate;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MovieApp.Core.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public int Name { get; set; } = 0;
        public int MovieId { get; set; }
        public bool IsPoster { get; set; } = false;
        [BindNever]
        public Movie Movie {get; set;}
        
    //    [NotMapped]
    //     public IFormFile Image { get; set; }
    }
}