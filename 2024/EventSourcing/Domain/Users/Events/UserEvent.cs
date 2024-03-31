namespace EventSourcing.Domain.Users.Events;

public abstract record UserEvent : Event
{
    public required Guid UserId { get; init; }
};