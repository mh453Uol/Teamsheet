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
                        CreatedById = c.String(nullable: false, maxLength: 128),
                        ModifiedById = c.String(nullable: false, maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById, cascadeDelete: true)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            AddColumn("dbo.Activities", "CreatedById", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Activities", "ModifiedById", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Sections", "CreatedById", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Sections", "ModifiedById", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Int());
            CreateIndex("dbo.Activities", "CreatedById");
            CreateIndex("dbo.Activities", "ModifiedById");
            CreateIndex("dbo.AspNetUsers", "CompanyId");
            CreateIndex("dbo.Sections", "CreatedById");
            CreateIndex("dbo.Sections", "ModifiedById");
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies", "Id");
            AddForeignKey("dbo.Activities", "CreatedById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Activities", "ModifiedById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sections", "CreatedById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sections", "ModifiedById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
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
            DropForeignKey("dbo.Sections", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sections", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Activities", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Activities", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.Sections", new[] { "ModifiedById" });
            DropIndex("dbo.Sections", new[] { "CreatedById" });
            DropIndex("dbo.Companies", new[] { "ModifiedById" });
            DropIndex("dbo.Companies", new[] { "CreatedById" });
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropIndex("dbo.Activities", new[] { "ModifiedById" });
            DropIndex("dbo.Activities", new[] { "CreatedById" });
            DropColumn("dbo.AspNetUsers", "CompanyId");
            DropColumn("dbo.Sections", "ModifiedById");
            DropColumn("dbo.Sections", "CreatedById");
            DropColumn("dbo.Activities", "ModifiedById");
            DropColumn("dbo.Activities", "CreatedById");
            DropTable("dbo.Companies");
        }
    }
}
