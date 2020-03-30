using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeratMain.Authentication
{
    public class AuthOptions
    {
        public const string ISSUER = "DeratMain"; // издатель токена
        public const string AUDIENCE = "DeratMain"; // потребитель токена
        const string KEY = "derat_ProjectFromRomanVoityk!";   // ключ для шифрации
        public const int LIFETIME = 100; // время жизни токена - 1 минута

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
