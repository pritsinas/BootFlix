namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Series", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Series", "ReleaseDate", c => c.DateTime());
        }
    }
}
