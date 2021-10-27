using AppCuadre.Datos;
using AppCuadre.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCuadre.Controllers
{
    public class ArchivoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ArchivoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Archivo> listArchivos = _context.Archivo;
            return View(listArchivos);
        }
    }
}
