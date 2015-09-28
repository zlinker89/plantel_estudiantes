using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Notificacion
    {
        public int id { get; set; }
        public string asunto { get; set; }
        public string mensaje { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public int UsuarioId { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}