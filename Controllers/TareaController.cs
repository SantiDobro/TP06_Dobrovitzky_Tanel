using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using TP06_Dobrovitzky_Tanel.Models;

namespace TP06_Dobrovitzky_Tanel.Controllers
{
    public class TareaController : Controller
    {
        public IActionResult Index()
        {
            List<Tarea> tareasActivas = BD.ObtenerTareasActivas();
            if (tareasActivas != null && tareasActivas.Count != 0)
            {
                ViewBag.tareasActivas = tareasActivas;
            }
            else
            {
                ViewBag.tareasActivas = "No se ha encontrado ninguna tarea activa.";
            }
            return View();
        }
        public IActionResult AgregarTarea()
        {
            List<string> categorias = BD.DevolverCategorias();
            if (categorias == null)
            {
                categorias = new List<string>();
            }
            ViewBag.Categorias = categorias;

            return View();
        }

        [HttpPost]
        public IActionResult InsertarTarea(string nombre, DateTime fecha, string categoria, string nuevaCategoria)
        {
            if (nuevaCategoria != null)
            {
                BD.InsertarCategoria(nuevaCategoria);
                categoria = nuevaCategoria;
            }

            BD.InsertarTarea(nombre, fecha, categoria);
            TempData["MensajeExito"] = "Tarea creada correctamente";
            return RedirectToAction("AgregarTarea");
        }
        public IActionResult InsertarCategoria(string nuevaCategoria)
        {
            BD.InsertarCategoria(nuevaCategoria);
            return View("AgregarTarea");
        }
    }
}

