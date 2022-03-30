using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Entities;
using MovieApp.Application.DTO;
using MovieApp.Infrastructure.Data;
using System.Linq;


namespace MovieApp.backend.Controllers
{
    public class QualityController: Controller
    {

        private ApplicationContext db;
        public QualityController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("/dashboard/qualities/{id:int}")]
        public IActionResult GetQuality(int id)
        {
            var quality = db.Qualities
                        .Where(q => q.Id == id)
                        .Single();

            return Ok(quality);
        }

        
        [HttpGet("/dashboard/qualities")]
        public IActionResult GetQualities(int id)
        {
            var qualities = db.Qualities.ToList();

            return Ok(qualities);
        }
    }
}