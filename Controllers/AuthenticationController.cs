using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace UsersApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;

        public class AuthenticationRequestBody()
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        private class User {
            public int UserId {get; set;}
            public string UserName {get; set;}
            public string FirstName {get; set;}
            public string LastName {get; set;}
            public string Country {get; set;}
            public User(int userId, string userName, string firstName, string lastName, string country) {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
                Country = country;
            }

        }

        public AuthenticationController(IConfiguration config) {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody requestBody)
        {
            var user = ValidateCredentials(requestBody.Username, requestBody.Password);
            if(user == null) {
                return Unauthorized();
            }
            var secretKey = new SymmetricSecurityKey(Convert.FromBase64String(_config["Authentication:Secret"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim("sub", user.UserId.ToString()));
            claims.Add(new Claim("full_name", user.FirstName + " "+ user.LastName));
            claims.Add(new Claim("country", user.Country));

            var jwtToken =  new JwtSecurityToken(
                _config["Authentication:Issuer"],
                _config["Authentication:Audiences"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials
            );

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Ok(tokenToReturn);
        }

        private User ValidateCredentials(string? username, string? password) {
            return new User(
                1,
                "jogn_robinson",
                "John",
                "Robinson",
                "India"
            );
        }
    }
}
