using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastructure.Data;
using System.Linq;

namespace MovieApp.backend.Controllers
{
    public class RestrictionController: Controller
    {
        ApplicationContext db;
        public RestrictionController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("/dashboard/restrictions/{id:int}")]
        public IActionResult GetRestriction(int id)
        {
            var restriction = db.Restrictions
                .Where(r => r.Id == id)
                .Select(x => new {
                    Id = x.Id,
                    Name = x.Name,
                })
                .Single();

            return Ok(restriction);
        }

        [HttpGet("/dashboard/restrictions/")]
        public IActionResult GetRestrictions()
        {
            var restrictions = db.Restrictions.Select(x => new {
                Id = x.Id,
                Name = x.Name,
            })
            .ToList();

            return Ok(restrictions);
        }
    }
}