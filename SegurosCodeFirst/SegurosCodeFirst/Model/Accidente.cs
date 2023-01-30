using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosCodeFirst.Model
{
    public class Accidente
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Lugar { get; set; }
        public virtual Persona Persona { get; set; }
    }
}