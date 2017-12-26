namespace HomeInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLocationDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "ResidenceUse", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "ResidenceUse", c => c.String());
        }
    }
}
