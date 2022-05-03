using System;

namespace MovieApp.Core.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Password { get; set; }
    }
}