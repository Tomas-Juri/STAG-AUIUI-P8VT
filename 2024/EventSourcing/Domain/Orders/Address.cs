namespace EventSourcing.Domain.Orders;

public record Address
{
    public required string Street { get; init; }
    
    public required string City { get; init; }
    
    public required string Zipcode { get; init; }
};