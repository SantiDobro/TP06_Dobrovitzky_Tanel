using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using TP06_Dobrovitzky_Tanel.Models;

namespace TP06_Dobrovitzky_Tanel.Controllers
{
    public class TareasController : Controller
    {
        public IActionResult Index()
        {
            List<Tarea> tareasActivas = BD.ObtenerTareasActivas();
            if(tareasActivas != null && tareasActivas.Count != 0)
            {
                ViewBag.tareasActivas = tareasActivas;
            }
            else{
                ViewBag.tareasActivas = "No se ha encontrado ninguna tarea activa.";
            }
            return View();
        }
        public IActionResult AgregarTarea()
        {
            
        }
    }
}

    