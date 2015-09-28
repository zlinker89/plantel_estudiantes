using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Asistencia
    {
        public int id { get; set; }
        [Required]
        public bool estado { get; set; }
        public DateTime fecha_asistencia { get; set; }
        // Foreign keys
        public int MatriculaId { get; set; }
        // propiedades de navegacion
        public Matricula Matricula { get; set; }
        
    }
}