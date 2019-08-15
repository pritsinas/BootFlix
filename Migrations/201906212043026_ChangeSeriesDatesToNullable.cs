namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSeriesDatesToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Series", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Series", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Series", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Series", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
