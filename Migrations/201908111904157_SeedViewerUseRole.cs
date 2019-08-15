namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedViewerUseRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c3cfa6fb-7ee9-4e45-8fbc-27e6ffed74b5', N'CanManageViewers')
                  INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Passport]) VALUES (N'b21fca11-f32c-4732-8630-e1a13df58b65', N'AdminViewers@mail.com', 0, N'AL9TOEFygAhtWbhcasWdSb05OYWO2yt/n+yDDAY73aKOX5DLRdmoaG9BBSnSEaC3cw==', N'8e000ad4-3d42-43f4-87c2-17282895418b', NULL, 0, 0, NULL, 1, 0, N'AdminViewers@mail.com', N'XXX555')  
                  INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b21fca11-f32c-4732-8630-e1a13df58b65', N'c3cfa6fb-7ee9-4e45-8fbc-27e6ffed74b5')
                ");


        }
        
        public override void Down()
        {
        }
    }
}
