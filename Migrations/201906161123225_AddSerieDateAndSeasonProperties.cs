namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSerieDateAndSeasonProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Series", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Series", "Season", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Series", "Season");
            DropColumn("dbo.Series", "DateAdded");
            DropColumn("dbo.Series", "ReleaseDate");
        }
    }
}
