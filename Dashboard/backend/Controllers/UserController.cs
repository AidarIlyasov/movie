using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.DTO;
using MovieApp.Application.Entities;
using MovieApp.Infrastructure.Data;
using MovieApp.Infrastructure.Services.User;

namespace MovieApp.backend.Controllers
{
    [ApiController]
    [Route("/dashboard/users/")]
    [Authorize(Roles = "admin")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UserController(ApplicationContext context)
        {
            _context = context;
        }
        
        [HttpGet("")]
        public IActionResult GetUsers()
        {
            var users = new UserService(GetAuthorizedUserRole(), _context)
                .GetUsers();

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            var user = new UserService(GetAuthorizedUserRole(), _context)
                .GetUser(id);

            return Ok(user);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(UserDto requestUser)
        {
            var existUser = _context.Users.SingleOrDefault(u => u.Id == requestUser.Id);

            if (existUser == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "User not found"
                });
            }

            var role = _context.Roles.SingleOrDefault(r => r.Id == requestUser.RoleId);
            
            existUser.Email = requestUser.Email;
            existUser.Login = requestUser.Login;
            existUser.Role  = role;
            // existUser.Avatar = requestUser.Avatar;
            
            _context.Update(existUser);
            _context.SaveChanges();
            requestUser.Role = role.Name;
            
            return Ok(requestUser);
        }

        [HttpPost("")]
        public IActionResult CreateUser(UserDto requestUser)
        {
            var existUser = _context.Users.SingleOrDefault(u => u.Login == requestUser.Login || u.Email == requestUser.Email);
            
            if (existUser != null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "User with the same login or email has already existed in database"
                });
            }

            var role = _context.Roles.SingleOrDefault(r => r.Id == requestUser.RoleId);

            var user = new User
            {
                Login = requestUser.Login,
                Email = requestUser.Email,
                Password = requestUser.Password,
                Role = role
            };
            
            _context.Add(user);
            _context.SaveChanges();
            requestUser.Role = role.Name;
            
            return Ok(requestUser);
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveUser(int id)
        {
            var existUser = _context.Users.SingleOrDefault(u => u.Id == id);

            if (existUser == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = $"User with Id={id} not found in database"
                });
            }

            _context.Users.Remove(existUser);
            _context.SaveChanges();
            
            return Ok(existUser);
        }
        
        private string GetAuthorizedUserRole()
        {
            return User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value;
        }
    }
}