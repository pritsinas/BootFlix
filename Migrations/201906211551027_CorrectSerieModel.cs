namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectSerieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "Seasons", c => c.Byte(nullable: false));
            AlterColumn("dbo.Series", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Series", "Season");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "Season", c => c.String(nullable: false));
            AlterColumn("dbo.Series", "Name", c => c.String());
            DropColumn("dbo.Series", "Seasons");
        }
    }
}
