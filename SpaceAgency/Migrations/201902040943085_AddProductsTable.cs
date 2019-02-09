namespace SpaceAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcquisitionDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Missions", t => t.MissionId, cascadeDelete: true)
                .Index(t => t.MissionId);
            
            AlterColumn("dbo.Missions", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "MissionId", "dbo.Missions");
            DropIndex("dbo.Products", new[] { "MissionId" });
            AlterColumn("dbo.Missions", "Name", c => c.String());
            DropTable("dbo.Products");
        }
    }
}
