using System.ComponentModel.DataAnnotations;

namespace MovieApp.Application.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Login { get; set; }
        public string Avatar { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
        
        public int? RoleId { get; set; } = null;
        public Role Role { get; set; }
    }
}
