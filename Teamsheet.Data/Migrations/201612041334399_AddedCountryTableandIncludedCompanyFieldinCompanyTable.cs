namespace Teamsheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCountryTableandIncludedCompanyFieldinCompanyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Companies", "AddressLine1", c => c.String(nullable: false, maxLength: 125));
            AddColumn("dbo.Companies", "AddressLine2", c => c.String(nullable: false, maxLength: 125));
            AddColumn("dbo.Companies", "AddressLine3", c => c.String());
            AddColumn("dbo.Companies", "PostCode", c => c.String());
            AddColumn("dbo.Companies", "Country", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Country");
            DropColumn("dbo.Companies", "PostCode");
            DropColumn("dbo.Companies", "AddressLine3");
            DropColumn("dbo.Companies", "AddressLine2");
            DropColumn("dbo.Companies", "AddressLine1");
            DropTable("dbo.Countries");
        }
    }
}
