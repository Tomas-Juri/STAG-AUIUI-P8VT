using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Backend.Core;
using Application.Backend.Database;
using Application.Backend.Database.Models;
using Application.Backend.Dto.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Backend.Controllers;

[ApiController]
[Route("account")]
public class AccountController(DataContext dataContext, IOptions<AppSettings> options) : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        if (request.Password != request.PasswordRepeat)
            return BadRequest("Zadaná hesla se neshodují");

        if (dataContext.Users.Any(user => user.Email == request.Email))
            return BadRequest($"Uživatel s emailem {request.Email} je již registrován");

        var (passwordSalt, passwordHash) = Password.Create(request.Password);

        var user = new User
        {
            Email = request.Email,
            Username = request.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        dataContext.Add(user);
        dataContext.SaveChanges();

        // TODO send email here

        return Ok("Uživatel vytvořen");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = dataContext.Users.FirstOrDefault(user => request.Email == user.Email);

        if (user == null)
            return NotFound($"Uživatel ${request.Email} nenalezen.");

        if (Password.Verify(request.Password, user.PasswordHash, user.PasswordSalt) == false)
            return BadRequest("Neplatné přihlášení");
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(options.Value.JwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        if (tokenString == null)
            return BadRequest("Nepodařilo se přihlásit");

        return Ok(new LoginResponse { Token = tokenString });
    }
}