using System.Diagnostics;
using EventSourcing.Api.Models;
using EventSourcing.Api.Models.Home;
using EventSourcing.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Api.Controllers;

public class HomeController(EventStore store) : Controller
{
    private ApplicationState ApplicationState => store.GetState();
    
    [Authorize]
    public IActionResult Index()
    {
        var userId = Guid.Parse(User.FindFirst("Id").Value);

        var model = new IndexModel
        {
            MyOrders = ApplicationState.Orders
                .Where(order => order.CreatedBy == userId)
                .ToList()
        };
        
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}