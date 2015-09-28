using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombreusuario { get; set; }
        public string contrasena { get; set; }
        public System.DateTime fecha_registro { get; set; }
    
        public virtual Estudiante Estudiante { get; set; }
        public virtual Padre Padre { get; set; }
        public virtual Profesor Pofesor { get; set; }
    }
}