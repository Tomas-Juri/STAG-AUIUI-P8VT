using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Backend.Api.Models;
using Application.Backend.Authorization;
using Application.Backend.Core;
using Application.Backend.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Backend.Api;

[ApiController]
[Route("/api/account")]
public class AccountController(DataContext dataContext, IOptions<AppSettings> appSettings) : Controller
{
    private readonly AppSettings _appSettings = appSettings.Value;
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = dataContext.Users.FirstOrDefault(user => user.Email == request.Email);
        if (user == null)
            return NotFound();

        if (Password.Verify(request.Password, user.PasswordHash, user.PasswordSalt) == false)
            return BadRequest();

        var issuer = _appSettings.Jwt.Issuer;
        var audience = _appSettings.Jwt.Audience;
        var key = Encoding.ASCII.GetBytes(_appSettings.Jwt.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(Policy.CanEditForecasts, (user.Role == Role.Administrator).ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);

        return Ok(jwtToken);
    }
}