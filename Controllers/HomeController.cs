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
        string usuario = HttpContext.Session.GetString("Usuario");

        if (!string.IsNullOrEmpty(usuario))
        {
            var perfil = Perfil.BuscarPorUsuario(usuario);
            return View(perfil);
        }
        return View(null);
    }
    public IActionResult IniciarSesion()
    {
        return View();
    }
    public IActionResult CrearCuenta()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string usuario, string contraseña)
    {
        var perfil = Perfil.LevantarPerfil(usuario, contraseña);

        if (perfil != null)
        {
            HttpContext.Session.SetString("Usuario", perfil.Usuario);
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View("IniciarSesion");
        }
    }

    [HttpPost]
    [HttpPost]
public IActionResult Register(string usuario, string contraseña, DateTime nacimiento)
{
    var compararUser = Perfil.LevantarPerfil(usuario, contraseña);
    if (compararUser != null)
    {
        ViewBag.Error = "Este usuario ya existe";
        return View("CrearCuenta");
    }
    else
    {
        int registrosafectados = Perfil.AgregarPerfil(usuario, contraseña, nacimiento);
        if (registrosafectados > 0)
        {
            HttpContext.Session.SetString("Usuario", usuario);
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Error = "Error al crear el usuario.";
            return View("CrearCuenta");
        }
    }
}

    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}

