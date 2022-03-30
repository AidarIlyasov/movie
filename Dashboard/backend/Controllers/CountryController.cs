using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Entities;
using MovieApp.Application.DTO;
using MovieApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieApp.backend.Controllers
{
    public class CountryController: Controller
    {
        ApplicationContext db;
        public CountryController(ApplicationContext contex)
        {
            db = contex;
        }

        [HttpGet("/dashboard/countries/{id:int}")]
        public IActionResult GetCountry(int id)
        {
            var country = db.Countries
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new {
                    Id = c.Id,
                    Name = c.Name,
                    Link = c.Link
                }).Single();

            return Ok(country);
        }

        [HttpGet("/dashboard/countries/")]
        public IActionResult GetCountries()
        {
            var countries = db.Countries
            .AsNoTracking()
            .Select(c => new {
                Id = c.Id,
                Name = c.Name,
                Link = c.Link
            })
            .ToList();

            return Ok(countries);
        }
    }
}