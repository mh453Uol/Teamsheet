namespace Teamsheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyNameAndNameColumnToApplicationUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 125));
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String(nullable: false, maxLength: 125));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
