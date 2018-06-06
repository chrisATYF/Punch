namespace Punch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPunched : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PunchedClocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        PunchIn = c.DateTime(nullable: false),
                        PunchOut = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PunchedClocks", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.PunchedClocks", new[] { "ApplicationUserId" });
            DropTable("dbo.PunchedClocks");
        }
    }
}
