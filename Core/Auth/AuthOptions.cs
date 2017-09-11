using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace NXS.Core.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "NxsAuthServer";
        public const string AUDIENCE = "http://localhost:5000/";
        public const int LIFETIME = 86400;
        public string SecretKey = string.Empty;

        public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }
    }
}