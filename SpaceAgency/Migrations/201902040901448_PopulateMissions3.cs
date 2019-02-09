namespace SpaceAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMissions3 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Missions ON");

            string sqlStatement1 =
                "INSERT INTO Missions (Id, Name, StartDate, FinishDate, MissionTypeId) " +
                "VALUES ({0}, '{1}', convert(datetime, '{2}', 105), convert(datetime, '{3}', 105), {4})";
            Sql(String.Format(sqlStatement1, 1, "Mision1", "04-02-2019", "10-02-2019", 1));
            Sql(String.Format(sqlStatement1, 2, "Mision2", "04-02-2019", "12-02-2019", 2));

            Sql("SET IDENTITY_INSERT Missions OFF");
        }
        
        public override void Down()
        {
        }
    }
}
