using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
