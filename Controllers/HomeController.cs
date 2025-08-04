using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_Dobrovitzky_Tanel.Models;

namespace TP06_Dobrovitzky_Tanel.Controllers;

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
}
