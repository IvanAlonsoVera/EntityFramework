using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosCodeFirst.Model
{
    public class PersonaAccidente
    {
        public int Id { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Accidente Accidente { get; set; }
    }
}