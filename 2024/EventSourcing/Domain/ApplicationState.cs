using System.Collections.Immutable;
using EventSourcing.Domain.Orders;
using EventSourcing.Domain.Orders.Events;
using EventSourcing.Domain.Users;
using EventSourcing.Domain.Users.Events;

namespace EventSourcing.Domain;

public record ApplicationState
{
    public static ApplicationState Empty => new()
    {
        Users = [],
        Orders = []
    };

    public required ImmutableList<UserState> Users { get; init; }
    
    public required ImmutableList<OrderState> Orders { get; init; }

    public static ApplicationState Apply(ApplicationState state, Event @event) =>
        @event switch
        {
            OrderCreatedEvent orderCreatedEvent => state with
            {
                Orders = state.Orders.Add(new OrderState
                {
                    Id = orderCreatedEvent.OrderId,
                    Name = orderCreatedEvent.Name,
                    PhotoUrl = orderCreatedEvent.PhotoUrl,
                    Price = orderCreatedEvent.Price,
                    Size = orderCreatedEvent.Size,
                    Description = orderCreatedEvent.Description,
                    From = orderCreatedEvent.From,
                    To = orderCreatedEvent.To,
                    CreatedBy = orderCreatedEvent.UserId,
                    CreatedAt = orderCreatedEvent.CreatedAt,
                    UpdatedAt = orderCreatedEvent.CreatedAt,
                })
            },
            UserRegisteredEvent userRegisteredEvent => state with
            {
                Users = state.Users.Add(new UserState
                {
                    Id = userRegisteredEvent.UserId,
                    Firstname = userRegisteredEvent.Firstname,
                    Lastname = userRegisteredEvent.Lastname,
                    Email = userRegisteredEvent.Email,
                    PasswordHash = userRegisteredEvent.PasswordHash,
                    PasswordSalt = userRegisteredEvent.PasswordSalt
                })
            },
            _ => state with { }
        };
};