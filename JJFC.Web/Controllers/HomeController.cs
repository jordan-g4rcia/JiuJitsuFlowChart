using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JJFC.Web.Models;

namespace JJFC.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("{id}")]
    public IActionResult PositionDetails(string id)
    {
        var vm = new PositionDetailsViewModel();
        vm.Description = "This is the positon's description.";
        return View(vm);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}