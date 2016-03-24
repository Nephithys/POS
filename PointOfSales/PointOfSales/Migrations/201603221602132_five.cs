namespace PointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkProfiles", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkProfiles", "UserID");
        }
    }
}
