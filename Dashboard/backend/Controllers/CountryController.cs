using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MovieApp.Application.Entities;

namespace MovieApp.backend.Controllers
{
    [ApiController]
    [Route("/dashboard/countries/")]
    public class CountryController: ControllerBase
    {
        private readonly ApplicationContext _context;
        public CountryController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCountry(int id)
        {
            var country = _context.Countries
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new {
                    Id = c.Id,
                    Name = c.Name,
                    Link = c.Link
                }).Single();

            return Ok(country);
        }

        [HttpGet("")]
        public IActionResult GetCountries()
        {
            var countries = _context.Countries
            .AsNoTracking()
            .Select(c => new {
                Id = c.Id,
                Name = c.Name,
                Link = c.Link,
                Code = c.CountryCode,
                MoviesCount = c.Movies.Count()
            })
            .ToList();

            return Ok(countries);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCountry(Country requestCountry)
        {
            var existCountry = _context.Countries.Single(r => r.Id == requestCountry.Id);
            
            if (existCountry == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Country not found"
                });
            }
            
            existCountry.Name = requestCountry.Name;
            
            _context.Update(existCountry);
            _context.SaveChanges();

            return Ok(existCountry);
        }
        
        [HttpPost("")]
        public IActionResult AddCountry(Country requestCountry)
        {
            var existCountry = _context.Countries
                .Single(r => r.Name == requestCountry.Name || r.Link == requestCountry.Link);
            
            if (existCountry != null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Country with this name or link has already existed in database"
                });
            }

            _context.Add(requestCountry);
            _context.SaveChanges();

            return Ok(requestCountry);
        }
    }
}