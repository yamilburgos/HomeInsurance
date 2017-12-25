namespace HomeInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckingOnDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Homeowners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DOB = c.String(nullable: false),
                        IsRetired = c.Boolean(nullable: false),
                        SSN = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeownerId = c.Int(nullable: false),
                        ResidenceType = c.String(nullable: false),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        ResidenceUse = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Homeowners", t => t.HomeownerId, cascadeDelete: true)
                .Index(t => t.HomeownerId);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuoteId = c.Int(nullable: false),
                        PolicyKey = c.String(),
                        PolicyEffDate = c.String(),
                        PolicyEndDate = c.String(),
                        PolicyTerm = c.Int(nullable: false),
                        PolicyStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quotes", t => t.QuoteId, cascadeDelete: true)
                .Index(t => t.QuoteId);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        Premium = c.Double(nullable: false),
                        DwellingCoverage = c.Double(nullable: false),
                        DetachedStructure = c.Double(nullable: false),
                        PersonalProperty = c.Double(nullable: false),
                        AddnlLivgExpense = c.Double(nullable: false),
                        MedicalExpense = c.Double(nullable: false),
                        Deductible = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        MarketValue = c.Int(nullable: false),
                        YearBuilt = c.Int(nullable: false),
                        SquareFootage = c.Int(nullable: false),
                        DwellingStyle = c.Int(nullable: false),
                        RoofMaterial = c.String(),
                        GarageType = c.String(),
                        NumFullBaths = c.Int(nullable: false),
                        NumHalfBaths = c.Int(nullable: false),
                        HasSwimmingPool = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Quotes", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Properties", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "HomeownerId", "dbo.Homeowners");
            DropForeignKey("dbo.Homeowners", "UserId", "dbo.Users");
            DropIndex("dbo.Properties", new[] { "LocationId" });
            DropIndex("dbo.Quotes", new[] { "PropertyId" });
            DropIndex("dbo.Policies", new[] { "QuoteId" });
            DropIndex("dbo.Locations", new[] { "HomeownerId" });
            DropIndex("dbo.Homeowners", new[] { "UserId" });
            DropTable("dbo.Properties");
            DropTable("dbo.Quotes");
            DropTable("dbo.Policies");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.Homeowners");
        }
    }
}
