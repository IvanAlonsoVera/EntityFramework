namespace SegurosCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Accidentes", newName: "Accidente");
            RenameTable(name: "dbo.Personas", newName: "Persona");
            RenameTable(name: "dbo.AccidenteVehiculoes", newName: "AccidenteVehiculo");
            RenameTable(name: "dbo.Vehiculoes", newName: "Vehiculo");
            RenameTable(name: "dbo.Multas", newName: "Multa");
            RenameTable(name: "dbo.PersonaAccidentes", newName: "PersonaAccidente");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PersonaAccidente", newName: "PersonaAccidentes");
            RenameTable(name: "dbo.Multa", newName: "Multas");
            RenameTable(name: "dbo.Vehiculo", newName: "Vehiculoes");
            RenameTable(name: "dbo.AccidenteVehiculo", newName: "AccidenteVehiculoes");
            RenameTable(name: "dbo.Persona", newName: "Personas");
            RenameTable(name: "dbo.Accidente", newName: "Accidentes");
        }
    }
}
