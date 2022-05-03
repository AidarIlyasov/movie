using System;
using System.Linq;

namespace MovieApp.Core.Helpers
{
    public class WordRegister
    {
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new System.ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}