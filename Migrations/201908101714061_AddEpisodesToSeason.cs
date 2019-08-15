namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEpisodesToSeason : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Episodes", "SeasonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Episodes", "SeasonId");
            AddForeignKey("dbo.Episodes", "SeasonId", "dbo.Seasons", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Episodes", "SeasonId", "dbo.Seasons");
            DropIndex("dbo.Episodes", new[] { "SeasonId" });
            DropColumn("dbo.Episodes", "SeasonId");
        }
    }
}
