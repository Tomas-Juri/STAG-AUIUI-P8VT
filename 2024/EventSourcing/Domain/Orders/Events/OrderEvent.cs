namespace EventSourcing.Domain.Orders.Events;

public record OrderEvent : Event
{
    public required Guid OrderId { get; init; }
};