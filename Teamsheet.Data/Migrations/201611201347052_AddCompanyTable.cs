namespace Teamsheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedById = c.String(nullable: false),
                        ModifiedById = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Activities", "CreatedById", c => c.String(nullable: false));
            AddColumn("dbo.Activities", "ModifiedById", c => c.String(nullable: false));
            AddColumn("dbo.Sections", "CreatedById", c => c.String(nullable: false));
            AddColumn("dbo.Sections", "ModifiedById", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CompanyId");
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies", "Id");
            DropColumn("dbo.Activities", "CreatedBy");
            DropColumn("dbo.Activities", "ModifiedBy");
            DropColumn("dbo.Sections", "CreatedBy");
            DropColumn("dbo.Sections", "ModifiedBy");
            DropColumn("dbo.AspNetUsers", "CompanyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String(nullable: false, maxLength: 125));
            AddColumn("dbo.Sections", "ModifiedBy", c => c.String(nullable: false));
            AddColumn("dbo.Sections", "CreatedBy", c => c.String(nullable: false, maxLength: 125));
            AddColumn("dbo.Activities", "ModifiedBy", c => c.String(nullable: false));
            AddColumn("dbo.Activities", "CreatedBy", c => c.String(nullable: false, maxLength: 125));
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropColumn("dbo.AspNetUsers", "CompanyId");
            DropColumn("dbo.Sections", "ModifiedById");
            DropColumn("dbo.Sections", "CreatedById");
            DropColumn("dbo.Activities", "ModifiedById");
            DropColumn("dbo.Activities", "CreatedById");
            DropTable("dbo.Companies");
        }
    }
}
