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
            List<Tarea> connection = BD.ObtenerTareasActivas();
            return View();
        }

    }
}

    