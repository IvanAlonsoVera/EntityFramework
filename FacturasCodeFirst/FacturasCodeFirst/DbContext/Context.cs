using FacturasCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FacturasCodeFirst.DbContext
{
    public class Context : System.Data.Entity.DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Proyect> Proyects { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public Context() : base("StringDBContext")
        {

        }
    }
}