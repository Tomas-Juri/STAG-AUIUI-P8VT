using EventSourcing.Api.Models.Orders;
using EventSourcing.Domain;
using EventSourcing.Domain.Orders;
using EventSourcing.Domain.Orders.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Api.Controllers;

[Authorize]
[Route("orders")]
public class OrdersController(EventStore eventStore) : Controller
{
    [HttpGet("new")]
    public IActionResult ViewNewOrder() => 
        View("New");

    [HttpPost("new")]
    public IActionResult NewOrder([FromForm] OrderRequest request)
    {
        if (ModelState.IsValid == false)
            return View("New");

        var @event = new OrderCreatedEvent
        {
            OrderId = Guid.NewGuid(),
            UserId = Guid.Parse(User.FindFirst("Id").Value),
            Name = request.Name,
            PhotoUrl = string.Empty, // TODO
            Price = request.Price,
            Size = request.Size,
            Description = request.Description,
            From = new Address
            {
                Street = request.FromStreet,
                City = request.FromCity,
                Zipcode = request.FromZipcode
            },
            To = new Address
            {
                Street = request.ToStreet,
                City = request.ToCity,
                Zipcode = request.ToZipcode
            },
            CreatedAt = DateTimeOffset.Now
        };
        eventStore.Add(@event);

        ViewData["Id"] = @event.OrderId;
        ViewData["Name"] = @event.Name;
        return View("Created");
    }
}