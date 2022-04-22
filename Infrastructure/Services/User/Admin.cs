using System.Collections.Generic;
using MovieApp.Application.DTO;
using MovieApp.Infrastructure.Data;
using System.Linq;

namespace MovieApp.Infrastructure.Services.User
{
    public class Admin: IUser
    {
        private readonly ApplicationContext _context;

        public Admin(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Login = u.Login,
                    Email = u.Email,
                    Password = u.Password,
                    RoleId = u.Role.Id,
                    Role = u.Role.Name
                })
                .OrderBy(u => u.Login);
        }

        public UserDto GetUser(int id)
        {
            return _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Login = u.Login,
                    Email = u.Email,
                    Password = u.Password,
                    RoleId = u.Role.Id,
                    Role = u.Role.Name
                }).FirstOrDefault(u => u.Id == id);
        }

        public UserDto UpdateUser()
        {
            throw new System.NotImplementedException();
        }
    }
}