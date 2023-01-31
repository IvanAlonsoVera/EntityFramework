namespace IvanAlonsoBibliotecaCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Libroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        ISBN = c.String(),
                        Editorial = c.String(),
                        Paginas = c.Int(nullable: false),
                        Autor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autors", t => t.Autor_Id)
                .Index(t => t.Autor_Id);
            
            CreateTable(
                "dbo.Prestamoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaPrestamo = c.DateTime(nullable: false),
                        FechaDevolucion = c.DateTime(nullable: false),
                        Libro_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libroes", t => t.Libro_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Libro_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prestamoes", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Prestamoes", "Libro_Id", "dbo.Libroes");
            DropForeignKey("dbo.Libroes", "Autor_Id", "dbo.Autors");
            DropIndex("dbo.Prestamoes", new[] { "Usuario_Id" });
            DropIndex("dbo.Prestamoes", new[] { "Libro_Id" });
            DropIndex("dbo.Libroes", new[] { "Autor_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Prestamoes");
            DropTable("dbo.Libroes");
            DropTable("dbo.Autors");
        }
    }
}
