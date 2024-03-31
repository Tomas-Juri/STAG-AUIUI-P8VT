namespace EventSourcing.Domain.Users;

public record UserState
{
    public required Guid Id { get; init; }
    
    public required string Firstname { get; init; }
    
    public required string Lastname { get; init; }
    
    public required string Email { get; init; }
    
    public required byte[] PasswordHash { get; init; }
    
    public required byte[] PasswordSalt { get; init; }
};