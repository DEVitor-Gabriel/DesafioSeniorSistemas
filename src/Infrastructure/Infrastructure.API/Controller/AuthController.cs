using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DesafioSeniorSistemas.Infrastructure.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("Login")]
    public IActionResult Login()
    {
        var token = GenerateJwtToken();
        return Ok(new { token });
    }

    private static string GenerateJwtToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        string key = "54gY8BWmk8nqSMO6GVEFvbh53CsRBrHg";
        byte[] byteKey = Encoding.ASCII.GetBytes(key);
        int expirationTimeInHours = 1;

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "admin") }),
            Expires = DateTime.UtcNow.AddHours(expirationTimeInHours),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}