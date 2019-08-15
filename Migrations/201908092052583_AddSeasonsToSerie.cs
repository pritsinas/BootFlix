namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeasonsToSerie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seasons", "SerieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Seasons", "SerieId");
            AddForeignKey("dbo.Seasons", "SerieId", "dbo.Series", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seasons", "SerieId", "dbo.Series");
            DropIndex("dbo.Seasons", new[] { "SerieId" });
            DropColumn("dbo.Seasons", "SerieId");
        }
    }
}
