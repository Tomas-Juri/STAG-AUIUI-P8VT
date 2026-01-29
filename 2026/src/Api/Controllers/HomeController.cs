using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() =>
        View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View("Error");
}