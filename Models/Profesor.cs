using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Profesor
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string tdocumento { get; set; }
        public string documento { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}