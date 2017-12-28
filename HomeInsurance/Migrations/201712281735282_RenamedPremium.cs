namespace HomeInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedPremium : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "MonthlyPremium", c => c.Double(nullable: false));
            DropColumn("dbo.Quotes", "Premium");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quotes", "Premium", c => c.Double(nullable: false));
            DropColumn("dbo.Quotes", "MonthlyPremium");
        }
    }
}
