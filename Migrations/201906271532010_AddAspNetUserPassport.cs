namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAspNetUserPassport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Passport", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Passport");
        }
    }
}
