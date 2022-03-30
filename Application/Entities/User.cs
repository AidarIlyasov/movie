namespace MovieApp.Application.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; } = null;
        public Role Role { get; set; }
    }
}
