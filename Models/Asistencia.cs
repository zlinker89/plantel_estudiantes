using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Asistencia
    {
        public int Id { get; set; }
        public bool estado { get; set; }
        public int EstudianteId { get; set; }
        public int PofesorId { get; set; }
    
        public virtual Estudiante Estudiante { get; set; }
        public virtual Profesor Pofesor { get; set; }
    }
}