﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvanAlonsoBibliotecaCodeFirst.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}