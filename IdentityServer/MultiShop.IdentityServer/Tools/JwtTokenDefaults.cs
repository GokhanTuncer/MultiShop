using System.Runtime.InteropServices;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string Key = "MultiShop..010203040506070809TestKey*-=+_)(*&^%$#@!~`";
        public const int Expire = 60; 
    }
}
