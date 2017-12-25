namespace HomeInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingSelectList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "ResidenceTypes_DataGroupField", c => c.String());
            AddColumn("dbo.Locations", "ResidenceTypes_DataTextField", c => c.String());
            AddColumn("dbo.Locations", "ResidenceTypes_DataValueField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "ResidenceTypes_DataValueField");
            DropColumn("dbo.Locations", "ResidenceTypes_DataTextField");
            DropColumn("dbo.Locations", "ResidenceTypes_DataGroupField");
        }
    }
}
