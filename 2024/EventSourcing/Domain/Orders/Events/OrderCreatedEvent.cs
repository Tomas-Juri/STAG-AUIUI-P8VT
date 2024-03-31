namespace EventSourcing.Domain.Orders.Events;

public record OrderCreatedEvent : OrderEvent
{
    public required Guid UserId { get; init; }
    
    public required string Name { get; init; }

    public required string PhotoUrl { get; init; }

    public required int Price { get; init; }

    public required OrderSize Size { get; init; }

    public required string Description { get; init; }

    public required Address From { get; init; }

    public required Address To { get; init; }
    
    public required DateTimeOffset CreatedAt { get; init; }
};