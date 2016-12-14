namespace PointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "MenuImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "MenuImage");
        }
    }
}
