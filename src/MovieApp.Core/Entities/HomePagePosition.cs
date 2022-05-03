using System.Collections.Generic;
using MovieApp.Core.Enums;

namespace MovieApp.Core.Entities
{
    public class HomePagePosition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HomePageSettings> Settings = new List<HomePageSettings>();
    }
}