using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Notificacion
    {
        public int id { get; set; }
        [Required]
        public string asunto { get; set; }
        public string mensaje { get; set; }
        public DateTime fecha_creacion { get; set; }
        public bool estado { get; set; }
        // Foreign keys
        public int UsuarioId { get; set; }
        public int EstudianteId { get; set; }

        // propiedades de navegacion
        public Usuario Usuario { get; set; }
        public Estudiante Estudiante{ get; set; }
    }
}