using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosCodeFirst.Model
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public virtual Persona Persona { get; set; }
    }
}