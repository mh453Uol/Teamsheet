namespace Teamsheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedByIdAndModifiedByIdColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "CreatedById", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Activities", "ModifiedById", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Sections", "CreatedById", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Sections", "ModifiedById", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Companies", "CreatedById", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Companies", "ModifiedById", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Activities", "CreatedById");
            CreateIndex("dbo.Activities", "ModifiedById");
            CreateIndex("dbo.Companies", "CreatedById");
            CreateIndex("dbo.Companies", "ModifiedById");
            CreateIndex("dbo.Sections", "CreatedById");
            CreateIndex("dbo.Sections", "ModifiedById");
            AddForeignKey("dbo.Companies", "CreatedById", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Companies", "ModifiedById", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Activities", "CreatedById", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Activities", "ModifiedById", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Sections", "CreatedById", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Sections", "ModifiedById", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sections", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Activities", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Activities", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "CreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.Sections", new[] { "ModifiedById" });
            DropIndex("dbo.Sections", new[] { "CreatedById" });
            DropIndex("dbo.Companies", new[] { "ModifiedById" });
            DropIndex("dbo.Companies", new[] { "CreatedById" });
            DropIndex("dbo.Activities", new[] { "ModifiedById" });
            DropIndex("dbo.Activities", new[] { "CreatedById" });
            AlterColumn("dbo.Companies", "ModifiedById", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "CreatedById", c => c.String(nullable: false));
            AlterColumn("dbo.Sections", "ModifiedById", c => c.String(nullable: false));
            AlterColumn("dbo.Sections", "CreatedById", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "ModifiedById", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "CreatedById", c => c.String(nullable: false));
        }
    }
}
