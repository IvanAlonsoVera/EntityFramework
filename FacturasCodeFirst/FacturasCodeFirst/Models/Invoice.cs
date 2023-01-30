using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturasCodeFirst.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime DueDate { get; set; }
        public int ProyectID { get; set; }
        public virtual Proyect Proyect { get; set; }
    }
}