namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET SubscriptionType = 'Free' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET SubscriptionType = 'Basic' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET SubscriptionType = 'Standard' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET SubscriptionType = 'Premium' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
