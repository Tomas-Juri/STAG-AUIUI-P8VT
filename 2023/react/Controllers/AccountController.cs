using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlyShare.Database;
using OnlyShare.Database.Models;
using OnlyShare.Dto;
using OnlyShare.Dto.Account;
using OnlyShare.Settings;

namespace OnlyShare.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IOptions<AppSettings> _options;
    private readonly DataContext _dataContext;

    public AccountController(DataContext dataContext, IOptions<AppSettings> options)
    {
        _dataContext = dataContext;
        _options = options;
    }

    [HttpPost("[action]")]
    public IActionResult Register(RegisterRequest request)
    {
        if (request.Password != request.PasswordRepeat)
            return BadRequest("Zadaná hesla se neshodují");

        if (_dataContext.Users.Any(user => user.Email == request.Email))
            return BadRequest($"Uživatel s emailem {request.Email} je již registrován");

        var (passwordSalt, passwordHash) = CreatePasswordHash(request.Password);

        var user = new User
        {
            Email = request.Email,
            Username = request.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        _dataContext.Add(user);
        _dataContext.SaveChanges();

        // send email here

        return Ok("Uživatel vytvořen");
    }

    [HttpPost("[action]")]
    public IActionResult Login(LoginRequest request)
    {
        var user = _dataContext.Users.FirstOrDefault(user => request.Email == user.Email);

        if (user == null)
            return NotFound($"Uživatel ${request.Email} nenalezen.");

        if (VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt) == false)
            return BadRequest("Neplatné přihlášení");


        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.Value.JwtSecret);
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
    
    private static (byte[] passwordSalt, byte[] passwordHash) CreatePasswordHash(string password)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        var passwordSalt = hmac.Key;
        var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return (passwordSalt, passwordHash);
    }

    private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        if (storedHash.Length != 64)
            throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(storedHash));
        if (storedSalt.Length != 128)
            throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(storedSalt));

        using var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (var i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != storedHash[i]) return false;
        }

        return true;
    }
}