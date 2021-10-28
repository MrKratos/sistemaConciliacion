using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuadre.Datos;
using AppCuadre.Models;

namespace AppCuadre.Controllers
{
    public class ejecutarProcController : Controller
    {

        public IActionResult Index()
        {
            return View("ejecutarProcedimiento");
        }
    }
}
