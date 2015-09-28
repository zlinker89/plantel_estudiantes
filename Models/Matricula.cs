using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Matricula
    {
        public int id { get; set; }
        [Required]
        // Foreign keys
        public int CursoId { get; set; }
        public int AsignaturaId { get; set; }
        public int EstudianteId { get; set; }
        // navegacion
        public Curso Curso { get; set; }
        public Asignatura Asignatura { get; set; }
        public Estudiante Estudiante { get; set; }

    }
}