using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using JJFC.Web.Models;
using JJFC.Web.Repositories;

namespace JJFC.Web.Controllers;

public class HomeController : Controller
{
    private readonly PositionRepository _positionRepository;

    public HomeController(PositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task<IActionResult> Index()
    {
        var positions = await _positionRepository.GetAll();
        return View(positions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> PositionDetails(string id)
    {
        var position = await _positionRepository.GetById(id);
        if (position == null)
        {
            return RedirectToAction("Index");
        }
        return View(position);
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