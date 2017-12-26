namespace HomeInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertyRequirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Properties", "DwellingStyle", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "RoofMaterial", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "GarageType", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "NumFullBaths", c => c.String(nullable: false));
            AlterColumn("dbo.Properties", "NumHalfBaths", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "NumHalfBaths", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "NumFullBaths", c => c.Int(nullable: false));
            AlterColumn("dbo.Properties", "GarageType", c => c.String());
            AlterColumn("dbo.Properties", "RoofMaterial", c => c.String());
            AlterColumn("dbo.Properties", "DwellingStyle", c => c.Int(nullable: false));
        }
    }
}
