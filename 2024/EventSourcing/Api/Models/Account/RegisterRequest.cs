using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Api.Models.Account;

public record RegisterRequest
{
    public required string Email { get; init; }
    
    public required string Firstname { get; init; }
    
    public required string Lastname { get; init; }
    
    public required string Password { get; init; }
    
    [BindProperty(Name = "password-repeat")]
    public required string PasswordRepeat { get; init; }
};