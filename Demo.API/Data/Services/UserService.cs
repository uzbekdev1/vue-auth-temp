using Demo.API.Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demo.API.Data.Services
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Elyor", LastName = "Latipov", Username = "dev", Password = "test" }
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            var claims = new[]
            {
                new Claim("login", user.Username),
                new Claim("role", "client")
            };
            var token = new JwtSecurityToken(null, null, claims, DateTime.UtcNow, DateTime.UtcNow.AddDays(1), _appSettings.SigningCredentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            
            return jwt;
        }
    }
}
