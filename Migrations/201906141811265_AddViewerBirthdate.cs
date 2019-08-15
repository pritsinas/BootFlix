namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewerBirthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viewers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viewers", "BirthDate");
        }
    }
}
