namespace CultivaPina.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cultivoes",
                c => new
                    {
                        CultivoId = c.Int(nullable: false, identity: true),
                        CultivoFechaSiembra = c.DateTime(nullable: false),
                        CultivoPeso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CultivoFechaRecoleccion = c.DateTime(nullable: false),
                        SectorId = c.Int(nullable: false),
                        PinaId = c.Int(nullable: false),
                        CultivoHectareas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CultivoId)
                .ForeignKey("dbo.Pinas", t => t.PinaId, cascadeDelete: true)
                .ForeignKey("dbo.Sectors", t => t.SectorId, cascadeDelete: true)
                .Index(t => t.PinaId)
                .Index(t => t.SectorId);
            
            CreateTable(
                "dbo.Pinas",
                c => new
                    {
                        PinaId = c.Int(nullable: false, identity: true),
                        PinaNombre = c.String(),
                        PinaMaduracion = c.Single(nullable: false),
                        PinaProductividadPorHectarea = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PinaId);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        SectorId = c.Int(nullable: false, identity: true),
                        SectorNombre = c.String(),
                    })
                .PrimaryKey(t => t.SectorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cultivoes", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Cultivoes", "PinaId", "dbo.Pinas");
            DropIndex("dbo.Cultivoes", new[] { "SectorId" });
            DropIndex("dbo.Cultivoes", new[] { "PinaId" });
            DropTable("dbo.Sectors");
            DropTable("dbo.Pinas");
            DropTable("dbo.Cultivoes");
        }
    }
}
