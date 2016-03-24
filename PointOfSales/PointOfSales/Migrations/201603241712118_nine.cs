namespace PointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "UserID");
        }
    }
}
