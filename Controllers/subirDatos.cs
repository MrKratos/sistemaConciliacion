using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace AppCuadre.Controllers
{
    public class subirDatos : Controller
    {
        public IActionResult SubirDatos()
        {
            return View();
        }
        public IActionResult archivos()
        {
            return RedirectToAction("SubirDatos");
        }

        public void ExtraccionDatos(String procedimiento, DataTable tabla) {
            String[] campos = camposProcedimiento("");
            String nombreTablas = nombreTabla("");
            String query = "insert into " + nombreTablas + " (";

            for (int j = 0; j < campos.Length; j++) {
                query = query +" " +campos[j];
                if (j == campos.Length - 1){
                    query = query + ") values (";
                }
                else {
                    query = query + " ,";
                }
            }


            for (int i = 0; i < tabla.Rows.Count; i++) {
                for (int k=0; k< campos.Length; k++) {
                    
                }
            }
        }

        public String[] camposProcedimiento(String procedimiento) {
            /*seleccionar campos documento*/
            String[] campos = { "valor", "texto" };
            return campos;
        }

        public String nombreTabla(String procedimiento) {
            return "conciliaciones";
        }
    }
}
