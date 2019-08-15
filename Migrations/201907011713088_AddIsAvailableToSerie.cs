namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsAvailableToSerie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "IsAvailable", c => c.Boolean(nullable: false));
            Sql("UPDATE Series SET IsAvailable = 1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Series", "IsAvailable");
        }
    }
}
