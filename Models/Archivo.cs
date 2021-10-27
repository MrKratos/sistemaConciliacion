using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCuadre.Models
{
    public class Archivo
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "El campo es obligatorio")]
        public String Nombre { get; set; }
        public String File { get; set; }
        // public String tipo { get; set; }

        //public HttpPostedFileBase archivo { get; set; }
        
        
    }
}
