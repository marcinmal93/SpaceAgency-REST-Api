namespace SpaceAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMissions1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Missions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Missions", "Name");
        }
    }
}
