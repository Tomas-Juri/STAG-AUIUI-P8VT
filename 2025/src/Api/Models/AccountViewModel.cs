namespace Application.Api.Models;

public record AccountViewModel
{
    public string Email { get; init; } = string.Empty;
    
    public string Name { get; init; } = string.Empty;
}