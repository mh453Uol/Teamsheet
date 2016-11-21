namespace Teamsheet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedDayTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "DayId", "dbo.Days");
            DropForeignKey("dbo.Days", "WeekId", "dbo.Weeks");
            DropIndex("dbo.Entries", new[] { "DayId" });
            DropIndex("dbo.Days", new[] { "WeekId" });
            AddColumn("dbo.Entries", "WeekId", c => c.Int(nullable: false));
            CreateIndex("dbo.Entries", "WeekId");
            AddForeignKey("dbo.Entries", "WeekId", "dbo.Weeks", "Id", cascadeDelete: true);
            DropColumn("dbo.Entries", "DayId");
            DropTable("dbo.Days");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        WeekId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Entries", "DayId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Entries", "WeekId", "dbo.Weeks");
            DropIndex("dbo.Entries", new[] { "WeekId" });
            DropColumn("dbo.Entries", "WeekId");
            CreateIndex("dbo.Days", "WeekId");
            CreateIndex("dbo.Entries", "DayId");
            AddForeignKey("dbo.Days", "WeekId", "dbo.Weeks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Entries", "DayId", "dbo.Days", "Id", cascadeDelete: true);
        }
    }
}
