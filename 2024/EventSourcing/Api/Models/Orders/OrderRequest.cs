using EventSourcing.Domain.Orders;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Api.Models.Orders;

public record OrderRequest
{
    public required string Name { get; init; }
    
    public IFormFile? Photo { get; init; }
    
    public required int Price { get; init; }

    public required OrderSize Size { get; init; }

    public required string Description { get; init; }

    [BindProperty(Name = "from-street")]
    public required string FromStreet { get; init; }
    
    [BindProperty(Name = "from-city")]
    public required string FromCity { get; init; }

    [BindProperty(Name = "from-zipcode")]
    public required string FromZipcode { get; init; }

    [BindProperty(Name = "to-street")]
    public required string ToStreet { get; init; }
    
    [BindProperty(Name = "to-city")]
    public required string ToCity { get; init; }

    [BindProperty(Name = "to-zipcode")]
    public required string ToZipcode { get; init; }
}