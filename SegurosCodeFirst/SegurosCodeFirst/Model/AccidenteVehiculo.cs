using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosCodeFirst.Model
{
    public class AccidenteVehiculo
    {
        public int Id { get; set; }
        public virtual Accidente Accidente { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}