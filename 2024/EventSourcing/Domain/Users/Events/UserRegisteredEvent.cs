namespace EventSourcing.Domain.Users.Events;

public record UserRegisteredEvent : UserEvent
{
    public required string Email { get; init; }
    
    public required string Firstname { get; init; }
    
    public required string Lastname { get; init; }
    
    public required byte[] PasswordHash { get; init; }
    
    public required byte[] PasswordSalt { get; init; }
};