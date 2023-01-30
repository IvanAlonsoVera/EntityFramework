using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosCodeFirst.Model
{
    public class Multa
    {
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Lugar { get; set; }
        public double Importe { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual Persona Persona { get; set; }
    }
}