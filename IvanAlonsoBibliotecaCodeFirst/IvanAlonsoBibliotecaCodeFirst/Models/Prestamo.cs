using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvanAlonsoBibliotecaCodeFirst.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Libro Libro { get; set; }
    }
}