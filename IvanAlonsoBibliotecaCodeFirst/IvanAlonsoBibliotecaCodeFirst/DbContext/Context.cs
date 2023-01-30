using IvanAlonsoBibliotecaCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace IvanAlonsoBibliotecaCodeFirst.DbContext
{
    public class Context : System.Data.Entity.DbContext
    {
        public DbSet<Usuario>Usuarios { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public Context() : base("StringDBContext")
        {

        }
    }
}