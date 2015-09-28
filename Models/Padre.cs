using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Padre
    {
        public int id { get; set; }
        [Required]
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string tdocumento { get; set; }
        public string ndocumento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        // Foreign keys
        public int EstudianteId { get; set; }
        // propiedades de navegacion
        public Usuario Usuario { get; set; }
        public Estudiante Estudiante { get; set; }
    }
}