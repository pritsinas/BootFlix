namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSerieToGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Series", "GenreId");
            AddForeignKey("dbo.Series", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Series", "GenreId", "dbo.Genres");
            DropIndex("dbo.Series", new[] { "GenreId" });
            DropColumn("dbo.Series", "GenreId");
        }
    }
}
