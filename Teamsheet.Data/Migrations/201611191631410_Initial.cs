namespace Teamsheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 125),
                        Description = c.String(nullable: false, maxLength: 255),
                        SectionId = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 125),
                        ModifiedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 125),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(nullable: false, maxLength: 125),
                        ModifiedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        WeekId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Weeks", t => t.WeekId, cascadeDelete: true)
                .Index(t => t.WeekId);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.DateTime(nullable: false),
                        DayId = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: false)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: true)
                .Index(t => t.DayId)
                .Index(t => t.ActivityId);
            
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Days", "WeekId", "dbo.Weeks");
            DropForeignKey("dbo.Entries", "DayId", "dbo.Days");
            DropForeignKey("dbo.Entries", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.Activities", "SectionId", "dbo.Sections");
            DropIndex("dbo.Entries", new[] { "ActivityId" });
            DropIndex("dbo.Entries", new[] { "DayId" });
            DropIndex("dbo.Days", new[] { "WeekId" });
            DropIndex("dbo.Activities", new[] { "SectionId" });
            DropTable("dbo.Weeks");
            DropTable("dbo.Entries");
            DropTable("dbo.Days");
            DropTable("dbo.Sections");
            DropTable("dbo.Activities");
        }
    }
}
