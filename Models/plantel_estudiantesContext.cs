using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class plantel_estudiantesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public plantel_estudiantesContext() : base("name=plantel_estudiantesContext")
        {
        }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Estudiante> Estudiantes { get; set; }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Asignatura> Asignaturas { get; set; }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Profesor> Profesors { get; set; }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Asistencia> Asistencias { get; set; }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Matricula> Matriculas { get; set; }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Curso> Cursoes { get; set; }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Jornada> Jornadas { get; set; }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Notificacion> Notificacions { get; set; }

        public System.Data.Entity.DbSet<plantel_estudiantes.Models.Padre> Padres { get; set; }
    
    }
}
