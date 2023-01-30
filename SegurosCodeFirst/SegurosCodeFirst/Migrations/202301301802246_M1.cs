namespace SegurosCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accidentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Lugar = c.String(),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Poblacion = c.String(),
                        Telefono = c.String(),
                        DNI = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccidenteVehiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Accidente_Id = c.Int(),
                        Vehiculo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accidentes", t => t.Accidente_Id)
                .ForeignKey("dbo.Vehiculoes", t => t.Vehiculo_Id)
                .Index(t => t.Accidente_Id)
                .Index(t => t.Vehiculo_Id);
            
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.Multas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Lugar = c.String(),
                        Importe = c.Double(nullable: false),
                        Persona_Id = c.Int(),
                        Vehiculo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Persona_Id)
                .ForeignKey("dbo.Vehiculoes", t => t.Vehiculo_Id)
                .Index(t => t.Persona_Id)
                .Index(t => t.Vehiculo_Id);
            
            CreateTable(
                "dbo.PersonaAccidentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Accidente_Id = c.Int(),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accidentes", t => t.Accidente_Id)
                .ForeignKey("dbo.Personas", t => t.Persona_Id)
                .Index(t => t.Accidente_Id)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonaAccidentes", "Persona_Id", "dbo.Personas");
            DropForeignKey("dbo.PersonaAccidentes", "Accidente_Id", "dbo.Accidentes");
            DropForeignKey("dbo.Multas", "Vehiculo_Id", "dbo.Vehiculoes");
            DropForeignKey("dbo.Multas", "Persona_Id", "dbo.Personas");
            DropForeignKey("dbo.AccidenteVehiculoes", "Vehiculo_Id", "dbo.Vehiculoes");
            DropForeignKey("dbo.Vehiculoes", "Persona_Id", "dbo.Personas");
            DropForeignKey("dbo.AccidenteVehiculoes", "Accidente_Id", "dbo.Accidentes");
            DropForeignKey("dbo.Accidentes", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.PersonaAccidentes", new[] { "Persona_Id" });
            DropIndex("dbo.PersonaAccidentes", new[] { "Accidente_Id" });
            DropIndex("dbo.Multas", new[] { "Vehiculo_Id" });
            DropIndex("dbo.Multas", new[] { "Persona_Id" });
            DropIndex("dbo.Vehiculoes", new[] { "Persona_Id" });
            DropIndex("dbo.AccidenteVehiculoes", new[] { "Vehiculo_Id" });
            DropIndex("dbo.AccidenteVehiculoes", new[] { "Accidente_Id" });
            DropIndex("dbo.Accidentes", new[] { "Persona_Id" });
            DropTable("dbo.PersonaAccidentes");
            DropTable("dbo.Multas");
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.AccidenteVehiculoes");
            DropTable("dbo.Personas");
            DropTable("dbo.Accidentes");
        }
    }
}
