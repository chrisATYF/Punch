namespace Punch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewClockInOutTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClockIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PunchIn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClockOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PunchOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Clocks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClockIn = c.DateTime(nullable: false),
                        ClockOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ClockOuts");
            DropTable("dbo.ClockIns");
        }
    }
}
