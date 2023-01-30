namespace FacturasCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueDate = c.DateTime(nullable: false),
                        ProyectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proyects", t => t.ProyectID, cascadeDelete: true)
                .Index(t => t.ProyectID);
            
            CreateTable(
                "dbo.Proyects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "ProyectID", "dbo.Proyects");
            DropForeignKey("dbo.Proyects", "ClientID", "dbo.Clients");
            DropIndex("dbo.Proyects", new[] { "ClientID" });
            DropIndex("dbo.Invoices", new[] { "ProyectID" });
            DropTable("dbo.Proyects");
            DropTable("dbo.Invoices");
            DropTable("dbo.Clients");
        }
    }
}
