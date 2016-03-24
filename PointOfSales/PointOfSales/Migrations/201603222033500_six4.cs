namespace PointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class six4 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Events");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        title = c.String(),
                        date = c.String(),
                        start = c.String(),
                        end = c.String(),
                        url = c.String(),
                        allDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
