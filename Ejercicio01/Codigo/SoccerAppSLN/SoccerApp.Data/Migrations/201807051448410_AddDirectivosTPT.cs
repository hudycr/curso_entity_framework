namespace SoccerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDirectivosTPT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directivos",
                c => new
                    {
                        DirectivoId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Activity = c.String(),
                        Departament = c.String(),
                        JefeId = c.Int(),
                    })
                .PrimaryKey(t => t.DirectivoId)
                .ForeignKey("dbo.Directivos", t => t.JefeId)
                .Index(t => t.JefeId);
            
            CreateTable(
                "dbo.Presidentes",
                c => new
                    {
                        DirectivoId = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.DirectivoId)
                .ForeignKey("dbo.Directivos", t => t.DirectivoId)
                .Index(t => t.DirectivoId);
            
            CreateTable(
                "dbo.Directores",
                c => new
                    {
                        DirectivoId = c.Int(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.DirectivoId)
                .ForeignKey("dbo.Directivos", t => t.DirectivoId)
                .Index(t => t.DirectivoId);
            
            CreateTable(
                "dbo.Secretarios",
                c => new
                    {
                        DirectivoId = c.Int(nullable: false),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.DirectivoId)
                .ForeignKey("dbo.Directivos", t => t.DirectivoId)
                .Index(t => t.DirectivoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Secretarios", "DirectivoId", "dbo.Directivos");
            DropForeignKey("dbo.Directores", "DirectivoId", "dbo.Directivos");
            DropForeignKey("dbo.Presidentes", "DirectivoId", "dbo.Directivos");
            DropForeignKey("dbo.Directivos", "JefeId", "dbo.Directivos");
            DropIndex("dbo.Secretarios", new[] { "DirectivoId" });
            DropIndex("dbo.Directores", new[] { "DirectivoId" });
            DropIndex("dbo.Presidentes", new[] { "DirectivoId" });
            DropIndex("dbo.Directivos", new[] { "JefeId" });
            DropTable("dbo.Secretarios");
            DropTable("dbo.Directores");
            DropTable("dbo.Presidentes");
            DropTable("dbo.Directivos");
        }
    }
}
