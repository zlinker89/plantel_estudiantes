using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Curso
    {
        public int id { get; set; }
        public string ncurso { get; set; }
        public int JornadaId { get; set; }
    
        public virtual Jornada Jornada { get; set; }
    }
}