using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastructure.Data;

namespace MovieApp.backend.Controllers
{
    [ApiController]
    [Route("/dashboard/roles/")]
    public class RoleController: ControllerBase
    {
        private readonly ApplicationContext _context;
        
        public RoleController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult GetRoles()
        {
            var roles = _context.Roles.ToList();
            
            return Ok(roles);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == id);
            
            return Ok(role);
        }
    }
}