namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3a744d47-35d2-4a5d-bdf0-8a6420b2e617', N'CanManageSeries')
                  INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'01978948-ac07-40fb-bbc5-0c1184a7a8e3', N'AdminSeries@mail.com', 0, N'AIKmymUJbiIQ3rjNMcw2ECtMPbeqfbp8dJacdLW10QDhGOBUTRYmPfjqwwNPSCSu4A==', N'0f83f518-0cb9-4585-a547-2732980ca29f', NULL, 0, 0, NULL, 1, 0, N'AdminSeries@mail.com')
                  INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f5270fce-f890-4476-9642-8de31672d51f', N'guest@gmail.com', 0, N'AEbvQpE50WDTRiSj2ey1VgwyJ0FJ+FM5Zxoux9jWpSKapwp+h8S5ntqYfRka1ZEyuA==', N'ac9a46aa-8287-44d0-9012-82726f272b20', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                  INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'01978948-ac07-40fb-bbc5-0c1184a7a8e3', N'3a744d47-35d2-4a5d-bdf0-8a6420b2e617')
                ");
        }
        
        public override void Down()
        {

        }
    }
}
