namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeasons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeasonName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seasons");
        }
    }
}
