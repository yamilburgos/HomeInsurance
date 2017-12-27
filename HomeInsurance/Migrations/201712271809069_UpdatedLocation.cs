namespace HomeInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedLocation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "AddressLine1", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Locations", "AddressLine2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Locations", "City", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Locations", "State", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Locations", "Zip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Zip", c => c.String(nullable: false));
            AlterColumn("dbo.Locations", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Locations", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Locations", "AddressLine2", c => c.String());
            AlterColumn("dbo.Locations", "AddressLine1", c => c.String(nullable: false));
        }
    }
}
