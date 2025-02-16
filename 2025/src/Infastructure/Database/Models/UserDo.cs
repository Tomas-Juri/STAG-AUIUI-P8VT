namespace Application.Infastructure.Database.Models;

public class UserDo
{
    public required Guid Id { get; set; }

    public required string Email { get; set; }

    public required string Name { get; set; }

    public required byte[] PasswordHash { get; set; }

    public required byte[] PasswordSalt { get; set; }
    
    public required string Role { get; set; }
}