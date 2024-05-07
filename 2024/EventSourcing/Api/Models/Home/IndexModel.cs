using EventSourcing.Domain.Orders;

namespace EventSourcing.Api.Models.Home;

public record IndexModel
{
    public required IReadOnlyCollection<OrderState> MyOrders { get; init; }
};