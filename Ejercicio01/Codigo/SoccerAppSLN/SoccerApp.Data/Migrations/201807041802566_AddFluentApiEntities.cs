namespace SoccerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFluentApiEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goles",
                c => new
                    {
                        GolId = c.Int(nullable: false, identity: true),
                        ScoringTime = c.Int(nullable: false),
                        ScorerId = c.Int(nullable: false),
                        JuegoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GolId)
                .ForeignKey("dbo.Juegos", t => t.JuegoId, cascadeDelete: true)
                .ForeignKey("dbo.Jugadores", t => t.ScorerId)
                .Index(t => t.ScorerId)
                .Index(t => t.JuegoId);
            
            CreateTable(
                "dbo.Juegos",
                c => new
                    {
                        JuegoId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        GameNumber = c.Int(nullable: false),
                        EquipoLocalId = c.Int(nullable: false),
                        EquipoVisitanteId = c.Int(nullable: false),
                        TorneoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JuegoId)
                .ForeignKey("dbo.Torneos", t => t.TorneoId, cascadeDelete: true)
                .ForeignKey("dbo.Equipos", t => t.EquipoLocalId)
                .ForeignKey("dbo.Equipos", t => t.EquipoVisitanteId)
                .Index(t => t.EquipoLocalId)
                .Index(t => t.EquipoVisitanteId)
                .Index(t => t.TorneoId);
            
            CreateTable(
                "dbo.Equipos",
                c => new
                    {
                        EquipoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 500),
                        Pais = c.String(nullable: false, maxLength: 100),
                        Founded = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        EstadioId = c.Int(),
                        TorneoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipoId)
                .ForeignKey("dbo.Torneos", t => t.TorneoId, cascadeDelete: true)
                .Index(t => t.TorneoId);
            
            CreateTable(
                "dbo.Jugadores",
                c => new
                    {
                        JugadorId = c.Int(nullable: false, identity: true),
                        NombreJugador = c.String(nullable: false, maxLength: 100),
                        NumeroJugador = c.Int(),
                        Active = c.Boolean(),
                        FechaNacimiento = c.DateTime(),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JugadorId)
                .ForeignKey("dbo.Equipos", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Estadios",
                c => new
                    {
                        EstadioId = c.Int(nullable: false, identity: true),
                        NombreEstadio = c.String(nullable: false, maxLength: 100),
                        Pais = c.String(maxLength: 100),
                        NombreCoorporativo = c.String(maxLength: 100),
                        EquipoId = c.Int(),
                    })
                .PrimaryKey(t => t.EstadioId)
                .ForeignKey("dbo.Equipos", t => t.EstadioId)
                .Index(t => t.EstadioId);
            
            CreateTable(
                "dbo.Torneos",
                c => new
                    {
                        TorneoId = c.Int(nullable: false, identity: true),
                        NombreTorneo = c.String(nullable: false, maxLength: 200),
                        FechaCreacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.TorneoId);
            
            CreateTable(
                "dbo.Officials",
                c => new
                    {
                        OfficialId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OfficialId);
            
            CreateTable(
                "dbo.OficialesJuegos",
                c => new
                    {
                        JuegoId = c.Int(nullable: false),
                        OficialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JuegoId, t.OficialId })
                .ForeignKey("dbo.Juegos", t => t.JuegoId, cascadeDelete: true)
                .ForeignKey("dbo.Officials", t => t.OficialId, cascadeDelete: true)
                .Index(t => t.JuegoId)
                .Index(t => t.OficialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goles", "ScorerId", "dbo.Jugadores");
            DropForeignKey("dbo.Juegos", "EquipoVisitanteId", "dbo.Equipos");
            DropForeignKey("dbo.OficialesJuegos", "OficialId", "dbo.Officials");
            DropForeignKey("dbo.OficialesJuegos", "JuegoId", "dbo.Juegos");
            DropForeignKey("dbo.Juegos", "EquipoLocalId", "dbo.Equipos");
            DropForeignKey("dbo.Equipos", "TorneoId", "dbo.Torneos");
            DropForeignKey("dbo.Juegos", "TorneoId", "dbo.Torneos");
            DropForeignKey("dbo.Estadios", "EstadioId", "dbo.Equipos");
            DropForeignKey("dbo.Jugadores", "TeamId", "dbo.Equipos");
            DropForeignKey("dbo.Goles", "JuegoId", "dbo.Juegos");
            DropIndex("dbo.OficialesJuegos", new[] { "OficialId" });
            DropIndex("dbo.OficialesJuegos", new[] { "JuegoId" });
            DropIndex("dbo.Estadios", new[] { "EstadioId" });
            DropIndex("dbo.Jugadores", new[] { "TeamId" });
            DropIndex("dbo.Equipos", new[] { "TorneoId" });
            DropIndex("dbo.Juegos", new[] { "TorneoId" });
            DropIndex("dbo.Juegos", new[] { "EquipoVisitanteId" });
            DropIndex("dbo.Juegos", new[] { "EquipoLocalId" });
            DropIndex("dbo.Goles", new[] { "JuegoId" });
            DropIndex("dbo.Goles", new[] { "ScorerId" });
            DropTable("dbo.OficialesJuegos");
            DropTable("dbo.Officials");
            DropTable("dbo.Torneos");
            DropTable("dbo.Estadios");
            DropTable("dbo.Jugadores");
            DropTable("dbo.Equipos");
            DropTable("dbo.Juegos");
            DropTable("dbo.Goles");
        }
    }
}
