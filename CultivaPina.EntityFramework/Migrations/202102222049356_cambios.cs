namespace CultivaPina.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sectors", "SectorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sectors", "SectorName");
        }
    }
}
