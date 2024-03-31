using EventSourcing.Domain.Orders;

namespace EventSourcing.Mvc.Models.Home;

public record IndexModel
{
    public required IReadOnlyCollection<OrderState> MyOrders { get; init; }
};