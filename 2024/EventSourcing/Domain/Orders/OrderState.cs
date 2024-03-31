using EventSourcing.Domain.Users;

namespace EventSourcing.Domain.Orders;

public record OrderState
{
    public required Guid Id { get; init; }
    
    public required Guid CreatedBy { get; init; }
    
    public required string Name { get; init; }

    public required string PhotoUrl { get; init; }

    public required int Price { get; init; }

    public required OrderSize Size { get; init; }

    public required string Description { get; init; }

    public required Address From { get; init; }

    public required Address To { get; init; }
    
    public required DateTimeOffset CreatedAt { get; init; }
    
    public required DateTimeOffset UpdatedAt { get; init; }
};