using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosCodeFirst.Model
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }


    }
}