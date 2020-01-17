using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Data
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
