namespace CultivaPina.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration7 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Cultivo_Insert",
                p => new
                    {
                        CultivoFechaSiembra = p.DateTime(),
                        CultivoPeso = p.Decimal(precision: 18, scale: 2),
                        SectorId = p.Int(),
                        PinaId = p.Int(),
                        CultivoHectareas = p.Int(),
                        CultivoFechaRecoleccion = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Cultivoes]([CultivoFechaSiembra], [CultivoPeso], [SectorId], [PinaId], [CultivoHectareas], [CultivoFechaRecoleccion])
                      VALUES (@CultivoFechaSiembra, @CultivoPeso, @SectorId, @PinaId, @CultivoHectareas, @CultivoFechaRecoleccion)
                      
                      DECLARE @CultivoId int
                      SELECT @CultivoId = [CultivoId]
                      FROM [dbo].[Cultivoes]
                      WHERE @@ROWCOUNT > 0 AND [CultivoId] = scope_identity()
                      
                      SELECT t0.[CultivoId]
                      FROM [dbo].[Cultivoes] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[CultivoId] = @CultivoId"
            );
            
            CreateStoredProcedure(
                "dbo.Cultivo_Update",
                p => new
                    {
                        CultivoId = p.Int(),
                        CultivoFechaSiembra = p.DateTime(),
                        CultivoPeso = p.Decimal(precision: 18, scale: 2),
                        SectorId = p.Int(),
                        PinaId = p.Int(),
                        CultivoHectareas = p.Int(),
                        CultivoFechaRecoleccion = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Cultivoes]
                      SET [CultivoFechaSiembra] = @CultivoFechaSiembra, [CultivoPeso] = @CultivoPeso, [SectorId] = @SectorId, [PinaId] = @PinaId, [CultivoHectareas] = @CultivoHectareas, [CultivoFechaRecoleccion] = @CultivoFechaRecoleccion
                      WHERE ([CultivoId] = @CultivoId)"
            );
            
            CreateStoredProcedure(
                "dbo.Cultivo_Delete",
                p => new
                    {
                        CultivoId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Cultivoes]
                      WHERE ([CultivoId] = @CultivoId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Cultivo_Delete");
            DropStoredProcedure("dbo.Cultivo_Update");
            DropStoredProcedure("dbo.Cultivo_Insert");
        }
    }
}
