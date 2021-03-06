﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Estudiante
    {
        public int id { get; set; }
        [Required]
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string tdocumento { get; set; }
        public string documento { get; set; }
        public string telefono { get; set; }
        // Foreign keys
        public int UsuarioId { get; set; }
        public int MatriculaId { get; set; }
        // propiedades de navegacion
        public Usuario Usuario { get; set; }
        public Matricula Matricula { get; set; }
    }
}