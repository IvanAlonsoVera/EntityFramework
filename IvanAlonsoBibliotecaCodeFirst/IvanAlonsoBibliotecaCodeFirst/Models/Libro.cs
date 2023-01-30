using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvanAlonsoBibliotecaCodeFirst.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Editorial { get; set; }
        public int Paginas { get; set; }
        public virtual Autor Autor { get; set; }
    }
}