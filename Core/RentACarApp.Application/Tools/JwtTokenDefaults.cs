using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudiance = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "RentACarProjectSuperSecretKey12345";
        public const int Expire = 3;
    }
}
