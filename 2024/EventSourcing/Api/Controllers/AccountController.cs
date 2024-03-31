using System.Security.Claims;
using EventSourcing.Domain;
using EventSourcing.Domain.Users.Events;
using EventSourcing.Mvc.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Mvc.Controllers;

[Route("account")]
public class AccountController(EventStore eventStore) : Controller
{
    [HttpGet("login")]
    public IActionResult ViewLogin([FromQuery] string? returnUrl)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            var redirectUrl = string.IsNullOrEmpty(returnUrl)
                ? Url.Action("Index", "Home")
                : Url.IsLocalUrl(returnUrl)
                    ? Url.Action(returnUrl)
                    : Url.Action("Index", "Home");

            return LocalRedirect(redirectUrl);
        }

        return View("Login");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginRequest request, [FromQuery] string? returnUrl)
    {
        var state = eventStore.GetState();

        var user = state.Users.FirstOrDefault(user => user.Email == request.Email);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View("Login");
        }

        var isPasswordValid = Password.Verify(request.Password, user.PasswordHash, user.PasswordSalt);
        if (isPasswordValid == false)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View("Login");
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email),
            new(ClaimTypes.Role, "User"),
            new("Id", user.Id.ToString()),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            IssuedUtc = DateTimeOffset.UtcNow,
            IsPersistent = true,
            RedirectUri = Url.Action("ViewLogin")
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        eventStore.Add(new UserLoggedIn { UserId = user.Id });

        var redirectUrl = string.IsNullOrEmpty(returnUrl)
            ? Url.Action("Index", "Home")
            : Url.IsLocalUrl(returnUrl)
                ? Url.Action(returnUrl)
                : Url.Action("Index", "Home");

        return LocalRedirect(redirectUrl);
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        // Clear the existing external cookie
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("register")]
    public IActionResult ViewReqister()
    {
        return View("Register");
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        // Validations
        if (request.Password != request.PasswordRepeat)
        {
            ModelState.AddModelError("password-repeat", "Passwords do not match.");
            return View("Register");
        }
        
        // Create event
        var (passwordSalt, passwordHash) = Password.Create(request.Password);
        eventStore.Add(new UserRegisteredEvent
        {
            UserId = Guid.NewGuid(),
            Email = request.Email,
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        });
        
        // Return view
        return RedirectToAction("Login");
    }

    [HttpGet("profile")]
    public IActionResult ViewProfile()
    {
        return View("Login");
    }
}