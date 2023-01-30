using SegurosCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SegurosCodeFirst.DbContext
{
    public class Context :System.Data.Entity.DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Accidente> Accidentes { get; set; }
        public DbSet<Multa> Multas { get; set; }
        public DbSet<PersonaAccidente> PersonaAccidentes { get; set; }
        public DbSet<AccidenteVehiculo> AccidenteVehiculos { get; set; }
        public Context() : base("StringDBContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}