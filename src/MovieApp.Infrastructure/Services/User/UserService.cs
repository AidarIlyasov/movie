using System.Collections.Generic;
using MovieApp.Core.DTO;
using MovieApp.Infrastructure.Data;

namespace MovieApp.Infrastructure.Services.User
{
    public class UserService: IUser
    {
        private readonly IUser _user; 
        
        public UserService(string roleName, ApplicationContext context)
        {
            _user = roleName switch
            {
                "admin" => new Admin(context),
                "manager" => new Manager(context),
                _ => _user
            };
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _user.GetUsers();
        }

        public UserDto GetUser(int id)
        {
            return _user.GetUser(id);
        }

        public UserDto UpdateUser()
        {
            return _user.UpdateUser();
        }
    }
}