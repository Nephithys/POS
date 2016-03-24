namespace PointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eight2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TableNumber = c.Int(nullable: false),
                        MenuID = c.Int(nullable: false),
                        WorkProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menus", t => t.MenuID, cascadeDelete: true)
                .ForeignKey("dbo.WorkProfiles", t => t.WorkProfileID, cascadeDelete: true)
                .Index(t => t.MenuID)
                .Index(t => t.WorkProfileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "WorkProfileID", "dbo.WorkProfiles");
            DropForeignKey("dbo.Bills", "MenuID", "dbo.Menus");
            DropIndex("dbo.Bills", new[] { "WorkProfileID" });
            DropIndex("dbo.Bills", new[] { "MenuID" });
            DropTable("dbo.Bills");
        }
    }
}
