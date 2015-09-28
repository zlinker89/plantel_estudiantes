using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace plantel_estudiantes.Models
{
    public class Jornada
    {
        public int id { get; set; }
        [Required]
        public string nombre_jornada { get; set; }
    }
}