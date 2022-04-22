using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MovieApp.backend
{
    public class AuthOptions
    {
        const string Key = "mysupersecret_secretkey!123";
        public const string Issuer = "MyAuthServer";
        public const string Audience = "MyAuthClient";
        public const int Lifetime = 35;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}