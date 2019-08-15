namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWatchModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Watches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ViewerId = c.Int(nullable: false),
                        SerieId = c.Int(nullable: false),
                        DateStarted = c.DateTime(nullable: false),
                        DateCompleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.SerieId, cascadeDelete: true)
                .ForeignKey("dbo.Viewers", t => t.ViewerId, cascadeDelete: true)
                .Index(t => t.ViewerId)
                .Index(t => t.SerieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Watches", "ViewerId", "dbo.Viewers");
            DropForeignKey("dbo.Watches", "SerieId", "dbo.Series");
            DropIndex("dbo.Watches", new[] { "SerieId" });
            DropIndex("dbo.Watches", new[] { "ViewerId" });
            DropTable("dbo.Watches");
        }
    }
}
