namespace HomeInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Homeowners", "SSN", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.Homeowners", "EmailAddress", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Properties", "DwellingStyle", c => c.Int(nullable: false));
            DropColumn("dbo.Locations", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Username", c => c.String());
            AlterColumn("dbo.Properties", "DwellingStyle", c => c.String());
            AlterColumn("dbo.Homeowners", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Homeowners", "SSN", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
