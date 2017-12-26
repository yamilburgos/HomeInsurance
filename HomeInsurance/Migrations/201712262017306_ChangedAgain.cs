namespace HomeInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "ResidenceTypes_DataGroupField");
            DropColumn("dbo.Locations", "ResidenceTypes_DataTextField");
            DropColumn("dbo.Locations", "ResidenceTypes_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "ResidenceTypes_DataValueField", c => c.String());
            AddColumn("dbo.Locations", "ResidenceTypes_DataTextField", c => c.String());
            AddColumn("dbo.Locations", "ResidenceTypes_DataGroupField", c => c.String());
        }
    }
}
