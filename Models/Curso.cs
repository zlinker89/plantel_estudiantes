using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Curso
    {
        public int id { get; set; }
        [Required]
        public string ncurso { get; set; }
        // Foreign keys
        public int JornadaId { get; set; }
        // Navegacion
        public Jornada Jornada { get; set; }
    }
}