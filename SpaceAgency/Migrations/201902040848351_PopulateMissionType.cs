namespace SpaceAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMissionType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MissionTypes (Id, Name) VALUES (1, 'Panchromatic')");
            Sql("INSERT INTO MissionTypes (Id, Name) VALUES (2, 'Multispectral')");
            Sql("INSERT INTO MissionTypes (Id, Name) VALUES (3, 'Hyperspectral')");
        }
        
        public override void Down()
        {
        }
    }
}
