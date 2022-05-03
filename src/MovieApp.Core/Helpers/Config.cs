using System.Collections.Generic;

namespace MovieApp.Core.Helpers
{
    public class Config
    {    
        public string Path { get; set; }
        public List<object> ConnectionStrings { get; set; }
        public string Secret { get; set; }
    }
}