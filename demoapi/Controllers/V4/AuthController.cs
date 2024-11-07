using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoApi.Controllers.V4
{
    [ApiController]
    [Route("api/v4/auth")]
    [ApiVersion("4.0")]
    public class AuthController : ControllerBase
    {
        private const string ValidUsername = "testuser";
        private const string ValidPassword = "password123";
        private const string ClientKey = "zuwiJCieIRrP4h2fv2TZLWEwka260LOZ";
        private const string SecretKey = "auwiJCieIRrP4h2fv2TZLWEwka260LOA"; // Ensure 32+ character length

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username != ValidUsername || request.Password != ValidPassword || request.ClientKey != ClientKey)
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = GenerateJwtToken(request.Username);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("auwiJCieIRrP4h2fv2TZLWEwka260LOA"); // Consistent encoding
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, username)
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "testuser",
                Audience = "password123"
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientKey { get; set; }
    }
}
