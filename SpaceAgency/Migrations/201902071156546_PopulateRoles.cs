using SpaceAgency.Models;

namespace SpaceAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles (Id, Name) Values (1, '"+ Role.ProductContentAdministrator + "')");
            Sql("INSERT INTO AspNetRoles (Id, Name) Values (2, '"+ Role.AgencyCustomer + "')");
        }
        
        public override void Down()
        {
        }
    }
}
