using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Asignatura
    {
        public int id { get; set; }
        [Required]
        public string nombre_asignatura { get; set; }
        // Foreign keys
        public int PofesorId { get; set; }
        // navegacion
        public Profesor Pofesor { get; set; }
    }
    }
}