using System;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastructure.Data;
using System.Linq;
using MovieApp.Core.Entities;
using MovieApp.Core.DTO;

namespace MovieApp.backend.Controllers
{
    [ApiController]
    [Route("/dashboard/restrictions/")]
    public class RestrictionController: ControllerBase
    {
        private readonly ApplicationContext _context;
        public RestrictionController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetRestriction(int id)
        {
            var restriction = _context.Restrictions
                .Where(r => r.Id == id)
                .Select(x => new {
                    Id = x.Id,
                    Name = x.Name,
                })
                .Single();

            return Ok(restriction);
        }

        [HttpGet("")]
        public IActionResult GetRestrictions()
        {
            var restrictions = _context.Restrictions.Select(x => new {
                Id = x.Id,
                Name = x.Name,
                Link = x.Link,
                MoviesCount = x.Movies.Count()
            })
            .ToList();

            return Ok(restrictions);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateRestriction(RestrictionDto requestRestriction)
        {
            var existRestriction = _context.Restrictions.SingleOrDefault(r => r.Id == requestRestriction.Id);
            
            if (existRestriction == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Restriction not found"
                });
            }
            
            existRestriction.Name = requestRestriction.Name;
            existRestriction.Link = requestRestriction.Link;
            
            _context.Update(existRestriction);
            _context.SaveChanges();

            return Ok(requestRestriction);
        }

        [HttpPost("")]
        public IActionResult AddRestriction(RestrictionDto requestRestriction)
        {
            var existRestriction = _context.Restrictions
                .SingleOrDefault(r => r.Name == requestRestriction.Name || r.Link == requestRestriction.Link);
            
            if (existRestriction != null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Restriction with this name or link has already existed in database"
                });
            }

            var restriction = new Restriction
            {
                Link = requestRestriction.Link,
                Name = requestRestriction.Name
            };
            
            _context.Add(restriction);
            _context.SaveChanges();

            return Ok(restriction);
        }
    }
}