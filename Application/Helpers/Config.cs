using System.Collections.Generic;

namespace MovieApp.Application.Helpers
{
    public class Config
    {    
        public string Path { get; set; }
        public List<object> ConnectionStrings { get; set; }
        public string Secret { get; set; }
    }
}