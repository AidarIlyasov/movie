using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Entities;
using MovieApp.Core.DTO;
using MovieApp.Infrastructure.Data;
using System.Linq;


namespace MovieApp.backend.Controllers
{
    [ApiController]
    [Route("/dashboard/qualities")]
    public class QualityController: ControllerBase
    {

        private readonly ApplicationContext _context;
        public QualityController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetQuality(int id)
        {
            var quality = _context.Qualities
                .Single(q => q.Id == id);

            return Ok(quality);
        }

        
        [HttpGet("")]
        public IActionResult GetQualities(int id)
        {
            var qualities = _context.Qualities
                .Select(q => new
                {   Id = q.Id,
                    Name = q.Name,
                    MoviesCount = q.Movies.Count()
                })
                .ToList();

            return Ok(qualities);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateQuality(QualityDto requestQuality)
        {
            var existQuality = _context.Qualities.SingleOrDefault(r => r.Id == requestQuality.Id);
            
            if (existQuality == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Quality not found"
                });
            }
            
            existQuality.Name = requestQuality.Name;
            
            _context.Update(existQuality);
            _context.SaveChanges();

            return Ok(existQuality);
        }

        [HttpPost("")]
        public IActionResult AddQuality(QualityDto requestQuality)
        {
            var existQuality = _context.Qualities
                .SingleOrDefault(r => r.Name.ToLower() == requestQuality.Name.ToLower());
            
            if (existQuality != null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Quality with this name has already existed in database"
                });
            }

            var quality = new Quality
            {
                Name = requestQuality.Name
            };
            _context.Add(quality);
            _context.SaveChanges();

            return Ok(quality);
        }
    }
}