namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembership : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SubscriptionType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Viewers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Viewers", "Name", c => c.String());
            DropColumn("dbo.MembershipTypes", "SubscriptionType");
        }
    }
}
