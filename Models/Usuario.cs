using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Usuario
    {
        public int id { get; set; }
        [Required]
        public string nombreusuario { get; set; }
        public string contrasena { get; set; }
        public DateTime fecha_registro { get; set; }
    
    }
}