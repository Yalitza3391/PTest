namespace CultivaPina.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sectors", "SectorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sectors", "SectorName", c => c.String());
        }
    }
}
